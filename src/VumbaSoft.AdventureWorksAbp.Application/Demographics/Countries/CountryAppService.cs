using System;
using System.Linq;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Permissions;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries.Dtos;
using Volo.Abp.Application.Services;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Countries;


public class CountryAppService : CrudAppService<Country, CountryDto, Guid, CountryGetListInput, CreateCountryDto, UpdateCountryDto>,
    ICountryAppService
{
    protected override string GetPolicyName { get; set; } = AdventureWorksAbpPermissions.Country.Default;
    protected override string GetListPolicyName { get; set; } = AdventureWorksAbpPermissions.Country.Default;
    protected override string CreatePolicyName { get; set; } = AdventureWorksAbpPermissions.Country.Create;
    protected override string UpdatePolicyName { get; set; } = AdventureWorksAbpPermissions.Country.Update;
    protected override string DeletePolicyName { get; set; } = AdventureWorksAbpPermissions.Country.Delete;

    private readonly ICountryRepository _repository;

    public CountryAppService(ICountryRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<Country>> CreateFilteredQueryAsync(CountryGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(input.ContinentId != null, x => x.ContinentId == input.ContinentId)
            .WhereIf(input.SubcontinentId != null, x => x.SubcontinentId == input.SubcontinentId)
            .WhereIf(input.Name != null, x => x.Name.Contains(input.Name))
            .WhereIf(input.FormalName != null, x => x.FormalName == input.FormalName)
            .WhereIf(input.NativeName != null, x => x.NativeName == input.NativeName)
            .WhereIf(input.IsoTreeCode != null, x => x.IsoTreeCode == input.IsoTreeCode)
            .WhereIf(input.IsoTwoCode != null, x => x.IsoTwoCode == input.IsoTwoCode)
            .WhereIf(input.CcnTreeCode != null, x => x.CcnTreeCode == input.CcnTreeCode)
            .WhereIf(input.PhoneCode != null, x => x.PhoneCode == input.PhoneCode)
            .WhereIf(input.Capital != null, x => x.Capital == input.Capital)
            .WhereIf(input.Currency != null, x => x.Currency == input.Currency)
            .WhereIf(input.Population != null, x => x.Population == input.Population)
            .WhereIf(input.Emoji != null, x => x.Emoji == input.Emoji)
            .WhereIf(input.EmojiU != null, x => x.EmojiU == input.EmojiU)
            .WhereIf(input.Remarks != null, x => x.Remarks == input.Remarks)
            ;
    }
}
