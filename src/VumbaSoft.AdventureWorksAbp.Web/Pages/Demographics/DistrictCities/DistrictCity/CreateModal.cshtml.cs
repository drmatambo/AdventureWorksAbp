using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities;
using VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.DistrictCities.DistrictCity.ViewModels;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.DistrictCities.DistrictCity;

public class CreateModalModel : AdventureWorksAbpPageModel
{
    [BindProperty]
    public CreateDistrictCityViewModel ViewModel { get; set; }

    private readonly IDistrictCityAppService _service;

    public CreateModalModel(IDistrictCityAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateDistrictCityViewModel, CreateDistrictCityDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}