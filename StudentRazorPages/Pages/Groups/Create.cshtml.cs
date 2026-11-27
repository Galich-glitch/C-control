using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentApi.Data.DTOs.Group;
using StudentApi.Data.Services;

namespace StudentRazorPages.Pages.Groups;

public class CreateModel : PageModel
{
    private readonly IGroupService _groupService;

    public CreateModel(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [BindProperty]
    public GroupCreateDto Input { get; set; } = new();

    public void OnGet()
    {

    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page(); 
        }

        await _groupService.CreateAsync(Input);

        return RedirectToPage("./Index");
    }
}