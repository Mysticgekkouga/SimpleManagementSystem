using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleManagementSystem.Data;
using SimpleManagementSystem.Models;

namespace SimpleManagementSystem.Controllers
{
    [Authorize]
    public class DevicesController : Controller
    {
        private readonly ManagementContext _managementContext;
        
        public DevicesController(ManagementContext managementContext)
        {
            _managementContext = managementContext;
        }
        
        public IActionResult Index()
        {
            IEnumerable<Device> devices = _managementContext.Devices.AsEnumerable();

            return View(devices);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("SerialNumber, Name, Stock")]Device device)
        {
            if (!_managementContext.Devices.Where(d => d.SerialNumber == device.SerialNumber).Any())
            {
                if (ModelState.IsValid)
                {
                    _managementContext.Add(device);
                    _managementContext.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                ModelState.AddModelError("SerialNumber", "Serial number already in system");
            }

            return View(device);
        }
    }
}