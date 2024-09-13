using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;   
using Dapper;

static class BD{
    private static string connectionString = @"Server=localhost; DataBase=Preguntados;Trusted_Connection=True";

    public static List<Categorias> ObtenerCategorias(){
        using(SqlConnection db = new SqlConnection(connectionString)){
            string sql = "SELECT * FROM Categorias";
            return db.Query<Categorias>(sql).ToList();
        }
    }

    public static List<Dificultades> ObtenerDificultades(){
        using(SqlConnection db = new SqlConnection(connectionString)){
            string sql = "SELECT * FROM Dificultades";
            return db.Query<Dificultades>(sql).ToList();
        }
    }

    public static List<Preguntas> ObtenerPreguntas(int dificultad, int categoria){
        string sql = "";
        using(SqlConnection db = new SqlConnection(connectionString)){
            if (dificultad == -1 && categoria == -1){
                 sql = "SELECT * FROM Preguntas";}
            
            else if (dificultad == -1){
                 sql = "SELECT * FROM Preguntas WHERE Categorias = @categoria";
        }
        else if (categoria == -1){
                 sql = "SELECT * FROM Preguntas WHERE Dificultad = @dificultad";
            }
            else{
                 sql = "SELECT * FROM Preguntas WHERE Categorias = @categoria AND Dificultad = @dificultad";
            }
            return db.Query<Preguntas>(sql, new {dificultad, categoria}).ToList();
        }
        
    }

    public static List<Respuestas> ObtenerRespuestas(int idPregunta){
        using(SqlConnection db = new SqlConnection(connectionString)){
            string sql = "SELECT * FROM Respuestas WHERE Preguntas = @idPregunta";
            return db.Query<Respuestas>(sql, new {idPregunta}).ToList();
        }
    }
}
