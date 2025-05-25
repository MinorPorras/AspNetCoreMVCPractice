using AspNetCoreMVCPractice.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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