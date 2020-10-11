﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly EfCoreRazorCrud.Data.ApplicationDbContext _context;

        public DetailsModel(EfCoreRazorCrud.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Publisher Publisher { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Publisher = await _context.Publishers.FirstOrDefaultAsync(m => m.Id == id);

            if (Publisher == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
