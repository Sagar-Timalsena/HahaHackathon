using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Web.Controllers
{
    [Authorize]
    public class VillaNumberController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public VillaNumberController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //var villaNumbers = _db.VillaNumbers.ToList();
            var villaNumbers = _unitOfWork.VillaNumber.GetAll(includeProperties: "Villa");
            return View(villaNumbers);
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
        //    VillaNumberVM villaNumberVM = new()
        //    {
        //        VillaList = _db.Villas.ToList().Select(u => new SelectListItem                
        //        {


        //            Text = u.Name,
        //            Value = u.Id.ToString()
        //        })


        //    };

        //    return View(villaNumberVM);
        //}

        //[HttpPost]
        //public IActionResult Create(VillaNumber obj)
        //{
        //    ModelState.Remove("Villa");

        //    if (ModelState.IsValid)
        //    {

        //        _db.VillaNumbers.Add(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");

        //    }
        //    return View(obj);
        //}
        [HttpPost]
        public IActionResult Create(VillaNumber obj)
        {
            ModelState.Remove("Villa");

            bool roomNumberExists = _unitOfWork.VillaNumber.Any(u => u.Villa_Number == obj.Villa_Number);
            if (ModelState.IsValid)
            {

                _unitOfWork.VillaNumber.Add(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index");

            }
            if (roomNumberExists)
            {
                TempData["error"] = "The Villa Number Already exists";
            }
            IEnumerable<SelectListItem> list = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(obj);
        }

        //public IActionResult Update(int villaNumberId)
        //{
        //    VillaNumberVM villaNumberVM = new VillaNumberVM();

        //    IEnumerable<SelectListItem> list = _db.Villas.ToList().Select(u => new SelectListItem
        //    {
        //        Text = u.Name,
        //        Value = u.Id.ToString()
        //    });

        //    villaNumberVM.VillaList = list;
        //    villaNumberVM.VillaNumber = _db.VillaNumbers.FirstOrDefault(u => u.Villa_Number == villaNumberId);

        //    if (villaNumberVM.VillaNumber == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(villaNumberVM);
        //}

        public IActionResult Update(int villaNumberId)
        {
            VillaNumber villaNumber = _unitOfWork.VillaNumber.Get(u => u.Villa_Number == villaNumberId);

            if (villaNumber == null)
            {
                return NotFound();
            }

            // Assuming ViewBag.Villalist is populated correctly in your Create action
            ViewBag.Villalist = _unitOfWork.Villa.GetAll()
                .Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() })
                .ToList();

            return View(villaNumber); // Change this line to pass a VillaNumber instance
        }


        [HttpPost]
        public IActionResult Update(VillaNumber obj)
        {

            ModelState.Remove("Villa");

            bool roomNumberExists = _unitOfWork.VillaNumber.Any(u => u.Villa_Number == obj.Villa_Number);
            if (ModelState.IsValid)
            {

                _unitOfWork.VillaNumber.Update(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index");

            }
            if (roomNumberExists)
            {
                TempData["error"] = "The Villa Number Already exists";
            }
            IEnumerable<SelectListItem> list = _unitOfWork.Villa.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(obj);
        }

        public IActionResult Delete(int villaNumberId)
        {
            VillaNumber villaNumber = _unitOfWork.VillaNumber.Get(u => u.Villa_Number == villaNumberId);

            if (villaNumber == null)
            {
                return NotFound();
            }

            // Assuming ViewBag.Villalist is populated correctly in your Create action
            ViewBag.Villalist = _unitOfWork.Villa.GetAll()
                .Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() })
                .ToList();

            return View(villaNumber); // Change this line to pass a VillaNumber instance
        }

        [HttpPost]
        public IActionResult Delete(VillaNumber obj)
        {
            VillaNumber? objFromDb = _unitOfWork.VillaNumber.Get(x => x.Villa_Number == obj.Villa_Number);

            if (objFromDb is not null)
            {
                _unitOfWork.VillaNumber.Remove(objFromDb);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
