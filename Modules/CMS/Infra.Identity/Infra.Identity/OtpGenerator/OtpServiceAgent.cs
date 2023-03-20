using Domain.Aggregates.OtpAggregate.Interface;
using Kavenegar;
using Microsoft.Extensions.Configuration;
using OtpNet;

namespace Infra.Identity.OtpGenerator
{
    public class OtpServiceAgent : IExternalOtpService
    {
        private readonly IConfiguration _configuration;

        public OtpServiceAgent(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateOtp()
        {
            var bytes = Base32Encoding.ToBytes("JBSWY3DPEHPK3PXP");
            var totp = new Totp(bytes, 180, OtpHashMode.Sha1, 4);
            var result = totp.ComputeTotp(DateTime.UtcNow);
            return result;
        }

        public bool VerifyOtp(Totp totp, string input)
        {
            long timeStepMatched;
            bool verify = totp.VerifyTotp(input, out timeStepMatched, window: null);

            Console.WriteLine("{0}-:{1}", "timeStepMatched", timeStepMatched);
            Console.WriteLine("{0}-:{1}", "Remaining seconds", totp.RemainingSeconds());
            Console.WriteLine("{0}-:{1}", "verify", verify);
            return verify;
        }

        //TODO:change void to enum or bool
        public void SendOtp(string receptor, string otp)
        {
            string? sender = _configuration.GetRequiredSection("sender").ToString();
            var message = $"{_configuration.GetRequiredSection("KaveNegarMessage")} \n {otp} ";
            var api = new KavenegarApi(_configuration.GetRequiredSection("ApiKeyKaveNegar").ToString());
            api.Send(sender, receptor, message);
        }
    }
}
