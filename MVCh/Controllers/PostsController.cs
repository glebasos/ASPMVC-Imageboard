using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCh.Data;
using MVCh.Models;
using MVCh.Services;
using MVCh.ViewModels;

namespace MVCh.Controllers
{
    public class PostsController : Controller
    {
        private readonly ChanDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ITerminator _terminator;
        public PostsController(ChanDbContext context, IWebHostEnvironment hostEnvironment, ITerminator terminator)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _terminator = terminator;
        }

        //GET
        [HttpGet]
        public IActionResult Index(int? threadId)
        {
            IEnumerable<Post> posts = _context.Posts.Where(p => p.ThreadId == threadId).OrderBy(p => p.Id).Include(p => p.PostImages);
            if (_context.Threads.FirstOrDefault(t => t.Id == threadId) is null)
                return RedirectToAction("Index", "Boards");
            string? threadName = _context.Threads.FirstOrDefault(t => t.Id == threadId).Name;
            PostViewModel viewModel = new()
            {
                AllPosts = posts,
                ThreadId = threadId,
                ThreadName = threadName,
            };
            return View(viewModel);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(PostViewModel obj)
        {
            //сохранить пикчи на диск
            if (_context.Threads.Select(t => t.Id == obj.ThreadId) is null)
                return RedirectToAction("Index", "Boards");

            if (ModelState.IsValid)
            {
                if(obj.NewPost is not null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    if (obj.UploadedImages is not null)
                    {
                        List<Image> _uploadedImages = new();
                        foreach (var file in obj.UploadedImages)
                        {
                            var image = new Image();
                            string filename = System.Guid.NewGuid().ToString() + file.FileName;
                            string fileNameWithPath = Path.Combine(path, filename);
                            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }
                            //Создать Images, где будут ссылки до файлов
                            image.ImageName = filename;
                            //Put Images to List<Images>
                            _uploadedImages.Add(image);
                        }
                        obj.NewPost.PostImages = _uploadedImages;
                    }
                    //if (obj.NewPost.TextContent is not null)
                    //    obj.NewPost.TextContent = obj.NewPost.TextContent.Replace("\n", "<br/>");
                    _context.Add(obj.NewPost);
                    _context.SaveChanges();
                    TempData["success"] = "Псто отправлен!";

                    //should I delete thread
                    int numPosts = _context.Posts.Where(p => p.ThreadId == obj.ThreadId).Count();
                    if(numPosts > 10)
                    {
                        if (obj.ThreadId is not null)
                            await _terminator.DeleteThreadCascadeAsync((int)obj.ThreadId, _context);
                        return RedirectToAction("Index", "Boards");
                    }
                    return RedirectToAction("Index", "Posts", new { threadId = obj.ThreadId });
                }
            }
            return RedirectToAction("Index", "Posts", new { threadId = obj.ThreadId });
        }


        
    }
}
