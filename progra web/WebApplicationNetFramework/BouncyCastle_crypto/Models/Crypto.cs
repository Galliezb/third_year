using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BouncyCastle_crypto.Models {
    public class Crypto {

        public AsymmetricCipherKeyPair lesdeuxcles { get;set; }
        public string PublicKey { get;set; }

        public Crypto() {

            int strength = 512;

            var kpgen = new RsaKeyPairGenerator();
            kpgen.Init( new KeyGenerationParameters( new SecureRandom( new CryptoApiRandomGenerator() ), strength ));

            // on stock la clé privé sous forme AsymmetricCipherKeyPair
            lesdeuxcles = kpgen.GenerateKeyPair();

            // sous forme de base 64 comme nécsssaire pour l'envoi de la clé public vers le form
            //PrivateKeyInfo pkInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(keyPair.Private);
            //PrivateKey = Convert.ToBase64String( pkInfo.GetDerEncoded() );

            SubjectPublicKeyInfo info = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo( lesdeuxcles.Public);
            PublicKey = Convert.ToBase64String( info.GetDerEncoded() );


        }
    }
}