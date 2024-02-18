using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;
using VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Subcontinents.Subcontinent.ViewModels;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Subcontinents.Subcontinent;

public class EditModalModel : AdventureWorksAbpPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditSubcontinentViewModel ViewModel { get; set; }

    //public List<SelectListItem> Continents { get; set; } = new List<SelectListItem>();

    private readonly ISubcontinentAppService _service;

    public EditModalModel(ISubcontinentAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<SubcontinentDto, EditSubcontinentViewModel>(dto);

        //var continentLookup = await _service.GetContinentLookupAsync();

        //Continents = continentLookup.Items
        //    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
        //    .ToList();
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditSubcontinentViewModel, UpdateSubcontinentDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}