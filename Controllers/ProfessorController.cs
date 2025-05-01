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
    
    [HttpGet]
    public IActionResult Adicionar()
    {
        return View((new Professor()));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Adicionar(Professor professor)
    {
        if (ModelState.IsValid)
        {
            if (professor.Id > 0)
            {
                await _repository.Atualizar(professor);
                return RedirectToAction("Listar");
            }
            await _repository.Adicionar(professor);
            return RedirectToAction("Listar");
        }
        
        return View("Adicionar", professor);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Atualizar(int id)
    {
        var professor = await _repository.GetById(id);
        if (professor == null)
        {
            ModelState.AddModelError("", "Pessoa não encontrada!");
            return View();  
        }
        return View("Adicionar", professor);    
    }
    
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remover(int id)
    {
        await _repository.Remover(id);
        return RedirectToAction("Listar");
    }

    public async Task<IActionResult> Listar()
    {
        var professor =  await _repository.Listar();
        return View(professor);
    }
}