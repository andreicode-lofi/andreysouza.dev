using Filmes_Jogos.Models;
using Filmes_Jogos.service.Interface;

namespace Filmes_Jogos.service
{
    public class LoginRepository : ILoginRepository
    {
        private readonly appDbContext _context;

        public LoginRepository(appDbContext context)
        {
            _context = context;
        }

        public  LoginModel BuscarLogin(string login)
        {
            return _context.Login.FirstOrDefault(x => login.ToUpper() == login.ToUpper());
        }
    }
}
