using AspNetCoreMVCPractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVCPractice.Controllers;

public class ItemsController : Controller
{
    // GET
    public ViewResult Overview()
    {
        var item = new Items() {Name = "Mouse"};
        return View(item);
    }

    public IActionResult Edit(int id)
    {
        return Content($"id = {id}");
    }
}