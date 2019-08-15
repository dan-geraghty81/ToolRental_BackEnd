using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToolRental_BackEnd.Models;
using ToolRental_BackEnd.ViewModels;

namespace ToolRental_BackEnd.Controllers
{
    public class ReportsController : ApiController
    {
		private ToolRentalEntities db = new ToolRentalEntities();

		[HttpGet]
		[Route("api/Reports/GetToolRentalCountReport")]
		public IEnumerable<ToolRentalCountViewModel> GetToolRentalCountReport()
		{
			string sql = "SELECT Tools.ToolID, Tools.ToolName, COUNT(RentalItem.ToolID) AS RentalCount "
						+"FROM Tools "
						+"INNER JOIN RentalItem ON Tools.ToolID = RentalItem.ToolID "
						+"GROUP BY Tools.ToolName, Tools.ToolID";
			return db.Database.SqlQuery<ToolRentalCountViewModel>(sql).ToList();
		}
    }
}
