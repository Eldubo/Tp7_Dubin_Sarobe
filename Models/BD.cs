using System;
using System.Data.SqlClient;
using Dapper;

namespace PreguntadOrt;

static public class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=Preguntados; Trusted_Connection=true;";

    public static List<Categorias> ObtenerCategorias()
    {
        List<Categorias> Lista = null;
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            Lista = db.Query<Categorias>("SELECT * FROM Categorias").ToList();
        }       
        return Lista;
    }

    public static List<Dificultades> ObtenerDificultades()
    {
        List<Dificultades> Lista = null;
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            Lista = db.Query<Dificultades>("SELECT * FROM Dificultades").ToList();
        }       
        return Lista;
    }

    public static List<Preguntas> ObtenerPreguntas(int dificultad, int categoria)
    {
        List<Preguntas> Lista = null;
        string sql = " ";
        if(dificultad != -1 && categoria != -1)
        {
            sql = "SELECT * FROM Preguntas WHERE IdDificultad = @pDificultad and IdCategoria = @pCategoria";
        }
        else if(dificultad == -1 && categoria == -1)
        {
            sql = "SELECT * FROM Preguntas";
        }
        else if(categoria == -1)
        {
            sql = "SELECT * FROM Preguntas WHERE IdDificultad = @pDificultad";
        }
        else
        {
            sql = "SELECT * FROM Preguntas WHERE IdCategoria = @pCategoria";
        }

        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            Lista = db.Query<Preguntas>(sql, new{pDificultad = dificultad, pCategoria = categoria}).ToList();
        }       
        return Lista;
    }

    public static List<Respuestas> ObtenerRespuestas(int idPregunta)
    {
        List<Respuestas> Lista = null;
        string sql = "SELECT * FROM Respuestas WHERE IdPregunta = @pId";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            Lista = db.Query<Respuestas>(sql, new{pId = idPregunta}).ToList();
        }       
        return Lista;
    }

    public static string CualEsCorrecta(int idPregunta)
    {
        string correcta=null;
         string sql = "SELECT * FROM Respuestas  WHERE Correcta = 1 and IdPregunta = @pId";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            correcta = db.Query<string>(sql, new{pId = idPregunta}).FirstOrDefault();
        }       
        return correcta;
    }
}