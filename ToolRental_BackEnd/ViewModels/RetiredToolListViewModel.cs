using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolRental_BackEnd.ViewModels
{
	public class RetiredToolListViewModel
	{
		public int ToolID { get; set; }
		public string ToolName { get; set; }
		public string Brand { get; set; }
		public string Comments { get; set; }
	}
}