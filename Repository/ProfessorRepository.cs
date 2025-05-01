using Microsoft.EntityFrameworkCore;
using SistemaEscolar.DataBase;
using SistemaEscolar.Interfaces;
using SistemaEscolar.Models;

namespace SistemaEscolar.Repository;

public class ProfessorRepository : IProfessorRepository
{
    private readonly Conexao _context;

    public ProfessorRepository(Conexao context)
    {
        _context = context;
    }

    public async Task Adicionar(Professor professor)
    {
        _context.Professor.Add(professor);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(Professor professor)
    {
        _context.Entry(professor).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<Professor> GetById(int id)
    {
        return await _context.Professor.FindAsync(id);
    }

    public async Task Remover(int id)
    {
        var professor = await _context.Professor.FindAsync(id);
        if (professor != null)
        {
            _context.Professor.Remove(professor);
            await _context.SaveChangesAsync();
        }

    }

    public async Task<List<Professor>> Listar()
    {
        return await _context.Professor.ToListAsync();
    }

}
