using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hotel_Tamagotchi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Tamagotchi.Models;

namespace Hotel_Tamagotchi.Controllers.Tests
{
    [TestClass()]
    public class RoomsControllerTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            Assert.Fail();
            Assert(new RoomsController().Create(new Room()), true);
        }
    }
}