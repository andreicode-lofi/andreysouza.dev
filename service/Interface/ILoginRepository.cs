using Filmes_Jogos.Models;

namespace Filmes_Jogos.service.Interface
{
    public interface ILoginRepository
    {
        LoginModel BuscarLogin(string login);

    }
}
