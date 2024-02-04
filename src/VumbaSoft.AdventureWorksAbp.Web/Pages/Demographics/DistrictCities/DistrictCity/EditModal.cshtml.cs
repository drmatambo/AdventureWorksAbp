using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities;
using VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.DistrictCities.DistrictCity.ViewModels;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.DistrictCities.DistrictCity;

public class EditModalModel : AdventureWorksAbpPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditDistrictCityViewModel ViewModel { get; set; }

    private readonly IDistrictCityAppService _service;

    public EditModalModel(IDistrictCityAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<DistrictCityDto, EditDistrictCityViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditDistrictCityViewModel, UpdateDistrictCityDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}