using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ShoppingCart.Tests
{
    [TestClass]
    public class CartTests
    {
        //Gereksinimler
        //1. Sepete ürün eklenebilmelidir.
        //2. Sepette olan ürün çıkarılabilmelidir.
        //3. Sepet temizlenebilmelidir.

        private static CartItem _cartItem;
        private static CartManager _cartManager;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _cartManager = new CartManager();
            _cartItem = new CartItem
            {
                Product = new Product
                {
                    ProductId = 1,
                    ProductName = "Laptop",
                    UnitPrice = 2500,
                },
                Quantity = 1
            };

            _cartManager.Add(_cartItem);

        }

        [TestCleanup]
        public static void ClassCleanup()
        {
            _cartManager.Clear();
        }

        [TestMethod]
        public void SepeteUrunEklenebilmelidir()
        {
            //Arrange
            const int beklenen = 1;

            //Act
            var toplamElemanSayisi = _cartManager.TotalItems;

            //Assert
            Assert.AreEqual(beklenen, toplamElemanSayisi);

        }

        [TestMethod]
        public void SepetteOlanUrunlerCikartilabilmelidir()
        {
            //Arrange
            var sepetteOlanElemanSayisi = _cartManager.TotalItems;

            //Act
            _cartManager.Remove(1);
            var sepetteKalanElemanSayisi = _cartManager.TotalItems;

            //Assert
            Assert.AreEqual(sepetteOlanElemanSayisi - 1, sepetteKalanElemanSayisi);
        }

        [TestMethod]
        public void SepetTemizlenebilmelidir()
        {
            //Act
            _cartManager.Clear();

            //Assert
            Assert.AreEqual(0, _cartManager.TotalQuantity);
            Assert.AreEqual(0, _cartManager.TotalItems);
        }

        [TestMethod]
        public void SepetteFarkliUrunEklemeDurumu1Adet()
        {
            //Arrange
            int toplamAdet = _cartManager.TotalQuantity;
            int toplamElemanSayisi = _cartManager.TotalItems;

            //Act

            _cartManager.Add(new CartItem
            {
                Product = new Product
                {
                    ProductId = 2,
                    ProductName = "mouse",
                    UnitPrice = 10
                },
                Quantity = 1,
            });

            //Assert
            Assert.AreEqual(toplamAdet+1,_cartManager.TotalQuantity);
            Assert.AreEqual(toplamElemanSayisi+1,_cartManager.TotalItems);
        }

        [TestMethod]
        public void SepetteOlanUrunden1AdetEklendigindeToplamUrunAdedi1Artmali()
        {
            //Arrange
            int toplamAdet = _cartManager.TotalQuantity;
            int toplamElemanSayisi = _cartManager.TotalItems;

            //Act
            _cartManager.Add(_cartItem);

            //Assert
            Assert.AreEqual(toplamAdet + 1, _cartManager.TotalQuantity);
            Assert.AreEqual(toplamElemanSayisi, _cartManager.TotalItems);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SepetteAyniUrundenIkinciKezEklendigindeHataVermelidir()
        {
            _cartManager.Add(_cartItem);
        }
    }
}
