using System.ComponentModel.DataAnnotations;

public class JogoModel{
    public Guid Id { get; set; }
    public string? Titulo { get; set; }
    public string? Genero { get; set; }
    public string? Desenvolvedora { get; set; }
    public DateTime DataLancamento { get; set; }
    public int Avaliacao { get; set; }

    


    public ICollection<JogosFilmesModel>? JogosFilmes { get; set; }

    public JogoModel()
    {
    }

    public JogoModel(string titulo, string genero, string desenvolvedora, DateTime dataLancamento, int avaliacao)
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
        Genero = genero;
        Desenvolvedora = desenvolvedora;
        DataLancamento = dataLancamento;
        Avaliacao = avaliacao;
    }
}