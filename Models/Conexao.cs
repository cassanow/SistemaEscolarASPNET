using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Models;

namespace SistemaEscolar.DataBase;

public class Conexao : DbContext
{
    public Conexao(DbContextOptions<Conexao> options) : base(options)
    {
        
    }
    
    public DbSet<Professor> Professor { get; set; }
    
}