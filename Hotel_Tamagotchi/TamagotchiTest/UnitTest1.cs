using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hotel_Tamagotchi;
using Hotel_Tamagotchi.Models.ViewModels;
using Hotel_Tamagotchi.Models;
using Hotel_Tamagotchi.Models.Repositories;
using Hotel_Tamagotchi.Controllers;

namespace TamagotchiTest
{
    [TestClass]
    public class UnitTest1
    {
        [DataSource(@"Provider=Microsoft.SqlServerCe.Client.4.0; Data Source=C:\Data\MathsData.sdf;", "Numbers")]

        [TestMethod]
        public void TestMethod1()
        {
            IRoomRepository roomRepository = new RoomRepository();
            ITamagotchiRepository tamagotchiRepository = new TamagotchiRepository();

            ReservationController reservationController = new ReservationController();

            // arrange  
            RoomViewModel roomViewModel = new RoomViewModel();
            Room room = new Room();
            room.Size = 1;
            roomViewModel.AmountOfTamagotchis = 1;
            roomViewModel.Room = room;

            // act  
            

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
    }
}
