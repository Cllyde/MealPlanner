using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MealPlanner.Models;

namespace MealPlanner.Controllers
{
    public class MealsController : Controller
    {
        /// <summary>
        /// Data context for Meal objects.
        /// </summary>
        private MealPlannerContext db = new MealPlannerContext();

        /// <summary>
        /// Static field to hold the list of Meal objects in the current plan.
        /// </summary>
        private static List<Meal> _meals = new List<Meal>();

        // GET: Meals
        public ActionResult Index()
        {
            return View(db.Meals.OrderBy(m => m.Name).ToList());
        }

        // GET: Meals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // GET: Meals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Ingredients,Directions,MealCategory,Url")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                db.Meals.Add(meal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meal);
        }

        // GET: Meals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // POST: Meals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Ingredients,Directions,MealCategory,Url")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meal);
        }

        // GET: Meals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // POST: Meals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meal meal = db.Meals.Find(id);
            db.Meals.Remove(meal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Meals/Plan/true
        /// <summary>
        /// Populates the _meals static field when it is empty or a new plan is requested.
        /// </summary>
        /// <param name="newPlan">Whether or not a new plan is requested by the user.</param>
        public ActionResult Plan(bool? newPlan = null)
        {
            if (!DoWeHaveAtLeast14Meals())
            {
                ShowErrorInView("You need to create at least 14 meals before using the planner.");
            }

            if (_meals.Count == 0)
            {
                PopulateMeals();
            }
            else if (newPlan.HasValue && newPlan.Value == true)
            {
                PopulateMeals();
            }

            return View(_meals);
        }

        // POST: Meals/RemovePlanMeal/5
        /// <summary>
        /// Removes the Meal with the specified ID fromt he _meals static field, and replaces it with a new random Meal.
        /// </summary>
        /// <param name="id">The ID of the Meal object to remove from _meals.</param>
        public ActionResult RemovePlanMeal(int id)
        {
            var allMeals = db.Meals.ToList();
            var availableMeals = allMeals.Where(am => _meals.FirstOrDefault(m => m.ID == am.ID) == null).ToList();
            var selectedMeal = _meals.Find(x => x.ID == id);
            _meals.Remove(selectedMeal);
            Random r = new Random();
            _meals.Add(availableMeals[r.Next(0, availableMeals.Count - 1)]);
            return RedirectToAction("Plan", _meals);
        }

        /// <summary>
        /// Shows the error message on the error view.
        /// </summary>
        /// <param name="errorMessage">The message to show.</param>
        /// <returns></returns>
        public ActionResult Error(string errorMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            return View();
        }

        /// <summary>
        /// Checks the data context to see if we have at least 14 meals, 
        /// which is the minimum amount to create a plan currently.
        /// </summary>
        private bool DoWeHaveAtLeast14Meals()
        {
            var allMeals = db.Meals.ToList();
            if (allMeals.Count < 14)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Re-populates the _meals static field with a new randomized list of 14 Meal objects from the data context.
        /// </summary>
        private void PopulateMeals()
        {
            var allMeals = db.Meals.ToList();
            Random r = new Random();
            _meals = new List<Meal>();

            while (_meals.Count < 14)
            {
                List<Meal> availableMeals = allMeals.Except(_meals).ToList();
                Meal randomMeal = availableMeals[r.Next(0, availableMeals.Count - 1)];
                _meals.Add(randomMeal);
            }
        }

        private ActionResult ShowErrorInView(string message)
        {
            return RedirectToAction("Error", "Meals", new { errorMessage = message });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
