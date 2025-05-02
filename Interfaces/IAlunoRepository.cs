using SistemaEscolar.Models;

namespace SistemaEscolar.Interfaces;

public interface IAlunoRepository
{
    Task Adicionar(Aluno aluno);
    
    Task Atualizar(Aluno aluno);
    
    Task <Aluno> GetById(int id);
    
    Task Remover(int id);
    
    Task <List<Aluno>> Listar();
}