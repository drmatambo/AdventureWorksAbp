using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Countries.Country.ViewModels;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Countries.Country;

public class EditModalModel : AdventureWorksAbpPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditCountryViewModel ViewModel { get; set; }

    private readonly ICountryAppService _service;

    public EditModalModel(ICountryAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<CountryDto, EditCountryViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditCountryViewModel, UpdateCountryDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}