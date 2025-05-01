using SistemaEscolar.Models;

namespace SistemaEscolar.Interfaces;

public interface IProfessorRepository
{
    Task Adicionar(Professor professor);
    
    Task Atualizar(Professor professor);
    
    Task Remover(int id);
    
    Task <List<Professor>> Listar();

    Task SaveAsync();
}