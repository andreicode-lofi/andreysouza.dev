public interface IFilmesRepository
{
    Task<List<FilmeModel>> GetAllFilmes();
    Task<FilmeModel> addFilme(FilmeModel model);
    Task<FilmeModel> GetById(Guid id);
    Task<bool> RemoveFilme (Guid id);
    Task<FilmeModel> UpdateFilme(FilmeModel model);
    

}