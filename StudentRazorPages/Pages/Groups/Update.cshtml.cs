using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentApi.Data.DTOs.Group;
using StudentApi.Data.Services;

namespace StudentRazorPages.Pages.Groups;

public class UpdateModel : PageModel
{
    private readonly IGroupService _groupService;

    public UpdateModel(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [BindProperty]
    public GroupUpdateDto Input { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var group = await _groupService.GetByIdAsync(id);
        if (group is null)
            return NotFound();

        Input = new GroupUpdateDto
        {
            Name = group.Name
        };

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var success = await _groupService.UpdateAsync(id, Input);

        if (!success)
        {
            return NotFound(); 
        }

        return RedirectToPage("./Index");
    }
}