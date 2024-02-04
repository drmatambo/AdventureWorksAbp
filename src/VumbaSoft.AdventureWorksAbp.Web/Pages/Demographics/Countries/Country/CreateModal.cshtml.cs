using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Countries.Country.ViewModels;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Countries.Country;

public class CreateModalModel : AdventureWorksAbpPageModel
{
    [BindProperty]
    public CreateCountryViewModel ViewModel { get; set; }

    private readonly ICountryAppService _service;

    public CreateModalModel(ICountryAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateCountryViewModel, CreateCountryDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}