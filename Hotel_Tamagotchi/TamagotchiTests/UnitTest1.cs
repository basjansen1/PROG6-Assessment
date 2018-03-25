using System;
using System.Collections.Generic;
using Hotel_Tamagotchi.Controllers;
using Hotel_Tamagotchi.Helpers;
using Hotel_Tamagotchi.Helpers.Validators;
using Hotel_Tamagotchi.Models;
using Hotel_Tamagotchi.Models.Repositories;
using Hotel_Tamagotchi.Models.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TamagotchiTests
{
    [TestClass]
    public class UnitTest1
    {
        Hotel_TamagotchiContext context = new Hotel_TamagotchiContext();

        [TestMethod]
        public void ValidateSelectedAmount()
        {
            //Hotel_TamagotchiContext context = new Hotel_TamagotchiContext();
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
            //Hotel_TamagotchiContext context = new Hotel_TamagotchiContext();
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

        [TestMethod]
        public void UnlinkRooms()
        {
            ITamagotchiRepository tamagotchiRepository = new DummyTamagotchiRepository();
            Tamagotchi tamagotchi = new Tamagotchi();
            Room room = new Room();

            room.Type = "ChillRoom";

            tamagotchi.Alive = true;
            tamagotchi.ID = 1;
            tamagotchi.Boredom = 20;
            tamagotchi.Health = 50;
            tamagotchi.Level = 1;
            tamagotchi.CurrentRoom = room;

            List<Tamagotchi> tamagotchis = new List<Tamagotchi>();
            tamagotchis.Add(tamagotchi);

            NightValidator.UnlinkRooms(tamagotchis, tamagotchiRepository);

            var tamagotchisResult = tamagotchiRepository.GetAll();

            Assert.IsNull(tamagotchisResult[4].CurrentRoom);
        }

        [TestMethod]
        public void CheckSizeTamagotchiList()
        {
            Room room = new Room();
            List<Tamagotchi> tamagotchis = new List<Tamagotchi>();
            tamagotchis.Add(new Tamagotchi());
            room.Size = 3;
            room.TamagotchiList = tamagotchis;

            Assert.IsNotNull(room.TamagotchiList);
        }

        [TestMethod]
        public void CheckPrimaryId()
        {
            Room room = new Room();
            List<Tamagotchi> tamagotchis = new List<Tamagotchi>();
            tamagotchis.Add(new Tamagotchi());
            room.ID = 7;
            room.TamagotchiList = tamagotchis;

            int expectedId = 7;

            Assert.AreEqual(expectedId, room.ID);
        }

        [TestMethod]
        public void CheckRoom()
        {
            IRoomRepository roomRepository = new DummyRoomRepository();
            roomRepository.Add(new Room());
            roomRepository.Add(new Room());
            roomRepository.Add(new Room());
            roomRepository.Add(new Room());
            roomRepository.Add(new Room());

            bool result = RoomValidator.CanDelete(roomRepository);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddTamagotchi()
        {
            ITamagotchiRepository dummy = new DummyTamagotchiRepository();
            Tamagotchi tamagotchi = new Tamagotchi();
            tamagotchi.Alive = true;
            tamagotchi.ID = 8;
            tamagotchi.Boredom = 20;
            tamagotchi.Health = 50;
            tamagotchi.Level = 1;

            var result = dummy.Add(tamagotchi);

            Assert.AreEqual(tamagotchi, result);
        }

        [TestMethod]
        public void CountElements()
        {
            ITamagotchiRepository dummy = new DummyTamagotchiRepository();

            int expectedItemsInList = 5;

            int result = dummy.GetAll().Count;

            Assert.AreEqual(expectedItemsInList, result);
        }

        [TestMethod]
        public void GetTamagotchiId()
        {
            ITamagotchiRepository dummy = new DummyTamagotchiRepository();

            int expectedId = 1;

            var result = dummy.Get(0) as Tamagotchi;

            Assert.AreEqual(expectedId, result.ID);
        }

        [TestMethod]
        public void DeleteTamagotchi()
        {
            ITamagotchiRepository dummy = new DummyTamagotchiRepository();

            Tamagotchi tamagotchi = new Tamagotchi();
            tamagotchi.Alive = true;
            tamagotchi.ID = 10;
            tamagotchi.Boredom = 20;
            tamagotchi.Health = 50;
            tamagotchi.Level = 1;

            int expectedCount = dummy.GetAll().Count;

            dummy.Add(tamagotchi);
            dummy.Delete(tamagotchi);

            Assert.AreEqual(expectedCount, dummy.GetAll().Count);
        }

        [TestMethod]
        public void AddRoom()
        {
            IRoomRepository dummy = new DummyRoomRepository();
            Room room = new Room();
            room.ID = 10;
            room.Size = 3;

            var result = dummy.Add(room);

            Assert.AreEqual(room, result);
        }

        [TestMethod]
        public void CountRoomElements()
        {
            IRoomRepository dummy = new DummyRoomRepository();

            int expectedItemsInList = 2;

            int result = dummy.GetAll().Count;

            Assert.AreEqual(expectedItemsInList, result);
        }

        [TestMethod]
        public void CheckChangeProperties()
        {
            ITamagotchiRepository dummy = new DummyTamagotchiRepository();

            NightHelper.ChangeProperties(dummy);

            int expectedHealth = 50;
            var realHealth = dummy.Get(0).Health;

            Assert.AreEqual(expectedHealth, realHealth);
        }

        [TestMethod]
        public void DeleteRoom()
        {
            IRoomRepository dummy = new DummyRoomRepository();

            Room room = new Room();
            room.ID = 66;
            room.Size = 5;
            room.Type = "Chillroom";

            int expectedCount = dummy.GetAll().Count;

            dummy.Add(room);
            dummy.Delete(room);

            Assert.AreEqual(expectedCount, dummy.GetAll().Count);
        }

        [TestMethod]
        public void GetRoomId()
        {
            IRoomRepository dummy = new DummyRoomRepository();

            int expectedId = 1;

            var result = dummy.Get(0) as Room;

            Assert.AreEqual(expectedId, result.ID);
        }

        [TestMethod]
        public void ValidateRoomType()
        {
            Tamagotchi tama = new Tamagotchi();
            Room room = new Room();
            room.Type = "Chillroom";
            tama.CurrentRoom = room;

            var expectedResult = "Chillroom";

            Assert.AreEqual(expectedResult, tama.CurrentRoom.Type);
        }

        [TestMethod]
        public void GetTamagotchis()
        {
            RoomViewModel room = new RoomViewModel();
            List<Tamagotchi> tamagotchis = new List<Tamagotchi>();
            tamagotchis.Add(new Tamagotchi());
            room.Tamagotichis = tamagotchis;

            Assert.IsNotNull(room.Tamagotichis);
        }

        [TestMethod]
        public void CheckAmountOfTamagotchis()
        {
            RoomViewModel room = new RoomViewModel();
            List<int> options = new List<int>();
            options.Add(1);
            options.Add(2);
            options.Add(3);

            room.AmountOfTamagotchisOptions = options;

            int expectedCount = 3;

            Assert.AreEqual(expectedCount, room.AmountOfTamagotchisOptions.Count);
        }
    }
}
