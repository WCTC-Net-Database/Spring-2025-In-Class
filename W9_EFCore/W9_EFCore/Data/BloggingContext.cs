using Microsoft.EntityFrameworkCore;
using W9_EFCore.Models;

namespace W9_EFCore.Data;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=StartingEFCore;Trusted_Connection=True;");

        // Used for production    
        // Data Source=bitsql.wctc.edu;Database=mmcarthey_20023_BlogSample;User ID=mmcarthey;Password=***********;

        // Used for local development
        // Server=(localdb)\\MSSQLLocalDB;Database=StartingEFCore;Trusted_Connection=True;
    }
}
