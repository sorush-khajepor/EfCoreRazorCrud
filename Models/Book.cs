using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EfTest.Models
{
    public class Book
    {
		public int Id { get; set; }
		public string Title { get; set; }

		public int PublisherId { get; set; }
		public Publisher Publisher { get; set; }

		[NotMapped]
		public string FilePath
		{
			get { return Path.Combine("..","pdf",Title + ".pdf"); }
		}

	}
}
