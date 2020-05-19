using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Superhero.Data;
using Superhero.Models;

namespace Superhero.Controllers
{
    public class HeroController : Controller
    {
        private ApplicationDbContext context;

        public HeroController(ApplicationDbContext _context)
        {
            context = _context;
        }
            
        // GET: Hero
        public ActionResult Index()
        {
            var heroes = context.SuperHeroes.ToList();
            return View(heroes);
        }

        // GET: Hero/Details/5
        public ActionResult Details(int id)
        {
            Hero hero = context.SuperHeroes.Find(id);
            return View(hero);
        }

        // GET: Hero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ID, Name, AlterEgo, PrimatyAbility, SecondaryAbility, Catchphrase")] Hero hero)
        {
            try
            {
                // TODO: Add insert logic here
                context.SuperHeroes.Add(hero);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(hero);
            }
        }

        // GET: Hero/Edit/5
        public ActionResult Edit(int id)
        {
            var heroesInDB = context.SuperHeroes.Where(h => h.ID == id).FirstOrDefault();
            return View(heroesInDB);
        }
        //context is the database
        //superheroes is the table with the data
        //Where is us locating a specific record in the superheroes table
        //FirstOrDefault is selecting the first superher record in the superherores table that has the matching id

      

        // POST: Hero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("ID, Name, AlterEgo, PrimatyAbility, SecondaryAbility, Catchphrase")] Hero hero)
    {
            try
            {
                // TODO: Add update logic here
                context.Entry(hero).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Hero/Delete/5
        public ActionResult Delete(int id)
        {
            Hero hero = context.SuperHeroes.Find(id);
            return View(hero);
        }

        // POST: Hero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Hero hero)
        {
            try
            {
                // TODO: Add delete logic here
                hero = context.SuperHeroes.Find(id);
                context.SuperHeroes.Remove(hero);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}