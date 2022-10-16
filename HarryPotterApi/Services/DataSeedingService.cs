using HarryPotterApi.Data.Connections;
using HarryPotterApi.Models.Data;
using HarryPotterApi.Models.Json;
using Microsoft.EntityFrameworkCore;

namespace HarryPotterApi.Services;

public class DataSeedingService : IDisposable
{
    private readonly HarryPotterApiDbContext _context;
    private readonly HashSet<Species> _species;
    private readonly HashSet<Gender> _genders;
    private readonly HashSet<House> _houses;
    private readonly HashSet<Character> _characters;

    private readonly Uri _imagesBaseUrl;
    private readonly Uri _dataSourceUrl;
    private readonly IList<CharacterFromJson> _charactersFromJson;

    public DataSeedingService(
        HarryPotterApiDbContext context,
        Uri imageBaseUrl,
        Uri dataSourceUrl
        )
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));

        _species = new HashSet<Species>();
        _genders = new HashSet<Gender>();
        _houses = new HashSet<House>();
        _characters = new HashSet<Character>();

        _imagesBaseUrl = imageBaseUrl ?? throw new ArgumentNullException(nameof(imageBaseUrl));
        _dataSourceUrl = dataSourceUrl ?? throw new ArgumentNullException(nameof(dataSourceUrl));
        _charactersFromJson = new List<CharacterFromJson>();
    }

    public async Task Run()
    {
        var isEmpty = await IsEmpty();
        if (!isEmpty) return;

        await LoadDataSource();

        _species.UnionWith(GetSpecies(_charactersFromJson));
        await _context.Species.AddRangeAsync(_species);

        _genders.UnionWith(GetGenders(_charactersFromJson));
        await _context.Genders.AddRangeAsync(_genders);

        _houses.UnionWith(GetHouses(_charactersFromJson));
        await _context.Houses.AddRangeAsync(_houses);

        _characters.UnionWith(GetCharacters(_charactersFromJson, _imagesBaseUrl.ToString()));
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
    private IEnumerable<Character> GetCharacters(IEnumerable<CharacterFromJson> dataSource, string imagesBaseUrl)
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
            Wand = json.Wand is null
                ? null
                : new Wand
                {
                    Wood = json.Wand!.Wood,
                    Core = json.Wand!.Core,
                    Length = json.Wand!.Length
                },
            Patronus = json.Patronus ?? null,
            IsHogwartsStudent = json.IsHogwartsStudent ?? false,
            IsHogwartsStaff = json.IsHogwartsStaff ?? false,
            Actor = json.Actor ?? "Unknown",
            IsAlive = json.IsAlive ?? false,
            ImageUrl = json.ImageUrl is null
                ? null
                : imagesBaseUrl + json.GetFilenameFromImageUrl()!
        }).ToList();
    }

    private async Task<bool> IsEmpty()
    {
        var hasCharacters = await _context.Characters.AnyAsync();
        return !hasCharacters;
    }

    private async Task LoadDataSource()
    {
        using var cliente = new HttpClient();
        var response = await cliente.GetFromJsonAsync<List<CharacterFromJson>>(_dataSourceUrl);
        foreach (var _ in response!)
        {
            _charactersFromJson.Add(_);
        }
    }

    public void Dispose()
    {
        
    }
}