using CodeFirstEFInAsp.netcoreDemo.Models;

namespace CodeFirstEFInAsp.netcoreDemo.Repositories
{
    public class PostRepository : IPost
    {
        public EventContext context;

        public PostRepository(EventContext cnt)
        {
            this.context = cnt;
        }
        public void DeletePost(int postid)
        {
            Post post = context.posts.Find(postid);
            context.posts.Remove(post);
        }

        public Post GetPostByID(int postid)
        {
            return context.posts.Find(postid);
        }

        public List<Post> GetPosts()
        {
            return context.posts.ToList();
        }

        public void InsertPost(Post post)
        {
            context.posts.Add(post);

        }

        public void save()
        {
            context.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            context.Entry(post).State=
                Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
