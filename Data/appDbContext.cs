using System.Data.Common;
using Filmes_Jogos.Models;
using Microsoft.EntityFrameworkCore;

public class appDbContext : DbContext
{
    public DbSet<FilmeModel> Filmes {get;set;}
    public DbSet<JogoModel> Jogoss {get;set;}
    public DbSet<LoginModel> Login { get; set; }
    public DbSet<UsuarioModel> Usuarios {get;set;}
    public DbSet<JogosFilmesModel> JogosFilmes {get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString:"Data Source=ANDREY;Initial Catalog=JogosFilmes;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        base.OnConfiguring(optionsBuilder);
    }

}
