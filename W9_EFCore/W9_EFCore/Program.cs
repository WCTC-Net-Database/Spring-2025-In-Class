using W9_EFCore.Data;
using W9_EFCore.Models;

namespace W9_EFCore;

public class Program
{
    public static void Main()
    {
        // 'using' will automatically dispose of the resources when exiting scope
        using var db = new BloggingContext();

        // CRUD operations
        // Create - INSERT
        //var blog = new Blog { Name = "My Blog", Url = "http://myblog.com" };
        //db.Blogs.Add(blog);
        //db.SaveChanges();

        // Read - SELECT
        Console.WriteLine("Your blogs are:");
        var blogs = db.Blogs;
        foreach (var b in blogs)
        {
            Console.WriteLine($"- {b.BlogId}: {b.Name} ({b.Url})");
        }

        //// Update - UPDATE THE BLOG (not the post)
        //Console.WriteLine("Hey user - enter the blog index to update");
        //var blogToUpdate = Console.ReadLine();

        //var post = new Post { Title = "My First Post", Content = "Hello World!" };
        //post.BlogId = Convert.ToInt32(blogToUpdate);

        //db.Posts.Add(post);
        //db.SaveChanges();

        // ** CRITICAL ** You MUST have a reference to the post you want to update
        // Update - UPDATE THE POST
        Console.WriteLine("Provide a substring of the title you would like update");
        var titleToUpdate = Console.ReadLine();
        var postToUpdate = db.Posts.FirstOrDefault(p => p.Title == "My First Post");
        postToUpdate.Content = "Hello World! Updated";
        db.SaveChanges();

        // ** CRITICAL ** You MUST have a reference to the post you want to delete
        // Delete - DELETE
        Console.WriteLine("Your posts are:");
        var posts = db.Posts;
        foreach (var p in posts)
        {
            Console.WriteLine($"- {p.PostId}: {p.Title} ({p.Content})");
        }

        Console.WriteLine("Hey user - enter the post index to delete");
        var postIndex = Convert.ToInt32(Console.ReadLine());
        // get the post reference
        var postToDelete = db.Posts.FirstOrDefault(p => p.PostId == postIndex);
        db.Remove(postToDelete);

        // kind of unnecessary with the 'using' statement but here for completeness
        db.Dispose();
    }
}