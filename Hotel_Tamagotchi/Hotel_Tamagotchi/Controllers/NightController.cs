using Hotel_Tamagotchi.Helpers;
using Hotel_Tamagotchi.Helpers.Validators;
using Hotel_Tamagotchi.Models;
using Hotel_Tamagotchi.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Tamagotchi.Controllers
{
    public class NightController : Controller
    {
        private ITamagotchiRepository _tamagotchiRepository;
        private List<Tamagotchi> _tamagotchis;

        public NightController()
        {

        }

        public NightController(ITamagotchiRepository tamagotchiRepository)
        {
            _tamagotchiRepository = tamagotchiRepository;

            _tamagotchis = _tamagotchiRepository.GetAll();
        }

        [HttpGet]
        public ActionResult StartNight()
        {
            ChangeProperties();
            NightValidator.UnlinkRooms(_tamagotchis, _tamagotchiRepository);

            return RedirectToAction("Index",
                        "Tamagotchis",
                        new { });
        }

        public void ChangeProperties()
        {
            NightHelper.ChangeProperties(_tamagotchiRepository);
    }
}