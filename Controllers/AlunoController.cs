using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Interfaces;
using SistemaEscolar.Models;

namespace SistemaEscolar.Controllers;

public class AlunoController : Controller
{
    private readonly IAlunoRepository _repository;

    public AlunoController(IAlunoRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    public IActionResult Adicionar()
    {
        return View((new Aluno()));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Adicionar(Aluno aluno)
    {
        if (ModelState.IsValid)
        {
            if (aluno.Id > 0)
            {
                await _repository.Atualizar(aluno);
                return RedirectToAction("Listar");
            }
            await _repository.Adicionar(aluno);
            return RedirectToAction("Listar");
        }
        return View("Adicionar", aluno);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Atualizar(int id)
    {
        var aluno = await _repository.GetById(id);
        return View("Adicionar", aluno);
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
        var alunos = await _repository.Listar();
        return View(alunos);
    }
}