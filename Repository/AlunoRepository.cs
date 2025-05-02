using Microsoft.EntityFrameworkCore;
using SistemaEscolar.DataBase;
using SistemaEscolar.Interfaces;
using SistemaEscolar.Models;

namespace SistemaEscolar.Repository;

public class AlunoRepository : IAlunoRepository
{
    private readonly Conexao _context;

    public AlunoRepository(Conexao context)
    {
        _context = context;
    }

    public async Task Adicionar(Aluno aluno)
    {
        _context.Aluno.Add(aluno);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(Aluno aluno)
    {
        _context.Entry(aluno).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<Aluno> GetById(int id)
    {
        return await _context.Aluno.FindAsync(id);
    }

    public async Task Remover(int id)
    {
        var aluno = await _context.Aluno.FindAsync(id);
        if (aluno != null)
        {
            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Aluno>> Listar()
    {
        return await _context.Aluno.ToListAsync();
    }
}