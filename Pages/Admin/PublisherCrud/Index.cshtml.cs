using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EfCoreRazorCrud.Data;
using EfCoreRazorCrud.Models;

namespace EfCoreRazorCrud.Admin.PublisherCrud
{
    public class IndexModel : PageModel
    {
        private readonly EfCoreRazorCrud.Data.ApplicationDbContext _context;

        public IndexModel(EfCoreRazorCrud.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; }

        public async Task OnGetAsync()
        {
            Publisher = await _context.Publishers.ToListAsync();
        }
    }
}
