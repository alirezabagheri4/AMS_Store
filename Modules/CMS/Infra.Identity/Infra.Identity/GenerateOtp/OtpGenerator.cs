using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtpNet;

namespace Infra.Identity.GenerateOtp
{
    public class OtpGenerator
    {
        public static void GenerateOtp()
        {
            var bytes = Base32Encoding.ToBytes("JBSWY3DPEHPK3PXP");

            var totp = new Totp(bytes, 300,OtpHashMode.Sha1);

            var result = totp.ComputeTotp(DateTime.UtcNow);

            Console.WriteLine(result);

            var input = Console.ReadLine();
            long timeStepMatched;
            bool verify = totp.VerifyTotp(input, out timeStepMatched, window: null);

            Console.WriteLine("{0}-:{1}", "timeStepMatched", timeStepMatched);
            Console.WriteLine("{0}-:{1}", "Remaining seconds", totp.RemainingSeconds());
            Console.WriteLine("{0}-:{1}", "verify", verify);

        }
    }
}
