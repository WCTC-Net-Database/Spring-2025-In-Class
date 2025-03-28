namespace W9_EFCore.Models;

public class Post
{
    public int PostId { get;set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime? PostDate { get; set; }

    // navigation property
    public Blog Blog { get; set; }
    public int BlogId { get; set; }
}
