
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace AuthServer.Web
{
    public class DevelopmentKeys
    {
        public DevelopmentKeys(
            IWebHostEnvironment env
            
            )
        {
            RsaKey = RSA.Create();
            var path = Path.Combine(env.ContentRootPath, "crypto_key");

            if (File.Exists(path))
            {
                var rsaKey = RSA.Create();
                rsaKey.ImportRSAPrivateKey(File.ReadAllBytes(path),out _);
            }
            else
            {
                var privateKey = RsaKey.ExportRSAPrivateKey();
                File.WriteAllBytes(path, privateKey);
            }
        }

        public RSA RsaKey { get; private set; }
        public RsaSecurityKey RsaSecurityKey => new RsaSecurityKey(RsaKey);
    }
}
