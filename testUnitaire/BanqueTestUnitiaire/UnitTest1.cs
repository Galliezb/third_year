using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using compteBancaire;
using Moq;

namespace BanqueTestUnitiaire {

    compteBancaire.IDAL fausseData;
    
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        static public void Debit_15sursolde20_return() {

            Banque cb = new Banque( 150, "Kahim" );

        }
    }

    // permet de tester avant de lancer tous les autres test
    //[TestInitialize]

    // Tescleanup permet de nettoyer les ressources après les test
    //[TestCleanup]

    //[fixture]
    //public void Debit_15surSolde5_RetourneException() {
    //    Banque cb = new Banque( 150, "Kahim" );

    //}

    [TestInitialize]
    public void init() {
        fausseData = Mock.
    }

}
