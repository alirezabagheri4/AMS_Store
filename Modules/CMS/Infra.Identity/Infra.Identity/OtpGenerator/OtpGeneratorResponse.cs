using OtpNet;

namespace Infra.Identity.OtpGenerator
{
    public class OtpGeneratorResponse
    {
        public Totp Totp { get; set; }
        public string? OtpCode { get; set; }
    }
}
