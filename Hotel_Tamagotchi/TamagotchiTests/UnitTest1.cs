using System;
using System.Collections.Generic;
using Hotel_Tamagotchi.Controllers;
using Hotel_Tamagotchi.Helpers.Validators;
using Hotel_Tamagotchi.Models;
using Hotel_Tamagotchi.Models.Repositories;
using Hotel_Tamagotchi.Models.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TamagotchiTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidateSelectedAmount()
        {
            Hotel_TamagotchiContext context = new Hotel_TamagotchiContext();
            IRoomRepository roomRepository = new RoomRepository(context);
            ITamagotchiRepository tamagotchiRepository = new TamagotchiRepository(context);

            ReservationValidator validator = new ReservationValidator();

            // arrange  
            RoomViewModel roomViewModel = new RoomViewModel();
            Room room = new Room();
            room.Size = 2;
            roomViewModel.AmountOfTamagotchis = 1;
            roomViewModel.Room = room;

            // act  
            bool result = ReservationValidator.ValidateSelectedAmount(roomViewModel);

            // assert  
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateSelectedTamagotchis()
        {
            Hotel_TamagotchiContext context = new Hotel_TamagotchiContext();
            IRoomRepository roomRepository = new RoomRepository(context);
            ITamagotchiRepository tamagotchiRepository = new TamagotchiRepository(context);

            ReservationValidator validator = new ReservationValidator();

            // arrange  
            RoomViewModel roomViewModel = new RoomViewModel();
            List<int> ids = new List<int> { 1, 2, 3, 4 };
            roomViewModel.SelectedTamagotchisIDList = ids;

            Room room = new Room();
            room.Size = 4;
            roomViewModel.AmountOfTamagotchis = 4;
            roomViewModel.Room = room;

            // act  
            bool result = ReservationValidator.ValidateSelectTamagotchis(roomViewModel);

            // assert  
            Assert.IsTrue(result);
        }
    }
}
