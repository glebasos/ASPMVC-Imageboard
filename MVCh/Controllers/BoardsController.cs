using Microsoft.AspNetCore.Mvc;
using MVCh.Data;
using MVCh.Models;

namespace MVCh.Controllers
{
    public class BoardsController : Controller
    {
        private readonly ChanDbContext _context;

        public BoardsController(ChanDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Board> boards = _context.Boards.OrderBy(b => b.Name);
            return View(boards);
        }

        public IActionResult OpenBoard(int id)
        {
            return RedirectToAction("Index", "Threads", new {boardId = id});
        }
        //public IActionResult GetThreads(int? id)
        //{
        //    var threads = _context.Threads.Where(t => t.BoardId == id);
        //    return View(threads);
        //}
        //public IActionResult CreateThread()
        //{
        //    var threads = _context.Threads.Where(t => t.BoardId == id);
        //    return View(threads);
        //}
    }
}
