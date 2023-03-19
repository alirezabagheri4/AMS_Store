using Kavenegar;
using Microsoft.Extensions.Configuration;

namespace Infra.Identity.SendOtp
{
    public class OtpSender:IOtpSender
    {
        private readonly IConfiguration _configuration;
        public OtpSender(IConfiguration configuration)
        {
            _configuration = configuration;
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