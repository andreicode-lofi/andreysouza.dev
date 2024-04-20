using Microsoft.EntityFrameworkCore;

public class JogosRepository : IJogosRepository
{

    private readonly appDbContext _context;

    public JogosRepository(appDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Método para popular a lista de jogos.
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    ///
    public async Task<List<JogoModel>> GetAllJogos()
    {
        try
        {
            return await _context.Jogoss.ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao obter todos os jogos: {ex.Message}");
            return new List<JogoModel>();
        }
    }

    /// <summary>
    /// Método para fazer uma busca de jogos por iD.
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    ///
    public async Task<JogoModel> GetbyId(Guid id)
    {
        try
        {
            var jogos = await _context.Jogoss.FirstOrDefaultAsync(j => j.Id == id);

            if (jogos == null) throw new InvalidOperationException($"Jogo não foi encontrado no banco de dados.");

            return jogos;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao obter o jogo com o ID {id}: {ex.Message}");
            throw new Exception("Erro ou buscar jogo pelo id. Por favor, tente novamente.", ex);

        }
    }

    /// <summary>
    /// Método para criar um jogos na base de dados.
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    ///
    public async Task<JogoModel> AddJogo(JogoModel model)
    {
        try
        {
            _context.Jogoss.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao adicionar o jogo: {ex.Message}");
            throw new Exception("Erro ao tentar criar um novo jogo, tente novamente.", ex);

        }

    }

    /// <summary>
    /// Método para remouver jogos da base de dados.
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    ///
    public async Task<bool> RemoveJogo(Guid id)
    {
        try
        {
            var jogos = await GetbyId(id);

            if (jogos == null) throw new InvalidOperationException($"Jogo não foi encontrado no banco de dados.");

            _context.Jogoss.Remove(jogos);

            await _context.SaveChangesAsync();

            return true;

        }
        catch(Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao remover o jogo com o ID {id}: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// Método para atualiza um jogos da base de dados.
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    ///
    public async Task<JogoModel> UpDateJogos(JogoModel model)
    {
        try
        {
            var jogo = await GetbyId(model.Id);

            if (jogo == null) throw new InvalidOperationException($"O jogo {model.Titulo} não foi encontrado no banco de dados");

            jogo.Titulo = model.Titulo;
            jogo.Genero = model.Genero;
            jogo.Desenvolvedora = model.Desenvolvedora;
            jogo.DataLancamento = model.DataLancamento;
            jogo.Avaliacao = model.Avaliacao;

            _context.Jogoss.Update(jogo);
            await _context.SaveChangesAsync();
            return jogo;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao atualizar o jogo {model.Titulo}: {ex.Message}");
            throw new Exception("Erro . Por favor, tente novamente.", ex);
            
        }
    }
}