
using Repository.Models.Data;
using Repository.Models.Json;
using Repository.Services;
using System.Text.Json;

namespace Repository;

public class Program
{
    public static async Task Main()
    {
        var path = @"C:\Users\Diego\source\repos\HarryPotterApi\Repository\Data\characters.json";

        using var file = File.OpenRead(path);
        var charactersFromJson = await JsonSerializer.DeserializeAsync<List<CharacterFromJson>>(file);

        var hairs = charactersFromJson!.Where(e => e.HairColor is not null)
            .Select(e => new Hair { Name = e.HairColor! })
            .ToHashSet();

        foreach (var i in hairs)
        {
            Console.WriteLine(i);
        }

        var eyes = charactersFromJson!.Where(e => e.EyeColor is not null)
            .Select(e => new Eye { Name = e.EyeColor! })
            .ToHashSet();

        foreach (var i in eyes)
        {
            Console.WriteLine(i);
        }

        var species = charactersFromJson!.Where(e => e.Species is not null)
            .Select(e => new Specie { Name = e.Species! })
            .ToHashSet();

        foreach (var i in species)
        {
            Console.WriteLine(i);
        }

        var genders = charactersFromJson!.Where(e => e.Gender is not null)
            .Select(e => new Gender { Name = e.Gender! })
            .ToHashSet();

        foreach (var i in genders)
        {
            Console.WriteLine(i);
        }

        var houses = charactersFromJson!.Where(e => e.House is not null)
            .Select(e => new Gender { Name = e.House! })
            .ToHashSet();

        foreach (var i in houses)
        {
            Console.WriteLine(i);
        }


        //    var characters = from character in charactersFromJson
        //                     let hair = hairs.FirstOrDefault(e => e.Name == character.HairColor)
        //                     select new Character
        //                     {
        //                         Name = character.Name,
        //                         Hair = hair
        //                     };
        //    foreach(var c in charactersFromJson)
        //    {
        //        await ImageDownloaderService.Download(c.ImageUrl);
        //    }
        //    foreach (var c in characters)
        //    {
        //        Console.WriteLine($"{c.Name} => {c.Hair}");
        //    }
    }
}