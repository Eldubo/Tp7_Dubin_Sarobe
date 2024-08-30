 public class Juego
{
    static private string Username {get; set;}
    static private int PuntajeActual {get; set;}
    static private int ContadorPreguntaActual {get; set;}
    static private int CantidadPreguntasCorrectas {get; set;}
    static private List<Preguntas> ListaPreguntas = new List<Preguntas>();
    static private List<Respuestas> ListaRespuestas = new List<Respuestas>();

    static void IniciarJuego(){
        Username = "";
        PuntajeActual = 0;
        CantidadPreguntasCorrectas = 0;
    }
    static List<Categorias> ObtenerCategorias(){
        return BD.ObtenerCategorias();
}

static List<Dificultades> ObtenerDificultades(){
    return BD.ObtenerDificultades();
}

static void CargarPartida(string username, int dificultad, int categoria){ // preguntar a la profe
    ListaPreguntas = BD.ObtenerPreguntas(dificultad, categoria);
    ListaRespuestas = BD.ObtenerRespuestas();
}

static string ObtenerProximaPregunta()
{
    List<Preguntas> preguntas = BD.ObtenerPreguntas();
    Random random = new Random();
    int indiceAleatorio = random.Next(preguntas.Count);
    return preguntas[indiceAleatorio].Enunciado;
}

static List<Respuestas> ObtenerProximasRespuestas(int idPregunta){
    return BD.ObtenerRespuestas(idPregunta);
}

static bool ValidarRespuesta(int idPregunta, int idRespuesta ){
    bool respuesta = false;
    if (){
}