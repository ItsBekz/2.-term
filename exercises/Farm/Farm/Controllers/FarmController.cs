using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FarmMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FarmMVC.Controllers
{
    public class FarmController : Controller
    {
        // GET: FarmController
        public static Farm myFarm { get; set; }

        public static Farm getFarm()
        {
            if(myFarm == null)
            {
                myFarm = new Farm();
                myFarm.id = 1;
                myFarm.name = "my Farm";
                Animal a1 = new Animal();
                a1.animalId = 1;
                a1.species = "Dog";
                a1.weight = 5;
                Animal a2 = new Animal();
                a2.animalId = 2;
                a2.species = "Cat";
                a2.weight = 2;
                Animal a3 = new Animal();
                a3.animalId = 3;
                a3.species = "Horse";
                a3.weight = 40;
                Animal a4 = new Animal();
                a4.animalId = 4;
                a4.species = "Bird";
                a4.weight = 3;
                myFarm.animalList = new List<Animal>();
                myFarm.animalList.Add(a1);
                myFarm.animalList.Add(a2);
                myFarm.animalList.Add(a3);
                myFarm.animalList.Add(a4);
            }
            return myFarm;
        }

        public List<Animal> GetAnimals()
        {
            return myFarm.animalList;
        }
        public ActionResult Index()
        {
            getFarm();
            ViewBag.animalSelectList = new SelectList(GetAnimals(), "animalId", "species");
            return View(myFarm);
        }

        // GET: FarmController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FarmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FarmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            Animal a = new Animal()
            {
                animalId = myFarm.animalList.Count + 1
            };
            a.species = collection["species"];
            a.weight = int.Parse(collection["weight"]);
            myFarm.animalList.Add(a);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FarmController/Edit/5
        public ActionResult Edit(int id, string species, int weight)
        {
            Animal a = myFarm.animalList.Find(x => x.animalId == id);
            return View(a);
        }

        // POST: FarmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            Animal a = myFarm.animalList.Find(x => x.animalId == id);
            a.species = collection["species"];
            a.weight = int.Parse(collection["weight"]);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FarmController/Delete/5
        public ActionResult Delete(int id)
        {
            Animal a = myFarm.animalList.Find(x => x.animalId == id);
            myFarm.animalList.Remove(a);
            return View();
        }

        // POST: FarmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
