using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentApi.Data.DTOs.Group;
using StudentApi.Data.Services;

namespace StudentRazorPages.Pages;

public class GroupsModel : PageModel
{
    private readonly IGroupService _groupService;

    public GroupsModel(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [BindProperty(SupportsGet = true)]
    public string? SearchTerm { get; set; }

    public int TotalCount { get; private set; }
    public List<GroupGetDto> Groups { get; private set; } = new();

    public async Task OnGetAsync()
    {
        Groups = (await _groupService.GetAllAsync(SearchTerm)).ToList();
        TotalCount = Groups.Count;
    }
    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        await _groupService.DeleteAsync(id);
        return RedirectToPage();
    }
}