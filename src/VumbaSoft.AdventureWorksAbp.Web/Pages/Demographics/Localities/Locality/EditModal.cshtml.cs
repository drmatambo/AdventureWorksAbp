using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

    private readonly ILocalityAppService _service;

    public EditModalModel(ILocalityAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
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