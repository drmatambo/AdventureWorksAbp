using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VumbaSoft.AdventureWorksAbp.Demographics.Localities;
using VumbaSoft.AdventureWorksAbp.Demographics.Localities.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Localities.Locality.ViewModels;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Localities.Locality;

public class EditModalModel : AdventureWorksAbpPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditLocalityViewModel ViewModel { get; set; }
    public List<SelectListItem> Continents { get; set; }
    public List<SelectListItem> SubContinents { get; set; }
    public List<SelectListItem> Countries { get; set; }
    public List<SelectListItem> Regions { get; set; }
    public List<SelectListItem> StateProvinces { get; set; }
    public List<SelectListItem> DistrictCities { get; set; }

    private readonly ILocalityAppService _service;

    public EditModalModel(ILocalityAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        //var continentLookUp = await _service.GetLocalityContinenteLookUpAsync();
        //Continents = continentLookUp.Items
        //    .OrderBy(y => y.Name)
        //    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
        //    .ToList();

        //var subcontinentLookUp = await _service.GetLocalitySubContinenteLookUpAsync();
        //SubContinents = subcontinentLookUp.Items
        //    .OrderBy(y => y.Name)
        //    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
        //    .ToList();

        //var countryLookUp = await _service.GetLocalityCountryLookUpAsync();
        //Countries = countryLookUp.Items
        //    .OrderBy(y => y.Name)
        //    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
        //    .ToList();

        //var regionsLookUp = await _service.GetLocalityRegionLookUpAsync();
        //Regions = regionsLookUp.Items
        //    .OrderBy(y => y.Name)
        //    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
        //    .ToList();

        //var stateProvinceLookUp = await _service.GetLocalityStateProvinceLookUpAsync();
        //StateProvinces = stateProvinceLookUp.Items
        //    .OrderBy(y => y.Name)
        //    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
        //    .ToList();

        //var districtCityLookUp = await _service.GetLocalityDistrictCityLookUpAsync();
        //DistrictCities = districtCityLookUp.Items
        //    .OrderBy(y => y.Name)
        //    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
        //    .ToList();

        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<LocalityDto, EditLocalityViewModel>(dto);

    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditLocalityViewModel, UpdateLocalityDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}