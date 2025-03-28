using System.Collections;

namespace W9_EFCore.Models;

public class Blog
{
    public int BlogId { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }

    // navigation property
    public List<Post> Posts { get; set; } = new List<Post>();
}
