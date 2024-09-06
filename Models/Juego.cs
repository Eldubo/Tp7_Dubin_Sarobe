 public class Juego
{
    static private string Username {get; set;}
    static private int PuntajeActual {get; set;}
    static private int ContadorNroPreguntaActual {get; set;}
    static private int CantidadPreguntasCorrectas {get; set;}
    static private Preguntas PreguntaActual {get;set;}
    static private List<Preguntas> ListaPreguntas = new List<Preguntas>();
    static private List<Respuestas> ListaRespuestas = new List<Respuestas>();

    public static void InicializarJuego(){
        Username = "";
        PuntajeActual = 0;
        CantidadPreguntasCorrectas = 0;
        ContadorNroPreguntaActual = 0;
        PreguntaActual = null;
        ListaPreguntas = null;
        ListaRespuestas = null;
    }
    public static void InicializarJuego(string username){
        Username = username;
        PuntajeActual = 0;
        CantidadPreguntasCorrectas = 0;
        ContadorNroPreguntaActual = 0;
        PreguntaActual = null;
        ListaPreguntas = null;
        ListaRespuestas = null;
    }

    static List<Categorias> ObtenerCategorias(){
        return BD.ObtenerCategorias();
    }
    static List<Dificultades> ObtenerDificultad(){
        return BD.ObtenerDificultades();
    }
    public static void CargarPartida(string username, int dificultad, int categoria){
    InicializarJuego(username);
    ListaPreguntas = BD.ObtenerPreguntas(dificultad, categoria);
    }
    public static List<Preguntas> ObtenerProximaPregunta(int dificultad, int categoria){
        return BD.ObtenerPreguntas(dificultad, categoria);
    }
    public static List<Respuestas> ObtenerProximasRespuestas(int idPregunta){
        return BD.ObtenerRespuestas(idPregunta);
    }
    public static bool VerificarRespuesta(int idRta){
        bool Correcta = false;
        ListaRespuestas[idRta].Correcta;
        ContadorNroPreguntaActual +=1;
        if(Correcta)
        {            
            correcto = true;
        }
        return correcto;
    }
}