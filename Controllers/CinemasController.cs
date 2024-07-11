using ETickets.Data;
using ETickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDbContext _context;
        public CinemasController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _context.Cinemas.ToListAsync();
            return View(allCinemas);
        }

        // GET: CinemasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cinema cinema)
        {
            try
            {
                _context.Cinemas.Add(cinema);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //GET: CinemaController/Edit/5
        public ActionResult Edit(int id)
        {
            Cinema cinema= _context.Cinemas.Where(x => x.Id == id).FirstOrDefault();
            return View(cinema);
        }

        // POST: ActorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cinema cinema)
        {
            try
            {
                _context.Entry(cinema).State = EntityState.Modified;
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
            Cinema cinema = _context.Cinemas.Where(x => x.Id == id).FirstOrDefault();

            return View(cinema);
        }

        // POST: CinemaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Cinema cinema)
        {
            try
            {
                _context.Entry(cinema).State = EntityState.Deleted;
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
             Cinema cinema=_context.Cinemas.Where(x=>x.Id == id).FirstOrDefault();
            return View(cinema);
        }


    }
}
