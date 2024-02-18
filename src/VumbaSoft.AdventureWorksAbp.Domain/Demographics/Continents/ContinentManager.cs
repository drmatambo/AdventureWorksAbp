using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Continents;

public class ContinentManager : DomainService
{
    private readonly IContinentRepository _continentRepository;

    public ContinentManager(IContinentRepository continentRepository)
    {
        _continentRepository = continentRepository;
    }

    public async Task<Continent> CreateAsync(
    string name,
    Int64 population,
    String remarks)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));

        var existingcontinent = await _continentRepository.FindByNameAsync(name);
        if (existingcontinent != null)
        {
            throw new ContinentAlreadyExistsException(name);
        }

        return new Continent(
            GuidGenerator.Create(),
            name,
            population,
            remarks
        );
    }

    public async Task ChangeNameAsync(
        Continent continent,
        string newName)
    {
        Check.NotNull(continent, nameof(continent));
        Check.NotNullOrWhiteSpace(newName, nameof(newName));

        var existingcontinent = await _continentRepository.FindByNameAsync(newName);
        if (existingcontinent != null && existingcontinent.Id != continent.Id)
        {
            throw new ContinentAlreadyExistsException(newName);
        }

        continent.ChangeName(newName);
    }
}
