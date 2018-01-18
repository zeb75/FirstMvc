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
        // GET: Person
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
            List<Person>  personList = new List<Person>();
            foreach (var item in Person._people)
            {
                if (item.City.ToLower().Contains(search.ToLower()) || item.Name.ToLower().Contains(search.ToLower()))
                {
                    personList.Add(item);
                }
            }
            return View(personList);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View(new Person());
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(string Name, string PhoneNumber, string City)
        {
            List<Person> personList;
           
            if (Session["Add"] != null)
            {
                personList = (List <Person> )Session["Add"];
            }
            else
            {
                personList = Person._people;
            }
            personList.Add(new Person() { Name = Name, PhoneNumber = PhoneNumber, City = City });
            Session["Names"] = personList;
            return RedirectToAction("index");
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            var person = Person._people.Single(r => r.Id == id);
            return View(person);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var person = Person._people.Single(r => r.Id == id);
            if(TryUpdateModel(person))
            {
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: PeopleReviews/Delete/5
        public ActionResult Delete(int id)
        {
            var review = Person._people.Single(r => r.Id == id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: PeopleReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {

            var review = Person._people.Single(r => r.Id == id);
            Person._people.Remove(review);
            return RedirectToAction("Index");
        }

        public ActionResult _Person(Person person)
        {
            return PartialView(person);
        }
    }
}
