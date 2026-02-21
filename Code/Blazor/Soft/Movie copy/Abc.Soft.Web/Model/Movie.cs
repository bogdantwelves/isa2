using System;

namespace Abc.Soft.Web.Model;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }
}