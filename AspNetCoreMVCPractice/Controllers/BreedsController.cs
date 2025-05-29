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

    public async Task<IActionResult> Edit(int id)
    {
        var breed = await _context.Breeds.Include(b => b.Species).FirstOrDefaultAsync(b => b.Id == id);
        if (breed == null) return NotFound();
        ViewBag.Species = await GetSpeciesList();
        ViewBag.SelectedSpeciesId = breed.SpeciesId;  // Agregamos el ID de la especie seleccionada al ViewBag
        return View(breed);
    }
    
    [HttpPut]
    public async Task<IActionResult> Edit(int id, [FromBody] Breed breed)
    {
        if (id != breed.Id) return BadRequest();

        try
        {
            var existingBreed = await _context.Breeds.Include(b => b.Species)
                .FirstOrDefaultAsync(b => b.Id == id);
                
            if (existingBreed == null) return NotFound();

            var species = await _context.Species.FindAsync(breed.SpeciesId);
            if (species == null)
            {
                return BadRequest(new { message = "La especie seleccionada no existe" });
            }

            existingBreed.Name = breed.Name;
            existingBreed.SpeciesId = breed.SpeciesId;
            existingBreed.Status = breed.Status;
            existingBreed.Species = species;

            _context.Breeds.Update(existingBreed);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new { message = "No se pudo guardar los cambios en la base de datos" });
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var breed = await _context.Breeds.Include(b => b.Species).FirstOrDefaultAsync(b => b.Id == id);
        if (breed == null) return NotFound();
        try
        {
            _context.Breeds.Remove(breed);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new { message = "No se pudo eliminar la raza de la base de datos" });
        }
    }
}

