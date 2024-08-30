 public class Juego
{
    static private string Username {get; set;}
    static private int PuntajeActual {get; set;}
    static private int ContadorPreguntaActual {get; set;}
    static private int CantidadPreguntasCorrectas {get; set;}
    static private List<Pregunta> ListaPreguntas = new List<Pregunta>();
    static private List<Respuesta> ListaRespuestas = new List<Respuesta>();

    public Juego(){ }
    public Juego (string username, int puntajeActual, int contadorPuntajeActual, int cantidadPreguntasCorrectas)
    {
        Username = username; 
        PuntajeActual = puntajeActual; 
        ContadorPreguntaActual = contadorPuntajeActual; 
        CantidadPreguntasCorrectas = cantidadPreguntasCorrecta;
    }

    static void IniciarJuego(){
        username = "";
        puntajeActual = 0;
        cantidadPreguntasCorrectas = 0;
    }
    static List<Categorias> ObtenerCategorias(){
        return BD.ObtenerCategorias();
}

static List<Dificultades> ObtenerDificultades(){
    return BD.ObtenerDificultades();
}

static void CargarPartida(string username, int dificultad, int categoria){
    var _preguntas = BD.ObtenerPreguntas(dificultad, categoria);
    var _respuestas = BD.ObtenerRespuestas();
}

static string ObtenerProximaPregunta(){
    List<Preguntas> preguntas = new list<Preguntas>();
        preguntas = BD.ObtenerPreguntas();
        random random = new random(1, preguntas.count);
        return preguntas[random].Enunciado;
}

static List<Respuestas> ObtenerProximasRespuestas(int idPregunta){
    return BD.ObtenerRespuestas(idPregunta);
}

static bool ValidarRespuesta(int idPregunta, int idRespuesta ){
    
}