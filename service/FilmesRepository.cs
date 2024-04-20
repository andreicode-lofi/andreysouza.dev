
using Microsoft.EntityFrameworkCore;

public class FilmesRepository : IFilmesRepository
{
    private readonly appDbContext _context;

    public FilmesRepository(appDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Método para criar um novo filme na base de dados.
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    ///
    public async Task<FilmeModel> addFilme(FilmeModel model)
    {
        try
        {
            _context.Filmes.Add(model);
            await _context.SaveChangesAsync();
            return model;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao adicionar o filme: {ex.Message}");
            throw new Exception("Erro ao adicionar o filme. Por favor, tente novamente.", ex);
        }
    }

    /// <summary>
    /// Método para listar todos os filmes.
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    ///
    public async Task<List<FilmeModel>> GetAllFilmes()
    {
        try
        {
            return await _context.Filmes.ToListAsync();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao obter todos os filmes: {ex.Message}");
            throw new Exception("Erro ao obter todos os filmes. Por favor, tente novamente.", ex);
        }
    }

    /// <summary>
    /// Método para buscar filme na base dedados pelo id.
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    ///
    public async Task<FilmeModel> GetById(Guid id)
    {
        try
        {
            var filme = await _context.Filmes.FirstOrDefaultAsync(f => f.Id == id);

            if (filme == null) throw new InvalidOperationException($"Filme não foi encontrado no banco de dados.");

            return filme;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao obter o filme pelo id: {ex.Message}");
            throw new Exception("Erro ao obter todo o filme. Por favor, tente novamente.", ex);
        }
        
    }

    /// <summary>
    /// Método para remouver filme da base de dados.
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    ///
    public async Task<bool> RemoveFilme(Guid id)
    {
        try
        {
            var filme = await GetById(id);

            if (filme == null) throw new System.Exception("Ouve um erro para remouver o filme");

            _context.Filmes.Remove(filme);

            await _context.SaveChangesAsync();

            return true;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao remouver o filme pelo id: {ex.Message}");
            throw new Exception("Erro ao remouver filme. Por favor, tente novamente.", ex);
        }
        
    }

    /// <summary>
    /// Método para atualizar filme na base de dados
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    ///
    public async Task<FilmeModel> UpdateFilme(FilmeModel model)
    {
        try
        {
            var filme = await GetById(model.Id);

            if (filme == null) throw new InvalidOperationException($"O Filme {model.Titulo} não foi encontrado no banco de dados.");

            filme.Titulo = model.Titulo;
            filme.Genero = model.Genero;
            filme.DataLancamento = model.DataLancamento;
            filme.Avaliacao = model.Avaliacao;

            _context.Filmes.Update(filme);
            await _context.SaveChangesAsync();
            return filme;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao atualizar o filme pelo id: {ex.Message}");
            throw new Exception("Erro ao atualizar filme. Por favor, tente novamente.", ex);
        }
        
    }
}