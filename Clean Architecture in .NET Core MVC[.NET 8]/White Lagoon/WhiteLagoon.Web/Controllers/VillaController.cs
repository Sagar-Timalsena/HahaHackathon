//using Microsoft.AspNetCore.Mvc;
//using WhiteLagoon.Domain.Entities;
//using WhiteLagoon.Infrastructure.Data;

//namespace WhiteLagoon.Web.Controllers
//{
//    public class VillaController : Controller
//    {

//        private readonly ApplicationDbContext _db;

//        public VillaController(ApplicationDbContext db)
//        {
//            _db = db;
//        }
//        public IActionResult Index()
//        {
//            var villas = _db.Villas.ToList();
//            return View(villas);
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Create(Villa obj)
//        {
//            if (obj.Name == obj.Description)
//            {
//                ModelState.AddModelError("description", "Description and name should not be same");
//            }
//            if (ModelState.IsValid)
//            {
//                _db.Villas.Add(obj);
//                _db.SaveChanges();
//                return RedirectToAction("Index");

//            }
//            return View(obj);
//        }


//        public IActionResult Update(int villaId)
//        {
//            Villa? obj = _db.Villas.FirstOrDefault(x => x.Id == villaId);
//            if (obj == null)
//            {
//                return NotFound();
//            }
//            return View(obj);
//        }
//        [HttpPost]
//        public IActionResult Update(Villa obj)
//        {

//            if (ModelState.IsValid && obj.Id > 0)
//            {
//                _db.Villas.Update(obj);
//                _db.SaveChanges();
//                return RedirectToAction("Index");

//            }
//            return View(obj);
//        }
//        public IActionResult Delete(int villaId)
//        {
//            Villa? obj = _db.Villas.FirstOrDefault(x => x.Id == villaId);
//            if (obj == null)
//            {
//                return NotFound();
//            }
//            return View(obj);
//        }
//        [HttpPost]
//        public IActionResult Delete(Villa obj)
//        {
//            Villa? objFromDb = _db.Villas.FirstOrDefault(x => x.Id == obj.Id);

//            if (objFromDb is not null)
//            {
//                _db.Villas.Remove(objFromDb);
//                _db.SaveChanges();
//                return RedirectToAction("Index");

//            }
//            return View();
//        }

//    }
//}

//using Microsoft.AspNetCore.Mvc;
//using WhiteLagoon.Application.Common.Interfaces;
//using WhiteLagoon.Domain.Entities;
//using WhiteLagoon.Infrastructure.Data;

//namespace WhiteLagoon.Web.Controllers
//{
//    public class VillaController : Controller
//    {

//        //private readonly IVillaRepository _villaRepo;

//        //public VillaController(IVillaRepository villaRepo)
//        //{
//        //    _villaRepo = villaRepo;       
//        //}
//        private readonly IUnitOfWork _unitOfWork;

//        public VillaController(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//         }
//        public IActionResult Index()
//        {
//            var villas = _unitOfWork.GetAll();
//            return View(villas);
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Create(Villa obj)
//        {
//            if (obj.Name == obj.Description)
//            {
//                ModelState.AddModelError("description", "Description and name should not be same");
//            }
//            if (ModelState.IsValid)
//            {
//                _villaRepo.Add(obj);
//                _villaRepo.Save();                
//                return RedirectToAction("Index");

//            }
//            return View(obj);
//        }


//        public IActionResult Update(int villaId)
//        {
//            Villa? obj = _villaRepo.Get(x => x.Id == villaId);
//            if (obj == null)
//            {
//                return NotFound();
//            }
//            return View(obj);
//        }
//        [HttpPost]
//        public IActionResult Update(Villa obj)
//        {

//            if (ModelState.IsValid && obj.Id > 0)
//            {
//                _villaRepo.Update(obj);
//                _villaRepo.Save();
//                return RedirectToAction("Index");

//            }
//            return View(obj);
//        }
//        public IActionResult Delete(int villaId)
//        {
//            Villa? obj = _villaRepo.Get(x => x.Id == villaId);
//            if (obj == null)
//            {
//                return NotFound();
//            }
//            return View(obj);
//        }
//        [HttpPost]
//        public IActionResult Delete(Villa obj)
//        {
//            Villa? objFromDb = _villaRepo.Get(x => x.Id == obj.Id);

//            if (objFromDb is not null)
//            {
//                _villaRepo.Remove(objFromDb);
//                _villaRepo.Save();
//                return RedirectToAction("Index");

//            }
//            return View();
//        }

//    }
//}

using Microsoft.AspNetCore.Mvc;
using System.IO;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Web.Controllers
{
    public class VillaController : Controller
    {

        //private readonly IVillaRepository _villaRepo;

        //public VillaController(IVillaRepository villaRepo)
        //{
        //    _villaRepo = villaRepo;       
        //}
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public VillaController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var villas = _unitOfWork.Villa.GetAll();
            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa obj)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("description", "Description and name should not be same");
            }
            if (ModelState.IsValid)
            {
                if(obj.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\VillaImage");
                    using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
                    
                        obj.Image.CopyTo(fileStream);

                    obj.ImageUrl = @"\images\VillaImage\" + fileName;
                }
                else
                {
                    obj.ImageUrl = "https://placehold.co/600*400";
                }
                _unitOfWork.Villa.Add(obj);
                _unitOfWork.Villa.Save();
                //TempData["success"] = "The villa has been created successfully.";

                return RedirectToAction("Index");

            }
            return View(obj);
        }


        public IActionResult Update(int villaId)
        {
            Villa? obj = _unitOfWork.Villa.Get(x => x.Id == villaId);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult Update(Villa obj)
        {

            if (ModelState.IsValid && obj.Id > 0)
            {
                if (obj.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\VillaImage");
                    if(!string.IsNullOrEmpty(obj.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
                    
                    
                    if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                            
                    }


                    using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))

                        obj.Image.CopyTo(fileStream);

                    obj.ImageUrl = @"\images\VillaImage\" + fileName;
                }
               
                _unitOfWork.Villa.Update(obj);
                _unitOfWork.Villa.Save();
                return RedirectToAction("Index");

            }
            return View(obj);
        }
        public IActionResult Delete(int villaId)
        {
            Villa? obj = _unitOfWork.Villa.Get(x => x.Id == villaId);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult Delete(Villa obj)
        {
            Villa? objFromDb = _unitOfWork.Villa.Get(x => x.Id == obj.Id);

            if (objFromDb is not null)
            {
                if (!string.IsNullOrEmpty(objFromDb.ImageUrl))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, objFromDb.ImageUrl.TrimStart('\\'));


                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }

                }
                _unitOfWork.Villa.Remove(objFromDb);
                _unitOfWork.Villa.Save();
                return RedirectToAction("Index");

            }
            return View();
        }

    }
}

