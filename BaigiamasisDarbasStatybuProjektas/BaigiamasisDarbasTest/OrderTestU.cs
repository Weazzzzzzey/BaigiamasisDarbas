using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatybuProjektasBL;
using System.Collections.Generic;

namespace BaigiamasisDarbasTest
{
    [TestClass]
    public class OrderTestU
    {
        public Order vienasOrderis = new Order(new EsamuDaliuRepositorycs(),0,0, new KlientuRepositorija());
        // paduoda orderID ir UzsakovoID
        public OrderTestU()
        {

        }
        
        public void Uzpildymas()
        {
            vienasOrderis.PridetiDali(0, 1);
            vienasOrderis.PridetiDali(2, 4);
        }
        [TestMethod]
        public void TrinimoMetodasIrPridejimo()
        {
            // Arrange
            Uzpildymas();
            vienasOrderis.PridetiDali(4, 1);
            int expected = 2;

            // Act
            vienasOrderis.IstrintiDalis(2);
            int actual = vienasOrderis.perkamosDalysSuKiekiu.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void UzsakymuKiekisSarasae()
        {
            // Arrange
            Uzpildymas();
            int expected = 2;

            // Act
            int actual = vienasOrderis.perkamosDalysSuKiekiu.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ApskaiciuotiBendraKaina()
        {
            // Arrange
            Uzpildymas();
            decimal expected = 27500;

            // Act
            decimal actual = vienasOrderis.OrderPrice();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OrderRepo()
        {
            // Arrange
            Uzpildymas();
            decimal expected = 27500;

            // Act
            decimal actual = vienasOrderis.OrderPrice();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        
    }
}
