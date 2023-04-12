using BullkyBook.DataAccess.Repository.IRepository;
using BullkyBook.Models;
using BullkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BullkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Company> CompanyList = _unitOfWork.CompanyRepository.GetAll().ToList();
            return View(CompanyList);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                return View(new Company());
            }
            else
            {
                Company companyObj = _unitOfWork.CompanyRepository.Get(u => u.Id == id);
                return View(companyObj);
            }
        }
            
        [HttpPost]
        public IActionResult Upsert(Company CompanyObj)
        {
            if (ModelState.IsValid) {
                if (CompanyObj.Id == 0)
                {
                    _unitOfWork.CompanyRepository.Add(CompanyObj);
                }
                else
                {
                    _unitOfWork.CompanyRepository.Update(CompanyObj);
                }
                _unitOfWork.Save();
                TempData["success"] = "Company Created SuccessFully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(CompanyObj);
            }
        }
        #region
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> CompanyList = _unitOfWork.CompanyRepository.GetAll().ToList();
            return Json(new { data = CompanyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var CompanyToBeDeleted = _unitOfWork.CompanyRepository.Get(u => u.Id == id);
            if (CompanyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }
            
            _unitOfWork.CompanyRepository.Remove(CompanyToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successfully" });
        }
        #endregion
    }
}