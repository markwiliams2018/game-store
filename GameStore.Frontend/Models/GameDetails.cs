using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Frontend.Models;

public class GameDetails
{
    [My]
    public int Id { get; set; }

    [RequiredAttribute]
    [StringLength(50)]
    public required string Name { get; set; }

    [Required(ErrorMessage = "The Genre field is required.")]
    public string? GenreId { get; set; }

    [Range(1, 100)]
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}

[AttributeUsage(AttributeTargets.Property)]
public class MyAttribute : Attribute
{
    
}

//public class TestRun
//{
//    public void Run()
//    {
//        var newGameDetails = new GameDetails { Name = "Super Mario" };
//        Type type = typeof(GameDetails);
//        Activator.CreateInstance<T>();
//    }
//}