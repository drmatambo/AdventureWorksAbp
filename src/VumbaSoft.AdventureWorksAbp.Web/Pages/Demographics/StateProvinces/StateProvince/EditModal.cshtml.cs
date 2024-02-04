using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;
using VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.StateProvinces.StateProvince.ViewModels;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.StateProvinces.StateProvince;

public class EditModalModel : AdventureWorksAbpPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditStateProvinceViewModel ViewModel { get; set; }

    private readonly IStateProvinceAppService _service;

    public EditModalModel(IStateProvinceAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<StateProvinceDto, EditStateProvinceViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditStateProvinceViewModel, UpdateStateProvinceDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}