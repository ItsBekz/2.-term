using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FarmMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FarmMVC.Controllers
{
    public class OwnerController : Controller
    {
        // GET: OwnerController
        public static List<Owner> listOfOwners;

        public static List<Owner> showOwners()
        {
            if(listOfOwners == null)
            {
                listOfOwners = new List<Owner>();
                Owner o1 = new Owner();
                o1.id = 1;
                o1.name = "Carl Jacobsen";
                o1.myAnimal = "Owns no animal";
                listOfOwners.Add(o1);
                Owner o2 = new Owner();
                o2.id = 2;
                o2.name = "Hans Arrowhead";
                o2.myAnimal = "Owns no animal";
                listOfOwners.Add(o2);
                Owner o3 = new Owner();
                o3.id = 3;
                o3.name = "Kent Clarkson";
                o3.myAnimal = "Owns no animal";
                listOfOwners.Add(o3);
                Owner o4 = new Owner();
                o4.id = 4;
                o4.name = "Poul Smithesson";
                o4.myAnimal = "Owns no animal";
                listOfOwners.Add(o4);
            }
            return listOfOwners;
        }
        public ActionResult Index()
        {
            showOwners();
            return View(listOfOwners);
        }

        // GET: OwnerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OwnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: OwnerController/Edit/5
        public ActionResult Edit(int id, string name, string Animal)
        {
            FarmController.getFarm();
            var animalInstance = new FarmController().GetAnimals();
            ViewBag.animalSelectList = new SelectList(animalInstance, "animalId", "species");
            Owner o = listOfOwners.Find(x => x.id == id);
            return View(o);
        }

        // POST: OwnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            Owner o = listOfOwners.Find(x => x.id == id);
            o.name = collection["name"];
            Animal selectedAnimal = 
            if (selectedAnimal != null)
            {
                // Set myAnimal to the species property value of the selected animal
                o.myAnimal = selectedAnimal.species;
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OwnerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OwnerController/Delete/5
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
