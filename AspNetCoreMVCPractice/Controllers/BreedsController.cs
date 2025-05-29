using AspNetCoreMVCPractice.Data;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreMVCPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Controllers;

public class BreedsController : Controller
{
    private readonly AspNetVetContext _context;

    public BreedsController(AspNetVetContext context)
    {
        _context = context;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var items = await _context.Breeds.Include(b => b.Species).ToListAsync();
        return View(items);
    }
    private async Task<List<Species>> GetSpeciesList()
    {
        return await _context.Species.Where(s => s.Status).ToListAsync();
    }
    
    public async Task<IActionResult> Create()
    {
        ViewBag.Species = await GetSpeciesList();
        return View();
    }
    
    [HttpPost]
public async Task<IActionResult> Create([Bind("Id,Name,SpeciesId,Status")] Breed breed)
{
    if (!ModelState.IsValid)
    {
        ViewBag.Species = await GetSpeciesList();
        return View(breed);
    }

    try
    {
        var species = await _context.Species.FindAsync(breed.SpeciesId);
        if (species == null)
        {
            ModelState.AddModelError("SpeciesId", "La especie seleccionada no existe");
            ViewBag.Species = await GetSpeciesList();
            return View(breed);
        }

        breed.Species = species;
        _context.Breeds.Add(breed);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    catch (DbUpdateException)
    {
        ModelState.AddModelError(string.Empty, "No se pudo guardar los cambios en la base de datos");
        ViewBag.Species = await GetSpeciesList();
        return View(breed);
    }
}

    public IActionResult Edit()
    {
        throw new NotImplementedException();
    }

    public IActionResult DeleteBreed()
    {
        throw new NotImplementedException();
    }
}

