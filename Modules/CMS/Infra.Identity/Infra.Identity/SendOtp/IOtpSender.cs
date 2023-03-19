namespace Infra.Identity.SendOtp
{
    public interface IOtpSender
    {
        void SendOtp(string receptor, string otp);
    }
}
