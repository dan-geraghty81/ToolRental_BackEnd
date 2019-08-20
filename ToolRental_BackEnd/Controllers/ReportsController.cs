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

		[HttpGet]
		[Route("api/Reports/GetCurrentRentedToolListReport")]
		public IEnumerable<CurrentRentedToolsViewModel> GetCurrentRentedToolListReport()
		{
			string sql = "SELECT Tools.ToolID, Tools.ToolName, Tools.Brand, Rental.DateRented, Customer.CustomerName " +
						 "FROM Tools " +
						 "INNER JOIN RentalItem ON Tools.ToolID = RentalItem.ToolID " +
						 "INNER JOIN Rental ON Rental.RentalID = RentalItem.RentalID " +
						 "INNER JOIN Customer ON Rental.CustomerID = Customer.CustomerID " +
						 "WHERE Rental.DateReturned IS NULL";
			return db.Database.SqlQuery<CurrentRentedToolsViewModel>(sql).ToList();
		}

		[HttpGet]
		[Route("api/Reports/GetCurrentActiveToolsReport")]
		public IEnumerable<CurrentActiveToolsViewModel> GetCurrentActiveToolsReport()
		{
			string sql = "SELECT Tools.ToolID, Tools.ToolName, Tools.Brand, Tools.Comments " +
						 "FROM Tools " +
						 "WHERE Tools.Inactive = 0";
			return db.Database.SqlQuery<CurrentActiveToolsViewModel>(sql).ToList();
		}

		[HttpGet]
		[Route("api/Reports/GetRetiredToolListReport")]
		public IEnumerable<RetiredToolListViewModel> GetRetiredToolListReport()
		{
			string sql = "SELECT Tools.ToolID, Tools.ToolName, Tools.Brand, Tools.Comments " +
						 "FROM Tools " +
						 "WHERE Tools.Inactive = 1";
			return db.Database.SqlQuery<RetiredToolListViewModel>(sql).ToList();
		}

    }
}
