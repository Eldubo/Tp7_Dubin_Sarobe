using System.Data.SqlClient;
using Dapper;

static class BD{
    private static string connectionString = @"Server=localhost; DataBase=Preguntados;TrustedConnection=True";

    static List<Categorias> ObtenerCategorias(){
        using(SqlConnection db = new SqlConnection(connectionString)){
            string sql = "SELECT * FROM Categorias";
            return db.Query<Categorias>(sql).ToList();
        }
    }

    static List<Dificultades> ObtenerDificultades(){
        using(SqlConnection db = new SqlConnection(connectionString)){
            string sql = "SELECT * FROM Dificultades";
            return db.Query<Dificultades>(sql).ToList();
        }
    }

    static List<Preguntas> ObtenerPreguntas(int dificultad, int categoria){ // corregir aca segun consigna
        if (dificultad == -1)
        {
            using(SqlConnection db = new SqlConnection()){
                string sql = "SELECT * FROM Preguntas GROUP BY Dificultad";
                return db.Query<Preguntas>(sql, new {categoria}).ToList();
            }
            else if (categoria == -1)
            {
                using(SqlConnection db = new SqlConnection()){
                    string sql = "SELECT * FROM Preguntas GROUP BY Categorias";
                    return db.Query<Preguntas>(sql, new {dificultad}).ToList();
                }
        }
        using(SqlConnection db = new SqlConnection(connectionString)){
            string sql = "SELECT * FROM Preguntas WHERE Dificultad = @dificultad AND Categorias = @categoria";
            return db.Query<Preguntas>(sql, new {dificultad, categoria}).ToList();
        }
    }

    static List<Respuestas> ObtenerRespuestas(int idPregunta){
        using(SqlConnection db = new SqlConnection(connectionString)){
            string sql = "SELECT * FROM Respuestas WHERE Preguntas = @idPregunta";
            return db.Query<Respuestas>(sql, new {idPregunta}).ToList();
        }
    }
}