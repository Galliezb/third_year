using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BouncyCastle_crypto.Models;

namespace BouncyCastle_crypto.Controllers {
    public class HomeController : Controller {

        Crypto macle = new Crypto();

        // GET: Home
        public ActionResult Index() {

            ViewBag.PublicKey = macle.PublicKey;

            return View();
        }

        [HttpPost]
        public string Connect(Identification i) {

            // version wiwi du decryptage
            AsymmetricCipherKeyPair keyPair = macle.lesdeuxcles;
            IBufferedCipher cipher = CipherUtilities.GetCipher( "RSA/NONE/PKCS1Padding" );
            cipher.Init( false, keyPair.Private );
            byte[] secretBytes = Convert.FromBase64String( i.Login );
            byte[] decrypted = cipher.DoFinal( secretBytes );
            var data = System.Text.Encoding.UTF8.GetString( decrypted );

            return "OK";

        }
    }
}