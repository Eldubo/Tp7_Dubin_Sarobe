namespace PreguntadOrt;

static public class Juego
{
    static public string Usuario;
    static public int PuntajeActual;
    static private int CantCorrectas;
    static private int ContadorNroPreguntaActual;
    static private Preguntas PreguntaActual;
    static private List<Preguntas> ListaPreguntas;
    static private List<Respuestas> ListaRespuestas;


    static private void InicializarJuego(string user)
    {
        Usuario = user;
        PuntajeActual = 0;
        CantCorrectas = 0;
        ContadorNroPreguntaActual = 0;
        PreguntaActual = null;
        ListaPreguntas = null; 
        ListaRespuestas = null;
    }

    static public List<Categorias> ObtenerCategorias()
    {
        return(BD.ObtenerCategorias());
    }

    static public List<Dificultades> ObtenerDificultades()
    {
        return(BD.ObtenerDificultades());
    }

    static public void CargarPartida(string username, int dificultad, int categoria)
    {
        InicializarJuego(username);
        ListaPreguntas = BD.ObtenerPreguntas(dificultad, categoria);
    }

    static public Preguntas ObtenerProximaPregunta()
    {
        PreguntaActual = ListaPreguntas[ContadorNroPreguntaActual];
        return PreguntaActual;
    }

    static public List<Respuestas> ObtenerProximasRespuestas(int idPregunta)
    {
        ListaRespuestas = BD.ObtenerRespuestas(idPregunta);
        return ListaRespuestas;
    }

    public static bool VerificarRespuesta (int Idrespuesta)
    {
        bool Respuestas = false;
        foreach (Respuestas rta in ListaRespuestas)
        {
            if (rta.IdRespuesta == Idrespuesta)
            {
                Respuestas = true;

                    if(PreguntaActual.IdDificultad == 1)
                    {
                        PuntajeActual+=150;
                    }
                    else if(PreguntaActual.IdDificultad == 2)
                    {
                        PuntajeActual+=300;
                    }
                    else
                    {
                        PuntajeActual+=500;
                    }
                    CantCorrectas++;


            }
        }   
        ContadorNroPreguntaActual++;
        PreguntaActual = ListaPreguntas[ContadorNroPreguntaActual];
        return Respuestas;


    }  
    public static int ObtenerPuntaje(int PuntajeActual)
    {
        return PuntajeActual;
    }
    public static int CantidadPreguntas()
    {
        return ListaPreguntas.Count;
    }

    public static string RespuestaCorrecta(int idPregunta)
    {
        string Respuesta=null;
        Respuesta=BD.CualEsCorrecta(idPregunta);
        return Respuesta;
    }
}