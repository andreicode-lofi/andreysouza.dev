public interface IJogosRepository
{
    Task<List<JogoModel>> GetAllJogos();
    Task<JogoModel> AddJogo (JogoModel model);
    Task<JogoModel> GetbyId(Guid id);
    Task<JogoModel> UpDateJogos(JogoModel model);
    Task<bool> RemoveJogo(Guid id);


}