using System.Data.SqlTypes;
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
        Console.WriteLine("pasa");
        //SI el modelo no es valido, se regresa a la vista de crear
        species.Status = status == "Active" ? true : false;
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
/// <summary>
    /// Displays the edit form for a specific species record.
    /// </summary>
    /// <param name="id">The ID of the species to edit.</param>
    /// <returns>The edit view for the specified species record, or NotFound if the species doesn't exist.</returns>
    public async Task<IActionResult> Edit(int id)
    {
        Console.WriteLine("Edit normal");
        var item = await _context.Species.FirstOrDefaultAsync(x => x.Id == id);
        if (item == null) return NotFound();
        return View(item);
    }
    
    /// <summary>
    /// Saves the changes made to a species record.
    /// </summary>
    /// <param name="species">Object from the species model tha conatins the information to save</param>
    /// <param name="status">String containing "Active" or "Inactive", if is "Active" its value is turned to true</param>
    /// <returns>Redirects to the Index action of Species.</returns>
    [HttpPost]
    public async Task<IActionResult> Edit([Bind("Id, Name")] Species species, string status)
    {
        species.Status = status == "Active" ? true : false;
        // Si el modelo no es valido, se regresa a la vista de editar
        if (!ModelState.IsValid) return View(species);
        _context.Update(species);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Removes a species record from the database.
    /// </summary>
    /// <param name="id">The ID of the species to delete.</param>
    /// <returns>Redirects to the Index view after deletion, or returns NotFound if the species doesn't exist.</returns>
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _context.Species.FirstOrDefaultAsync(x => x.Id == id);
        if (item == null) return NotFound();
        Species species = item;
        _context.Species.Remove(species);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

    }
    
    /// <summary>
    /// Removes a species record from the database using HTTP DELETE method.
    /// </summary>
    /// <param name="id">The ID of the species to delete</param>
    [HttpDelete]
    [ValidateAntiForgeryToken]
    [Route("Species/DeleteSpecies/{id}")]
    public async Task<IActionResult> DeleteSpecies(int id)
    {
        var species = await _context.Species.FindAsync(id);
        if (species == null)
        {
            return NotFound();
        }

        _context.Species.Remove(species);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
