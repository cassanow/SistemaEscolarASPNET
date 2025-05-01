using SistemaEscolar.Models;

namespace SistemaEscolar.Interfaces;

public interface IProfessorRepository
{
    Task Adicionar(Professor professor);
    
    Task Atualizar(Professor professor);

    Task<Professor> GetById(int id);
    
    Task Remover(int id);
    
    Task <List<Professor>> Listar();
    
}