
using System.Xml.Serialization;
using System;
using lib.wordpress.Models; 
namespace CLI.WordPress
{
	class Program
	{
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to WordPress");
            List<Blog?> Blogposts = new List<Blog?>();
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
                    Console.WriteLine("Enter the title of the blogpost:");
                    blog.Title = Console.ReadLine();
                    Console.WriteLine("Enter the content of the blogpost:");
                    blog.Content = Console.ReadLine();
                    Blogposts.Add(blog);
                }
                else if (choice1 == "l" || choice1 == "L")
                {
                    foreach (var b in Blogposts)
                    {
                        Console.WriteLine(b);
                    }

                }
                else if (choice1 == "e" || choice1 == "E")
                {

                }
                else if (choice1 == "d" || choice1 == "D")
                {

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
