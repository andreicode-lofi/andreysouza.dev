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
        optionsBuilder.UseSqlServer(connectionString:"Server=tcp:jogosfilmes.database.windows.net,1433;Initial Catalog=jogosfilmes;Persist Security Info=False;User ID=jogosfilmes;Password=AN988687098dc;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        base.OnConfiguring(optionsBuilder);
    }

}
