using Filmes_Jogos.Models;
using Filmes_Jogos.service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Filmes_Jogos.Controllers
{
    public class LoginController : Controller
    {

        private readonly ILoginRepository _iloginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _iloginRepository = loginRepository;
        }

        /// <summary>
        /// Método para verificar o login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [Route("Login/GetLogin")]
        public async Task<IActionResult> GetLogin(LoginModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var usuario =  _iloginRepository.BuscarLogin(model.Login);

                    if(usuario != null)
                    {

                        if (usuario.SenhaValida(model.Senha))
                        {
                            return RedirectToAction("Index", "Jogo");
                        }

                        ModelState.AddModelError(string.Empty, "Email ou Senha inválida. Por favor, tente novamente.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Email ou Senha inválida. Por favor, tente novamente.");
                    }
                }

                return RedirectToAction("Index","Curriculo", model);
            }
            catch (Exception erro)
            {
                throw;
            }
        }
    }
}
