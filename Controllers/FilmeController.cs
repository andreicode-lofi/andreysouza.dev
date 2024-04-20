using Microsoft.AspNetCore.Mvc;

public class FilmeController : Controller
{
    private readonly IFilmesRepository _ifilmeRespository;

    public FilmeController(IFilmesRepository filmesRepository)
    {
        _ifilmeRespository = filmesRepository;
    }


    /// <summary>
    /// Método para popular a lista de filme.
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    ///
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            var filme = await _ifilmeRespository.GetAllFilmes();
            return View(filme);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao carregar a página Index: {ex.Message}");
            return View();
        }
        
    }

    /// <summary>
    /// Método para criar um filme
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    ///
    [HttpPost]
    [Route("Filme/Crate")]
    public async Task<IActionResult> Create(IFormCollection form)
    {
        try
        {
            FilmeModel model = new FilmeModel
            {
                Titulo = form["Create_Titulo"],
                Genero = form["Create_Genero"],
                DataLancamento = DateTime.Parse(form["Create_DataLancamento"]),
                Avaliacao = int.Parse(form["Create_Avaliacao"])

            };

            var jogo = await _ifilmeRespository.addFilme(model);
            return RedirectToAction("Index");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao criar o filme: {ex.Message}");
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
    [Route("Filme/Edit/{id}")]
    public async Task<IActionResult>Edit(Guid id)
    {
        try
        {
            var filme = await _ifilmeRespository.GetById(id);

            if (filme == null)
            {
                return NotFound();
            }

            var filmeModel = new FilmeModel
            {
                Id = filme.Id,
                Titulo = filme.Titulo,
                Genero = filme.Genero,
                DataLancamento = filme.DataLancamento,
                Avaliacao = filme.Avaliacao

            };

            return Json(filmeModel);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao editar o filme com o ID {id}: {ex.Message}");
            return RedirectToAction("Index");
        }
    }

    /// <summary>
    /// Método para editar um filme.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    ///
    [HttpPost]
    [Route("Filme/Edit")]
    public async Task<IActionResult> Edit(FilmeModel model)
    {
        try
        {
            var filme = await _ifilmeRespository.UpdateFilme(model);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao editar o filme com o ID {model.Id}: {ex.Message}");
            return RedirectToAction("Index");
        }
    }

    /// <summary>
    /// Método para deletar um filme.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    ///
    [HttpDelete]
    [Route("Filme/Delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var filme = await _ifilmeRespository.RemoveFilme(id);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao remouver o filme com o ID {id}: {ex.Message}");
            return RedirectToAction("Index");
        }
    }
}