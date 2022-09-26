using System.Text.Json;
using Api.Data.Connections;
using Api.Models.Data;
using Api.Models.Json;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;

public class DataSeedingService
{
    private readonly HarryPotterApiDbContext _context;
    private readonly HashSet<Species> _species;
    private readonly HashSet<Gender> _genders;
    private readonly HashSet<House> _houses;
    private readonly HashSet<Character> _characters;

    public DataSeedingService(HarryPotterApiDbContext context)
    {
        _context = context;
        _species = new();
        _genders = new();
        _houses = new();
        _characters = new();
    }
    public async Task Run()
    {
        var isEmpty = await IsEmpty();
        if (!isEmpty) return;
        
        // TODO Implements external data source
        var path = @"C:\Users\Diego\source\repos\HarryPotterApi\HarryPotterApi\Data\characters.json";

        await using var file = File.OpenRead(path);
        var charactersFromJson = await JsonSerializer.DeserializeAsync<List<CharacterFromJson>>(file);

        _species.UnionWith(GetSpecies(charactersFromJson!));
        await _context.Species.AddRangeAsync(_species);

        _genders.UnionWith(GetGenders(charactersFromJson!));
        await _context.Genders.AddRangeAsync(_genders);

        _houses.UnionWith(GetHouses(charactersFromJson!));
        await _context.Houses.AddRangeAsync(_houses);
        
        _characters.UnionWith(GetCharacters(charactersFromJson!));
        await _context.Characters.AddRangeAsync(_characters);

        await _context.SaveChangesAsync();
    }

    private IEnumerable<Species> GetSpecies(IEnumerable<CharacterFromJson> dataSource)
    {
        return dataSource
            .Where(e => e.Species is not null)
            .Select(e => new Species { Name = e.Species! })
            .ToHashSet();
    }

    private IEnumerable<Gender> GetGenders(IEnumerable<CharacterFromJson> dataSource)
    {
        return dataSource
            .Where(e => e.Gender is not null)
            .Select(e => new Gender { Name = e.Gender! })
            .ToHashSet();
    }

    private IEnumerable<House> GetHouses(IEnumerable<CharacterFromJson> dataSource)
    {
        return dataSource
            .Where(e => e.House is not null)
            .Select(e => new House { Name = e.House! })
            .ToHashSet();
    }
    private IEnumerable<Character> GetCharacters(IEnumerable<CharacterFromJson> dataSource)
    {
        return dataSource.Select(json => new Character
        {
            Name = json.Name!,
            Species = _species.FirstOrDefault(i => i.Name == json.Species),
            Gender = _genders.FirstOrDefault(i => i.Name == json.Gender),
            House = _houses.FirstOrDefault(i => i.Name == json.House),
            BirthDate = json.BirthDate ?? null,
            IsWizard = json.IsWizard ?? false,
            Ancestry = json.Ancestry,
            Eye = json.EyeColor,
            Hair = json.HairColor,
            Wand = new Wand { Wood = json.Wand?.Wood, Core = json.Wand?.Core, Length = json.Wand?.Length},
            Patronus = json.Patronus ?? null,
            IsHogwartsStudent = json.IsHogwartsStudent ?? false,
            IsHogwartsStaff = json.IsHogwartsStaff ?? false,
            Actor = json.Actor ?? "Unknown",
            IsAlive = json.IsAlive ?? false,
            ImageUrl = null // TODO
        }).ToList();
    }

    private async Task<bool> IsEmpty()
    {
        var hasCharacters = await _context.Characters.AnyAsync();
        var hasWands = await _context.Wands.AnyAsync();
        var hasHouses = await _context.Houses.AnyAsync();

        return !(hasCharacters || hasHouses || hasWands);
    }
}