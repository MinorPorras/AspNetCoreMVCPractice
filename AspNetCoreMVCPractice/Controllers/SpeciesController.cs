using AspNetCoreMVCPractice.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreMVCPractice.Models;

namespace AspNetCoreMVCPractice.Controllers;

/// <summary>
/// Controller responsible for managing animal species in the veterinary system.
/// Handles CRUD operations for species data.
/// </summary>
public class SpeciesController : Controller
{
    private readonly AspNetVetContext _context;

    /// <summary>
    /// Initializes a new instance of the SpeciesController.
    /// </summary>
    /// <param name="context">The database context for species data access.</param>
    public SpeciesController(AspNetVetContext context)
    {
        _context= context;
    }

    /// <summary>
    /// Retrieves and displays a list of all species.
    /// </summary>
    /// <returns>A view containing a list of all species in the database.</returns>
    public async Task<IActionResult> Index()
    {
        var items = await _context.Species.ToListAsync();
        return View(items);
    }
    
    /// <summary>
    /// Goes to the view for creating a new species record.
    /// </summary>
    /// <returns>The view for creating a new species record.</returns>
    public ViewResult Create()
    {
        return View();
    }
    
    /// <summary>
    /// Creates a new species record.
    /// </summary>
    /// <returns>The Index action view of Species.</returns>
    [HttpPost]
    public async Task<IActionResult> Create([Bind("Id, Name")] Species species, string status)
    {
        //SI el modelo no es valido, se regresa a la vista de crear
        Console.WriteLine(ModelState.IsValid);
        Console.WriteLine(species.Id);
        species.Status = status == "Active" ? true : false;
        Console.WriteLine(species.Status);
        if (!ModelState.IsValid) return View(species);
        //SI el modelo es valido, se agrega a la base de datos
        _context.Species.Add(species);
        await _context.SaveChangesAsync();
        //Redirecciona a la vista de index
        return RedirectToAction(nameof(Index));
    }
    
    

    /// <summary>
    /// Handles the editing of a species record.
    /// </summary>
    /// <returns>The edit view for a species record.</returns>
    /// <exception cref="NotImplementedException">This method is not yet implemented.</exception>
    public IActionResult Edit()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Handles the deletion of a species record.
    /// </summary>
    /// <returns>The delete confirmation view for a species record.</returns>
    /// <exception cref="NotImplementedException">This method is not yet implemented.</exception>
    public IActionResult Delete()
    {
        throw new NotImplementedException();
    }
    
    
}