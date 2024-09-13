using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimerProyecto.Models;

namespace PrimerProyecto.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ConfigurarJuego(){
        ViewBag.Categorias = Juego.ObtenerCategorias();
        ViewBag.Dificultades = Juego.ObtenerDificultad();
        return View();
    }
    
    public IActionResult Comenzar(string username, int dificultad, int categoria){
        Juego.CargarPartida(username, dificultad, categoria);
        return RedirectToAction("Jugar");
    }

    public IActionResult Jugar(int idpregunta, int dificultad, int categoria){
        ViewBag.PreguntaActual = Juego.ObtenerProximaPregunta(dificultad, categoria);
        ViewBag.PosiblesRespuestas = Juego.ObtenerProximasRespuestas(idpregunta);
        return View();
    }
    [HttpPost] public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta){
        Juego.ObtenerProximasRespuestas(idPregunta);
        Juego.VerificarRespuesta(idRespuesta);
        return View();
    }
}
