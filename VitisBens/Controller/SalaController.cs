using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class SalaController : Controller
{
 private static ListaSala listaDeSalas = new ListaSala();

    // Método que inicializa e carrega a lista com valores padrão, apenas uma vez
    private static void CarregaLista()
    {
        if (listaDeSalas == null || listaDeSalas.Count == 0)
        {
            listaDeSalas = new ListaSala
            {
                new Sala(1, "S1", "Sala 01", "2º andar", "Técnico"),
                new Sala(2, "S2", "Sala 02", "2º andar", "Engenharia"),
                new Sala(3, "S3", "Sala 03", "2º andar", "Servidor"),
                new Sala(4, "S4", "Sala 04", "1º andar", "Oscar"),
                new Sala(5, "S5", "Sala 05", "1º andar", "Administrativo"),
                new Sala(6, "S6", "Sala 06", "1º andar", "Sala de Reuniões"),
                new Sala(7, "S7", "Sala 07", "1º andar", "Oscar Gayer")
            };
        }
    }
    
    [HttpGet]
    [Route("sala/index")] // Define a rota para evitar conflito
    public IActionResult Index()
    {
        CarregaLista();
        return View(listaDeSalas); 
    }

    [HttpGet]
    [Route("sala/create")] // Define a rota para evitar conflito
    public IActionResult Create()
    {
        return View();
    }

[HttpPost]
[Route("sala/create")]
public IActionResult Create(Sala sala)
{
    // Verifica se já existe uma sala com o mesmo código
    if (listaDeSalas.Any(s => s.Codigo == sala.Codigo))
    {
        ModelState.AddModelError("Codigo", "Já existe uma sala com este código.");
        return View(sala); // Retorna a mesma view para o usuário corrigir o código
    }

    // Atribui o ID e adiciona a nova sala à lista
    CarregaLista();
    sala.Id = listaDeSalas.Count + 1;
    listaDeSalas.Add(sala);

    return RedirectToAction("Index"); // Redireciona para a lista de salas
}

}
