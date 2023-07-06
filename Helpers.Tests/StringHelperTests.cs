using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Tests
{
    [TestClass]
    public class StringHelperTests
    {
        // metod ismini gereksinim adiyla aynı olmalı
        [TestMethod]
        public void Girilen_ifadenin_başındaki_ve_sonundaki_fazla_bosluklar_silinmelidir()
        {
            // Arrange
            var ifade = "   İsmail Aydemir      ";
            var beklenen = "İsmail Aydemir";

            // Act

            var gerceklesen = StringHelper.FazlaBosluklariSil(ifade);

            // Assert
            Assert.AreEqual(beklenen, gerceklesen);
        }

        public void Girilen_ifadenin_icindeki_fazla_bosluklar_silinmelidir() { 
            // Arrange
            var ifade = "   İsmail Aydemir    Engin Demiroğ    Ahmet  Mehmet       Veysi     ";
            var beklenen = "İsmail Aydemir Engin Demiroğ Ahmet Mehmet Veysi";

            // Act

            var gerceklesen = StringHelper.FazlaBosluklariSil(ifade);

            // Assert
            Assert.AreEqual(beklenen, gerceklesen);
        }
    }
}
