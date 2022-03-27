using Microsoft.AspNetCore.Mvc;
using MVCh.Data;
using MVCh.Models;
using MVCh.ViewModels;

namespace MVCh.Controllers
{
    public class ThreadsController : Controller
    {
        private readonly ChanDbContext _context;
        public ThreadsController(ChanDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(int? boardId)
        {
            IEnumerable<Models.Thread> threads = _context.Threads.Where(t => t.BoardId == boardId);
            ViewData["bid"] = boardId;
            return View(threads);
        }

        [HttpGet]
        public IActionResult Create(int? boardId)
        {
            ViewData["bid"] = boardId;
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ThreadViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obj.NewThread);
                _context.SaveChanges();
                TempData["success"] = "Тред создан!";
                return RedirectToAction("Index", "Threads", new { boardId = obj.RefBoardId });
            }
            return View(obj);
        }

        public IActionResult OpenThread(int id)
        {
            return RedirectToAction("Index", "Posts", new { threadId = id });
        }
    }
}
