using Domain.Aggregates.OtpAggregate.Interface;
using Domain.Aggregates.OtpAggregate.Models;
using Domain.Aggregates.OtpAggregate.Models.@enum;
using Kavenegar;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using OtpNet;

namespace Infra.Identity.OtpGenerator
{
    public class OtpServiceAgent : IExternalOtpService
    {
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _memoryCache;

        public OtpServiceAgent(IConfiguration configuration, IMemoryCache memoryCache)
        {
            _configuration = configuration;
            _memoryCache = memoryCache;
        }


        //TODO:Refactor
        public string GenerateOtp(string phoneNumber)
        {
            var bytes = Base32Encoding.ToBytes("JBSWY3DPEHPK3PXP");
            var totp = new Totp(bytes, 180, OtpHashMode.Sha1, 4);
            var result = totp.ComputeTotp(DateTime.UtcNow);
            _memoryCache.Set(phoneNumber, totp, options: new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(3).AddSeconds(1),
            });
            return result;
        }


        //TODO:Refactor
        public Task<bool> VerifyOtp(string phoneNumber, string input)
        {
            var totp = _memoryCache.Get<Totp>(phoneNumber);
            if (totp == null) return Task.FromResult(false);

            bool verify = totp.VerifyTotp(input, out var timeStepMatched, window: null);
            Console.WriteLine("{0}-:{1}", "timeStepMatched", timeStepMatched);
            Console.WriteLine("{0}-:{1}", "Remaining seconds", totp.RemainingSeconds());
            Console.WriteLine("{0}-:{1}", "verify", verify);
            return Task.FromResult(verify);
        }


        //TODO:Refactor
        public Task<SendOtpResponse> SendOtp(string receptor, string otp)
        {
            try
            {
                Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi(_configuration?.GetSection("Identity")["ApiKeyKaveNegar"]);
                var result = api.Send("10008663",
                    receptor, $"{_configuration?.GetSection("Identity")["KaveNegarMessage"]} \n {otp} ");
                return Task.FromResult(new SendOtpResponse
                {
                    OtpResponseCodeEnum = eSendOtpResponseCode.Ok,
                    PhoneNumber = receptor
                });
            }
            catch (Kavenegar.Exceptions.ApiException ex)
            {
                // در صورتی که خروجی وب سرویس 200 نباشد این خطارخ می دهد.
                Console.Write("Message : " + ex.Message);
                return Task.FromResult(new SendOtpResponse
                {
                    OtpResponseCodeEnum = eSendOtpResponseCode.Unknown,
                    PhoneNumber = receptor
                });
            }
            catch (Kavenegar.Exceptions.HttpException ex)
            {
                // در زمانی که مشکلی در برقرای ارتباط با وب سرویس وجود داشته باشد این خطا رخ می دهد
                Console.Write("Message : " + ex.Message);
                return Task.FromResult(new SendOtpResponse
                {
                    OtpResponseCodeEnum = eSendOtpResponseCode.Unknown,
                    PhoneNumber = receptor
                });
            }
        }

    }
}
