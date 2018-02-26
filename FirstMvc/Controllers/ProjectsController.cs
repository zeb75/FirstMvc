 using FirstMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMvc.Controllers
{
    public class ProjectsController : Controller
    {


        private static Random rng = new Random(DateTimeOffset.Now.Millisecond);

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sokoban()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GuessingGame()
        {
            int rnd = rng.Next(1, 100);
            this.Session["Answer"] = rnd;
            this.Session["GuessList"] = new List<int>();
            GuessNum guess = new GuessNum
            {
                Answer = (int)this.Session["Answer"],
            };

            return View(guess);
        }
     
        [HttpPost]
        public ActionResult GuessingGame(GuessNum guess)
        {
            guess.Answer = (int)this.Session["Answer"];
            guess.CompareNum();
            return View(guess);
            
        }


        [HttpGet]
        public ActionResult FeverCheck()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FeverCheck(double temp = 0)
        {
            Fever fever = new Fever(temp);
            ViewBag.Fever = fever;
            return View();
        }

    }
}