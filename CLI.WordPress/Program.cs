
using System.Xml.Serialization;
using System;
using lib.wordpress.Models;
using lib.wordpress;
namespace CLI.WordPress
{
	class Program
	{
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to WordPress");
            List<Blog?> Blogposts = BlogServiceProxy.Current.Blogs;
             bool cont = true;

            do
            {
                Console.WriteLine("C. Create a Blogpost");
                Console.WriteLine("L. List All Blogposts");
                Console.WriteLine("E. Edit a Blogpost");
                Console.WriteLine("D. Delete a Blogpost");
                Console.WriteLine("X. Exit");
                var choice1 = Console.ReadLine();

                if (choice1 == "c" || choice1 == "C")
                {
                    var blog = new Blog();
                    blog.Title = Console.ReadLine();
                    blog.Content = Console.ReadLine();
                    BlogServiceProxy.Current.AddOrUpdate(blog);
                }
                else if (choice1 == "l" || choice1 == "L")
                {
                   BlogServiceProxy.Current.Blogs.ForEach(Console.WriteLine);

                }
                else if (choice1 == "e" || choice1 == "E")
                {
                    {
                        Blogposts.ForEach(Console.WriteLine);
                        Console.WriteLine("Enter the ID of the blogpost to update:");
                        var selection = Console.ReadLine();
                        if (int.TryParse(selection ?? "0", out int IntSelection))
                        {
                            var blogToUpdate = Blogposts.Where(b => b != null)
                         .FirstOrDefault(b => (b?.Id ?? -1) == IntSelection);
                            if (blogToUpdate != null)
                            {
                                blogToUpdate.Title = Console.ReadLine();
                                blogToUpdate.Content = Console.ReadLine();
                            }
                            BlogServiceProxy.Current.AddOrUpdate(blogToUpdate);
                        }
                }
                    


                }
                else if (choice1 == "d" || choice1 == "D")
                {
                    {
                        Blogposts.ForEach(Console.WriteLine);
                        Console.WriteLine("Enter the ID of the blogpost to delete:");
                        var selection = Console.ReadLine();
                        if (int.TryParse(selection ?? "0", out int IntSelection))
                        {
                            BlogServiceProxy.Current.Delete(IntSelection);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID. Please try again.");
                        }
                    }

                }
                else if (choice1 == "x" || choice1 == "X")
                {
                    cont = false;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
            while (cont);
		}
	}
}
