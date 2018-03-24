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
            Hotel_TamagotchiContext context = new Hotel_TamagotchiContext();
            IRoomRepository roomRepository = new RoomRepository(context);
            ITamagotchiRepository tamagotchiRepository = new TamagotchiRepository(context);

            ReservationController reservationController = new ReservationController(roomRepository, tamagotchiRepository, new RoomViewModel());

            // arrange  
            RoomViewModel roomViewModel = new RoomViewModel();
            Room room = new Room();
            room.Size = 1;
            roomViewModel.AmountOfTamagotchis = 1;
            roomViewModel.Room = room;

            // act  
            bool result = reservationController.ValidateSelectedAmount(roomViewModel);

            // assert  
            Assert.IsTrue(result);
        }

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
    }
}
