
using BulkyWeb.DataAccess.Data;
using BulkyWeb.DataAccess.Repository.Repository;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

using BulkyWeb.DataAccess.Repository.IRepository;

namespace BulkyWeb.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public CategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        List<Category> objCategoryList = _unitOfWork.categoryRepository.GetAll().ToList();
        return View(objCategoryList);
    }

    public IActionResult Create()
    {

        return View();
    }
    [HttpPost]
    public IActionResult Create(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The Display order can not exactly match the name");
        }

        if (ModelState.IsValid)
        {
            _unitOfWork.categoryRepository.Add(obj);
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
        var category = _unitOfWork.categoryRepository.Get(u => u.Id == id);
        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    [HttpPost]
    public IActionResult Edit(Category category)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.categoryRepository.Update(category);
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
        Category category = new Category();
        if (ModelState.IsValid)
        {
            category = _unitOfWork.categoryRepository.Get(u => u.Id == id);
        }

        if (category == null)
        {
            return NotFound();
        }

        return View(category);

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
            Category categoryObj = _unitOfWork.categoryRepository.Get(u => u.Id == id);
            _unitOfWork.categoryRepository.Remove(categoryObj);
            _unitOfWork.Save();
            TempData["success"] = "category deleted successfully";
            return RedirectToAction("Index");
        }

        return View();
    }

}
