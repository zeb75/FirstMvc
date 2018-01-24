using FirstMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMvc.Controllers
{
    public class PersonController : Controller
    {
        public ActionResult Index()
        {
            List<Person> personList;

            if (Session["Add"] != null)
            {
                personList = (List<Person>)Session["Add"];
            }
            else
            {
                personList = Person._people;
            }

            var model =
                from r in personList
                orderby r.Name
                select r;

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return View(Person._people);
            }
            List<Person> personList = new List<Person>();
            foreach (var item in Person._people)
            {
                if (item.City.ToLower().Contains(search.ToLower()) || item.Name.ToLower().Contains(search.ToLower()))
                {
                    personList.Add(item);
                }
            }
            return View(personList);
        }

        [HttpGet]
        public ActionResult AjaxCreatePerson()
        {
            return PartialView("_CreatePerson", new Person());
        }
        [HttpPost]
        public ActionResult SaveAjaxCreatePerson(int id, [Bind(Exclude = "")] Person person)
        {
                Person me = new Person();
            if (ModelState.IsValid)
            {         
                me.Name = person.Name;
                me.PhoneNumber = person.PhoneNumber;
                me.City = person.City;
                Person._people.Add(me);
            }
                return PartialView("_Aperson", me);
            
        }

        [HttpGet]
        public ActionResult AjaxEditPerson(int id)
        {
            return PartialView("_EditPerson", Person._people.SingleOrDefault(c => c.Id == id));
        }

        [HttpPost]
        public ActionResult SaveAjaxEditPerson(int id,[Bind(Exclude = "")] Person person)
        {
            Person toUpdate = Person._people.SingleOrDefault(c => c.Id == id);
            if (ModelState.IsValid)
            {
                toUpdate.Name = person.Name;
                toUpdate.PhoneNumber = person.PhoneNumber;
                toUpdate.City = person.City;
            }
            return PartialView("_Aperson", person);

        }

        [HttpGet]
        public ActionResult AjaxCancelPerson(int id)

        {
            return PartialView("_Aperson", Person._people.SingleOrDefault(c => c.Id == id));
        }

        public ActionResult AjaxRemovePerson(int id)
        {
            Person._people.Remove(Person._people.SingleOrDefault(c => c.Id == id));
            return Content("");
        }

        public ActionResult PartPerson(int id)
        {
            Person temp = Person._people.SingleOrDefault(c => c.Id == id);

            return PartialView("_Person", temp);
        }


    }
  



}

