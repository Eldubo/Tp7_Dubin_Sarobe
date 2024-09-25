using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace PreguntadOrt.Controllers;

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
    public IActionResult ConfigurarJuego()
    {
        ViewBag.ListaCategorias = Juego.ObtenerCategorias();
        ViewBag.ListaDificultades = Juego.ObtenerDificultades();
        return View();
    }
     public IActionResult Comenzar(string username, int dificultad, int categoria)
    {
        Juego.CargarPartida(username, dificultad, categoria);
        ViewBag.Username=username;
        ViewBag.Dificultad=dificultad;
        ViewBag.Categoria=categoria;
        return View("Comenzar");
    }
    public IActionResult Jugar()
    {
        ViewBag.Username=Juego.Usuario;
        if (Juego.CantidadPreguntas()>0)
        {
        
            ViewBag.Pregunta = Juego.ObtenerProximaPregunta();        
            ViewBag.ListaRespuestas = Juego.ObtenerProximasRespuestas(ViewBag.Pregunta.IdPregunta);       
                 
            return View();
        }
        else
        {
            return View("Comenzar");
        }
    }
    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        ViewBag.EsCorrecta = Juego.VerificarRespuesta(idRespuesta);
        ViewBag.PuntajeActual=Juego.PuntajeActual;
        ViewBag.RespuestaCorrecta=Juego.RespuestaCorrecta(idPregunta);
        ViewBag.Pregunta = Juego.ObtenerProximaPregunta();
        
        return View("Respuesta");
    }
        public IActionResult Creditos()
    {
        return View();
    }

}