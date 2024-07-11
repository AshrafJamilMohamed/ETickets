using ETickets.Data;
using ETickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;
        public MoviesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _context.Movies.Include(n=>n.Cinema).ToListAsync();
            return View(allMovies);
        }


        //GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            Movie movie = _context.Movies.Where(x => x.Id == id).FirstOrDefault();
            return View(movie);
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Movie movie)
        {
            try
            {
                _context.Entry(movie).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //// GET: ActorController/Delete/5
        public ActionResult Delete(int id)
        {
            Movie movie = _context.Movies.Where(x => x.Id == id).FirstOrDefault();

            return View(movie);
        }

        // POST: ActorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Movie movie)
        {
            try
            {
                _context.Entry(movie).State = EntityState.Deleted;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            Movie movie = _context.Movies.Where(x => x.Id == id).FirstOrDefault();
            return View(movie);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            try
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Displaydata()
        {
            var data = _context.Movies.ToList();
            return View(data);
        }




    }
}
