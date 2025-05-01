using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Interfaces;
using SistemaEscolar.Models;

namespace SistemaEscolar.Controllers;

public class ProfessorController : Controller
{
    private readonly IProfessorRepository _repository;

    public ProfessorController(IProfessorRepository repository)
    {
        _repository = repository;
    }
    
    // GET
    public IActionResult Adicionar()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Adicionar(Professor professor)
    {
        if (ModelState.IsValid)
        { 
            await _repository.Adicionar(professor);
            await _repository.SaveAsync();
            return RedirectToAction("Listar");
        }
        
        return View(professor);
    }

    public IActionResult Atualizar()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Atualizar(Professor professor)
    {
        if (ModelState.IsValid)
        {
            await _repository.Atualizar(professor);
            await _repository.SaveAsync();
            return RedirectToAction("Listar");
        }

        return View(professor);
    }

    public IActionResult Remover()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remover(int id)
    {
        await _repository.Remover(id);
        await _repository.SaveAsync();
        return RedirectToAction("Listar");
    }

    public async Task<IActionResult> Listar()
    {
        var professor =  await _repository.Listar();
        return View(professor);
    }
}