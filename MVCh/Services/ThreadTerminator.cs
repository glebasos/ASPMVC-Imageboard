using Microsoft.EntityFrameworkCore;
using MVCh.Data;

namespace MVCh.Services
{
    public class ThreadTerminator : ITerminator
    {
        public async Task DeleteThreadCascadeAsync(int threadId, ChanDbContext context)
        {
            //var stuffToDelete = context.Threads.Where(t => t.Id == threadId).Include(t => t.Posts).ThenInclude(p => p.PostImages);
            //path to all images
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
            var imagesToDelete = from i in context.Images
                                 join p in context.Posts on i.PostId equals p.Id
                                 where p.ThreadId == threadId
                                 select new {imgName = i.ImageName};
            //delete all the files
            foreach(var image in imagesToDelete)
            {
                try
                {
                    // Check if file exists with its full path    
                    if (File.Exists(Path.Combine(path, image.imgName)))
                    {
                        // If file found, delete it    
                        File.Delete(Path.Combine(path, image.imgName));
                        Console.WriteLine("File deleted.");
                    }
                    else Console.WriteLine("File not found");
                }
                catch (IOException ioExp)
                {
                    Console.WriteLine(ioExp.Message);
                }
            }
            Models.Thread threadToDelete = await context.Threads.FirstAsync(t => t.Id == threadId);
            context.Remove(threadToDelete);
            await context.SaveChangesAsync();
        }
    }
}
