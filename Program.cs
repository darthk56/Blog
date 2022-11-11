using System;
using EFTutorial.Models;
using System.Linq;

namespace EFTutorial
{
    class Program
    {
        static void Main(string[] args)
        {

            int choice;
            do
            {
                Console.WriteLine("Select an option");

                Console.WriteLine("1. Display all blogs");
                Console.WriteLine("2. Add blog");
                Console.WriteLine("3. Create post");
                Console.WriteLine("4. Display posts");
                choice = Convert.ToInt16(Console.ReadLine());

                if (choice == 1)
                {
                    using (var db = new BlogContext())
                    {
                        int count = 0;
                        System.Console.WriteLine("Here is the list of blogs");
                        foreach (var b in db.Blogs)
                        {
                            System.Console.WriteLine($"Blog: {b.BlogId}: {b.Name}");
                            count++;
                        }
                        Console.WriteLine(count + " blogs displayed");
                    }

                }
                if (choice == 2)
                {
                    System.Console.WriteLine("Enter your Blog name");
                    var blogName = Console.ReadLine();
                    if(blogName != null)
                    {
                        var blog = new Blog();
                        blog.Name = blogName;

                        // // Save blog object to database
                        using (var db = new BlogContext())
                        {
                            db.Add(blog);
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        Console.WriteLine("name cannot be null");
                    }
                    // // Create new Blog
                    
                }
                if(choice == 3)
                {
                    System.Console.WriteLine("Enter Blog ID to post to");
                    var blogID = Console.ReadLine();
                    if(int.TryParse(blogID, out int blogIDNUM) == false)
                    {
                        Console.WriteLine("ID must be integer");
                    }
                    else
                    {
                        System.Console.WriteLine("Enter your Post title");
                        var postTitle = Console.ReadLine();
                        if (postTitle != null)
                        {
                            var post = new Post();
                            post.Title = postTitle;
                            post.BlogId = blogIDNUM;

                            using (var db = new BlogContext())
                        {
                            db.Posts.Add(post);
                            db.SaveChanges();
                        }
                        }
                        else
                        {
                            Console.WriteLine("Title must not be null");
                        }
                        
                    }
                   

                }
                if(choice == 4)
                {
                    Console.WriteLine("Which blogs posts would you like to view? (ID)");
                    var option = Convert.ToInt16(Console.ReadLine());
                    using (var db = new BlogContext())
                    {
                        var blogA = db.Blogs.Where(x => x.BlogId == option).FirstOrDefault();
                        //var blogsList = blog.ToList(); // convert to List from IQueryable

                        System.Console.WriteLine($"Posts for Blog {blogA.Name}");

                        foreach (var postA in blogA.Posts)
                        {
                            System.Console.WriteLine($"\tPost {postA.PostId} {postA.Title}");
                        }
                    }
                }









            } while (choice != 5);
            // 1. List Posts for Blog #1
            
            // 2. Add Post to database
            
            // 3. Read Blogs from database
             

            // 4. Add Blog to Database
            

        }
    }
}
