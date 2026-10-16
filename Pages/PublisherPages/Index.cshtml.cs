using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ungur_Alina_Lab2.Models;

namespace Ungur_Alina_Lab2.Pages.PublisherPages;

public class IndexModel : PageModel
{
    private readonly Ungur_Alina_Lab2Context _context;

    public IndexModel(Ungur_Alina_Lab2Context context)
    {
        _context = context;
    }

    public IList<Publisher> Publisher { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Publisher = await _context.Publisher.ToListAsync();
    }
}
