using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EfTest.Data;
using EfTest.Models;

namespace EfTest.Admin.PublisherCrud
{
    public class IndexModel : PageModel
    {
        private readonly EfTest.Data.ApplicationDbContext _context;

        public IndexModel(EfTest.Data.ApplicationDbContext context)
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
