public class FilmeModel{
    public Guid Id { get; set; }
    public string? Titulo { get; set; }
    public string? Genero { get; set; }
    public DateTime DataLancamento { get; set; }
    public int Avaliacao { get; set; }

    public ICollection<JogosFilmesModel>? JogosFilmes { get; set; }

    public FilmeModel()
    {
    }

    public FilmeModel(string titulo, string genero,  DateTime dataLancamento, int avaliacao)
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
        Genero = genero;
        DataLancamento = dataLancamento;
        Avaliacao = avaliacao;
    }
}