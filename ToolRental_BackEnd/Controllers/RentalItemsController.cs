﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ToolRental_BackEnd.Models;

namespace ToolRental_BackEnd.Controllers
{
    public class RentalItemsController : ApiController
    {
        private ToolRentalEntities db = new ToolRentalEntities();

        // GET: api/RentalItems
        public IQueryable<RentalItem> GetRentalItems()
        {
            return db.RentalItems;
        }

        // GET: api/RentalItems/5
        [ResponseType(typeof(RentalItem))]
        public IHttpActionResult GetRentalItem(int id)
        {
            RentalItem rentalItem = db.RentalItems.Find(id);
            if (rentalItem == null)
            {
                return NotFound();
            }

            return Ok(rentalItem);
        }

		[HttpGet]
		[Route("api/RentalItemsById/{id}")]
		[ResponseType(typeof(RentalItemsController))]
		public IQueryable<RentalItem> GetRentalItemsById(int Id)
		{
			// to get Rental Items using RentalID
			return db.RentalItems.Where(ri => ri.RentalId == Id);
		}

		// PUT: api/RentalItems/5
		[ResponseType(typeof(void))]
        public IHttpActionResult PutRentalItem(int id, RentalItem rentalItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rentalItem.RentalItemID)
            {
                return BadRequest();
            }

            db.Entry(rentalItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RentalItems
        [ResponseType(typeof(RentalItem))]
        public IHttpActionResult PostRentalItem(RentalItem rentalItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RentalItems.Add(rentalItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rentalItem.RentalItemID }, rentalItem);
        }

        // DELETE: api/RentalItems/5
        [ResponseType(typeof(RentalItem))]
        public IHttpActionResult DeleteRentalItem(int id)
        {
            RentalItem rentalItem = db.RentalItems.Find(id);
            if (rentalItem == null)
            {
                return NotFound();
            }

            db.RentalItems.Remove(rentalItem);
            db.SaveChanges();

            return Ok(rentalItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RentalItemExists(int id)
        {
            return db.RentalItems.Count(e => e.RentalItemID == id) > 0;
        }
    }
}