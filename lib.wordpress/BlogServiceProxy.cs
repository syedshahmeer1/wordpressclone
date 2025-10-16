using System;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using lib.wordpress.Models;

namespace lib.wordpress
{
    public class BlogServiceProxy
    {
        private List<Blog?> blogposts;
        private static BlogServiceProxy? instance;
        private static object Instancelock = new object();

        private BlogServiceProxy()
        {
            blogposts = new List<Blog?>();
        }

        public static BlogServiceProxy Current
        {
            get
            {
                lock (Instancelock  )
                {
                    if (instance == null)
                    {
                        instance = new BlogServiceProxy();
                    }
                }
                return instance;
            }
        }

        public List<Blog?> Blogs => blogposts;

        public Blog? AddOrUpdate(Blog? blog)
        {
            if (blog == null) return null;
            if (blog.Id <= 0)
            {
                var maxId = -1;
                if (blogposts.Any())
                {
                    maxId = blogposts.Select(b => b?.Id ?? -1).Max();
                }
                else
                {
                    maxId = 0;
                }
                blog.Id = ++maxId;
                blogposts.Add(blog);
            }

            return blog;
        }

        public Blog? Delete(int id)
        {
            var blogToDelete = blogposts
                .Where(b => b != null)
                .FirstOrDefault(b => (b?.Id ?? -1) == id);

            if (blogToDelete != null)
                blogposts.Remove(blogToDelete);

            return blogToDelete;
        }
    }
}