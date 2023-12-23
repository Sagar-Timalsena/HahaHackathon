 

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;
using WhiteLagoon.Web.ViewModels;

namespace WhiteLagoon.Web.Controllers
{
    public class AmenityController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public AmenityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //var amenities = _db.Amenitys.ToList();
            var amenities = _unitOfWork.Amenity.GetAll(includeproperties: "Villa");
            return View(amenities);
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> list = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewBag.VillaList = list;
            return View();
        }
        //public IActionResult Create()
        //{
        //    AmenityVM amenityVM = new()
        //    {
        //        VillaList = _db.Villas.ToList().Select(u => new SelectListItem                
        //        {


        //            Text = u.Name,
        //            Value = u.Id.ToString()
        //        })


        //    };

        //    return View(amenityVM);
        //}

        //[HttpPost]
        //public IActionResult Create(Amenity obj)
        //{
        //    ModelState.Remove("Villa");

        //    if (ModelState.IsValid)
        //    {

        //        _db.Amenitys.Add(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");

        //    }
        //    return View(obj);
        //}
        [HttpPost]
        public IActionResult Create(Amenity obj)
        {
          //  ModelState.Remove("Villa");

             if (ModelState.IsValid)
            {

                _unitOfWork.Amenity.Add(obj);
                _unitOfWork.Save();
                 return RedirectToAction("Index");

            }
           
            IEnumerable<SelectListItem> list = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(obj);
        }

        //public IActionResult Update(int amenityId)
        //{
        //    AmenityVM amenityVM = new AmenityVM();

        //    IEnumerable<SelectListItem> list = _db.Villas.ToList().Select(u => new SelectListItem
        //    {
        //        Text = u.Name,
        //        Value = u.Id.ToString()
        //    });

        //    amenityVM.VillaList = list;
        //    amenityVM.Amenity = _db.Amenitys.FirstOrDefault(u => u.Villa_Number == amenityId);

        //    if (amenityVM.Amenity == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(amenityVM);
        //}

        public IActionResult Update(int amenityId)
        {
            Amenity amenity = _unitOfWork.Amenity.Get(u => u.Id == amenityId);

            if (amenity == null)
            {
                return NotFound();
            }

            // Assuming ViewBag.Villalist is populated correctly in your Create action
            ViewBag.Villalist = _unitOfWork.Villa.GetAll()
                .Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() })
                .ToList();

            return View(amenity); // Change this line to pass a Amenity instance
        }


        [HttpPost]
        public IActionResult Update(Amenity obj)
        {

            ModelState.Remove("Villa");

             if (ModelState.IsValid)
            {

               _unitOfWork.Amenity.Update(obj);
                _unitOfWork.Save();                
                return RedirectToAction("Index");

            }
           
            IEnumerable<SelectListItem> list = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(obj);
        }

        public IActionResult Delete(int amenityId)
        {
            Amenity amenity = _unitOfWork.Amenity.Get(u => u.Id == amenityId);

            if (amenity == null)
            {
                return NotFound();
            }

            // Assuming ViewBag.Villalist is populated correctly in your Create action
            ViewBag.Villalist = _unitOfWork.Villa.GetAll()
                .Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() })
                .ToList();

            return View(amenity); // Change this line to pass a Amenity instance
        }

        [HttpPost]
        public IActionResult Delete(Amenity obj)
        {
            Amenity? objFromDb = _unitOfWork.Amenity.Get(x => x.Id == obj.Id);

            if (objFromDb is not null)
            {
                _unitOfWork.Amenity.Remove(objFromDb);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
