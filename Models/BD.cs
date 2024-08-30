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













}