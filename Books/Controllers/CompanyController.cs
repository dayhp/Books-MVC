using Books.DataAccess.Repository.IRepository;
using Books.Models;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Company> companies = _unitOfWork.Company.GetAll().ToList();
            return View(companies);
        }

        public IActionResult CreateOrEdit(int? id)
        {
            if (id == null || id == 0)
            {
                return View(new Company());
            }
            else
            {
                Company company = _unitOfWork.Company.Get(s => s.Id == id);
                return View(company);
            }
        }
        [HttpPost]
        public IActionResult CreateOrEdit(Company company)
        {
            if (ModelState.IsValid)
            {
                if (company.Id == 0)
                {
                    _unitOfWork.Company.Add(company);
                }
                else
                {
                    _unitOfWork.Company.Update(company);
                }
                _unitOfWork.Save();
                TempData["Success"] = "Company created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(company);
            }
        }

        [HttpGet]
        public IActionResult GetAllCompany()
        {
            List<Company> companies = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = companies });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            Company companyFromDb = _unitOfWork.Company.Get(s => s.Id == id);
            if (companyFromDb == null)
            {
                return Json(new { success = false, messagee = "Error while deleting" });
            }
            _unitOfWork.Company.Delete(companyFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted company success" });
        }
    }
}
