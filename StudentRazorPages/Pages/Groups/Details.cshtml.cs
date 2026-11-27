using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentApi.Data.DTOs.Group;
using StudentApi.Data.Services;

namespace StudentRazorPages.Pages.Groups;

public class DetailsModel : PageModel 
{
    private readonly IGroupService _groupService;

    public DetailsModel(IGroupService groupService)
    {
        _groupService = groupService;
    }

    public GroupGetDto Group { get; set; } = new GroupGetDto();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var group = await _groupService.GetByIdAsync(id);
        if (group is null)
        {
            return NotFound();
        }

        Group = group;
        return Page();
    }
}