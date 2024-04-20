public class JogosFilmesModel
{

    public int Id { get; set; }
    public int JogoId { get; set; }
    public JogoModel? Jogo { get; set; }

    public int FilmeId { get; set; }
    public FilmeModel? Filme { get; set; }
}