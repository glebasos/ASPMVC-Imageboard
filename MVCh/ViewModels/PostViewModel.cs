using MVCh.Models;

namespace MVCh.ViewModels
{
    public class PostViewModel
    {
        //все посты, т.к. гет и пост на одной странице
        public IEnumerable<Post>? AllPosts { get; set; }

        //newpost для [POST] экшна
        public Post? NewPost { get; set; }

        //передаем тредИД чтобы не потерять контекст треда
        public int? ThreadId { get; set; }
        public string? ThreadName { get; set; }

        //Картинки для поста
        public IFormFileCollection? UploadedImages { get; set; }
    }
}
