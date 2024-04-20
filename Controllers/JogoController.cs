using Microsoft.AspNetCore.Mvc;
using System;

public class JogoController : Controller
{
    private readonly IJogosRepository _ijogosRepository;

    public JogoController(IJogosRepository ijogosRepository)
    {
        _ijogosRepository = ijogosRepository;
    }


    /// <summary>
    /// Método para popular a lista de jogos.
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    ///
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            var jogos = await _ijogosRepository.GetAllJogos();
            return View(jogos);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao carregar a página Index: {ex.Message}");
            return View();
        }
        
    }

    /// <summary>
    /// Método para criar um jogo
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    ///
    [HttpPost]
    [Route("Jogo/Create")]
    public async Task<IActionResult> Create(IFormCollection form)
    {
        try
        {
            JogoModel model = new JogoModel
            {
                Titulo = form["Create_Titulo"],
                Genero = form["Create_Genero"],
                Desenvolvedora = form["Create_Desenvolvedora"],
                DataLancamento = DateTime.Parse(form["Create_DataLancamento"]),
                Avaliacao = int.Parse(form["Create_Avaliacao"])

            };

            var jogo = await _ijogosRepository.AddJogo(model);
            return RedirectToAction("Index");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao criar o jogo: {ex.Message}");
            return RedirectToAction("Index");

        }
    }

    /// <summary>
    /// Método para popular a modal editar
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    ///
    [HttpGet]
    [Route("Jogo/Edit/{id}")]
    public async Task<IActionResult>Edit(Guid id)
    {
        try
        {
            var jogo = await _ijogosRepository.GetbyId(id);

            if (jogo == null)
            {
                return NotFound();
            }

            var jogoModel = new JogoModel
            {
                Id = jogo.Id,
                Titulo = jogo.Titulo,
                Genero = jogo.Genero,
                Desenvolvedora = jogo.Desenvolvedora,
                DataLancamento = jogo.DataLancamento,
                Avaliacao = jogo.Avaliacao
            };

            return Json(jogoModel);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao editar o jogo com o ID {id}: {ex.Message}");
            return RedirectToAction("Index");
        }
    }

    /// <summary>
    /// Método para editar um jogo.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    ///
    [HttpPost]
    [Route("Jogo/Edit")]
    public async Task<IActionResult> Edit(JogoModel model)
    {
        try
        {
            var jogo = await _ijogosRepository.UpDateJogos(model);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
           Console.WriteLine($"Ocorreu um erro ao editar o jogo com o ID {model.Id}: {ex.Message}");
           return RedirectToAction("Index");
        }
    }

    /// <summary>
    /// Método para deletar um jogo.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    ///
    [HttpDelete]
    [Route("Jogo/Delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var jogo = await _ijogosRepository.RemoveJogo(id);

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao excluir o jogo com o ID {id}: {ex.Message}");
            return RedirectToAction("Index");
        }
    }
}
