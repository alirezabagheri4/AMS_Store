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
        public bool VerifyOtp(string phoneNumber, string input)
        {
            var totp = _memoryCache.Get<Totp>(phoneNumber);
            if (totp == null) return false;

            bool verify = totp.VerifyTotp(input, out var timeStepMatched, window: null);
            Console.WriteLine("{0}-:{1}", "timeStepMatched", timeStepMatched);
            Console.WriteLine("{0}-:{1}", "Remaining seconds", totp.RemainingSeconds());
            Console.WriteLine("{0}-:{1}", "verify", verify);
            return verify;
        }

        //TODO:Refactor
        public Task<SendOtpResponse> SendOtp(string receptor, string otp)
        {
            string? sender = _configuration.GetRequiredSection("sender").ToString();
            var message = $"{_configuration.GetRequiredSection("KaveNegarMessage")} \n {otp} ";
            var api = new KavenegarApi(_configuration.GetRequiredSection("ApiKeyKaveNegar").ToString());
            api.Send(sender, receptor, message);
            return Task.FromResult(new SendOtpResponse
            {
                OtpResponseCodeEnum = EOtpResponseCode.Ok,
                PhoneNumber = receptor
            });
        }
    }
}
