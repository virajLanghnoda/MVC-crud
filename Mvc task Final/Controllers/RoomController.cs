using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc_task_Final.Models;

namespace Mvc_task_Final.Controllers
{
    public class RoomController : Controller
    {
        static IList<Room> roomList = new List<Room>();
        // GET: Room
        public ActionResult Index()
        {
            return View(roomList);
        }

        // GET: Room/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection form)
        {
            try
            {
                Room obj = new Room
                {
                    RoomId = Int32.Parse(form["RoomId"]),
                    RoomNumber = Int32.Parse(form["RoomNumber"]),
                    NumberOfPerson = Int32.Parse(form["NumberOfPerson"]),
                    CheckInDate = DateTime.Parse(form["CheckInDate"]),
                    CheckOutDate = DateTime.Parse(form["CheckOutDate"]),
                    RoomType = form["RoomType"],
                    Description = form["Description"]
                };

                // Validate date difference
                if (ValidateDateDifference(obj.CheckInDate, obj.CheckOutDate))
                {
                    
                    if (obj.NumberOfPerson <= 3)
                    {
                        
                        obj.TotalHours = (int)(obj.CheckOutDate - obj.CheckInDate).TotalHours;
                        obj.TotalDays = (int)(obj.CheckOutDate - obj.CheckInDate).TotalDays;

                        roomList.Add(obj);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Number of persons should be 3 or less.";
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "The minimum difference between Check-In and Check-Out dates should be 1 day.";
                }

                
                ViewBag.RoomTypes = new List<string> { "Delux", "Super Delux", "Premium" };
                return View();
            }
            catch
            {
                return View();
            }
        }




        
        private bool ValidateDateDifference(DateTime checkInDate, DateTime checkOutDate)
        {
            
            TimeSpan difference = checkOutDate - checkInDate;

            return difference.Days >= 1;
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Room/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Room/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}