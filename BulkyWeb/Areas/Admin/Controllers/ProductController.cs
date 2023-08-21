
using Microsoft.AspNetCore.Mvc;
using BulkyWeb.DataAccess.Repository.IRepository;
using BulkyWeb.Models;

namespace BulkyWeb.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        List<Product> objCategoryList = _unitOfWork.productRepository.GetAll().ToList();
        return View(objCategoryList);
    }

    public IActionResult Create()
    {

        return View();
    }
    [HttpPost]
    public IActionResult Create(Product obj)
    {
        //if (obj.Name == obj.DisplayOrder.ToString())
        //{
        //    ModelState.AddModelError("name", "The Display order can not exactly match the name");
        //}

        if (ModelState.IsValid)
        {
            _unitOfWork.productRepository.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "category created successfully";
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var product = _unitOfWork.productRepository.Get(u => u.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    [HttpPost]
    public IActionResult Edit(Product product)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.productRepository.Update(product);
            _unitOfWork.Save();
            TempData["success"] = "category edited successfully";
            return RedirectToAction("Index");
        }

        return View();
    }


    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Product product = new Product();
        if (ModelState.IsValid)
        {
            product = _unitOfWork.productRepository.Get(u => u.Id == id);
        }

        if (product == null)
        {
            return NotFound();
        }

        return View(product);

    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            Product productObj = _unitOfWork.productRepository.Get(u => u.Id == id);
            _unitOfWork.productRepository.Remove(productObj);
            _unitOfWork.Save();
            TempData["success"] = "category deleted successfully";
            return RedirectToAction("Index");
        }

        return View();
    }

}
