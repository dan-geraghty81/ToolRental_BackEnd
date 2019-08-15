using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolRental_BackEnd.ViewModels
{
	public class ToolRentalCountViewModel
	{
		public int ToolID { get; set; }
		public string ToolName { get; set; }
		public int? RentalCount { get; set; }
	}
}