using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    //public List<SelectListItem> Provinces { get; set; }
    //public List<SelectListItem> Countries { get; set; }

    private readonly IDistrictCityAppService _service;

    public EditModalModel(IDistrictCityAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
       
        ViewModel = ObjectMapper.Map<DistrictCityDto, EditDistrictCityViewModel>(dto);
        
        //ViewModel.CountryId
        //var provinceLookUp = await _service.GetDistrictCityStateProvinceLookupAsync();
        //Provinces = provinceLookUp.Items
        //    .OrderBy(y => y.Name)
        //    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
        //    .ToList();

        //var countriesLookUp = await _service.GetDistrictCityCountryLookupAsync();
        //Countries = countriesLookUp.Items
        //    .OrderBy(y => y.Name)
        //    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
        //    .ToList();


    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditDistrictCityViewModel, UpdateDistrictCityDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}