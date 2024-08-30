 public class Juego
{
    static private string Username {get; set;}
    static private int PuntajeActual {get; set;}
    static private int ContadorPreguntaActual {get; set;}
    static private int CantidadPreguntasCorrectas {get; set;}
    static private List<Pregunta> ListaPreguntas;
    static private List<Respuesta> ListaRespuestas;

    public Juego(){ }
    public Juego (string username, int puntajeActual, int contadorPuntajeActual, int cantidadPreguntasCorrectas)
    {
        Username = username; 
        PuntajeActual = puntajeActual; 
        ContadorPreguntaActual = contadorPuntajeActual; 
        CantidadPreguntasCorrectas = cantidadPreguntasCorrecta;
    }
}
