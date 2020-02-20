using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatybuProjektasBL;
using System.Collections.Generic;

namespace BaigiamasisDarbasTest
{
    [TestClass]
    public class OrderItemTest
    {
        EsamuDaliuRepositorycs esamosDalys = new EsamuDaliuRepositorycs();
        

        public OrderItem DaliesPapildymas()
        {
            //sudedamosiosDalysIrKainorastis.Add(new SudedamojiDalis(0,"Pamatas", 7500m));

            List<SudedamojiDalis> PaimtaDalisIsImones = esamosDalys.Retrieve();
            OrderItem vienaDalisSuKaina = new OrderItem(PaimtaDalisIsImones[0], 2);
            return vienaDalisSuKaina;
        }
        
        [TestMethod]
        public void SavikainosApsiskaiciavimas()
        {
            // Arrange
            OrderItem vienaDalis = DaliesPapildymas();
            decimal actual = vienaDalis.ItemPrise();

            // Act
            decimal expected = 15000m;

            // Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
