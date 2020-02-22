using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatybuProjektasBL;
using System.Collections.Generic;

namespace BaigiamasisDarbasTest
{
    [TestClass]
    public class OrderRepositoryTest
    {
        OrdersRepository Orderiai;

        [TestInitialize]
        public void TestInitialize()
        {
            Orderiai = new OrdersRepository(new EsamuDaliuRepositorycs(), new KlientuRepositorija());
        }

        [TestMethod]
        public void ArSarasasTuscias()
        {
            // Arrange
            List<Order> visiuzsakymai = Orderiai.PerziuretiVisusUzsakymus();
            int actual = visiuzsakymai.Count;

            // Act
            int expected = 0;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PatikrintiArSarasasAuga()
        {
            // Arrange
            Orderiai.PridetiNaujaUzsakyma(0, 0);
            List<Order> visiuzsakymai = Orderiai.PerziuretiVisusUzsakymus();
            int actual = visiuzsakymai.Count;

            // Act
            int expected = 1;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PatikrintiArGalimaPridetiDaliIrepo()
        {
            // Arrange
            Orderiai.PridetiNaujaUzsakyma(0, 0);
            Orderiai.pridetiDaliUsakymui(0, 0, 2);
            Order uzsakymas = Orderiai.PerziuretiUzsakymaPagalOrderID(0);
            decimal actual = uzsakymas.OrderPrice();

            // Act
            decimal expected = 15000m;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PakeistiOrderioStatusa()
        {
            // Arrange
            Orderiai.PridetiNaujaUzsakyma(0, 0);
            Orderiai.pridetiDaliUsakymui(0, 0, 2);
            Orderiai.PakeistiStatusa(0, 1);
            Order vienasOrderis = Orderiai.PerziuretiUzsakymaPagalOrderID(0);
            int actual = vienasOrderis.Statusas;
            // Act
            int expected = 1;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IstrintiUzsakyma()
        {
            // Arrange
            Orderiai.PridetiNaujaUzsakyma(0, 0);
            Orderiai.PridetiNaujaUzsakyma(1, 0);
            Orderiai.PridetiNaujaUzsakyma(2, 0);
            Orderiai.PridetiNaujaUzsakyma(3, 0);
            Orderiai.PridetiNaujaUzsakyma(4, 0);
            Orderiai.IstrintiUzsakyma(3);
            List<Order> visiuzsakymai = Orderiai.PerziuretiVisusUzsakymus();
            int actual = visiuzsakymai.Count;
            // Act
            int expected = 4;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PatikrintiArTrinaTaUzsakyma()
        {
            // Arrange
            Orderiai.PridetiNaujaUzsakyma(0, 0);
            Orderiai.PridetiNaujaUzsakyma(1, 0);
            Orderiai.PridetiNaujaUzsakyma(2, 0);
            Orderiai.PridetiNaujaUzsakyma(3, 0);
            Orderiai.PridetiNaujaUzsakyma(4, 0);
            Orderiai.IstrintiUzsakyma(3);
            List<Order> visiuzsakymai = Orderiai.PerziuretiVisusUzsakymus();
            bool actual = false;
            foreach (var item in visiuzsakymai)
            {
                if (item.OrderID == 3)
                {
                    actual = true;
                }
            }
 
            // Act
            bool expected = false;

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
