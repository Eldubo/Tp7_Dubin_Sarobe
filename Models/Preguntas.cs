 public class Preguntas
{
    public int IdPregunta { get; set; }
    public int IdCategoria { get; set; }
    public int IdDificultad { get; set; }
    public string Enunciado { get; set; }
    public string Foto { get; set; }
    
    public Preguntas(){}
    public Preguntas (string enunciado, string foto)
    {
        Enunciado = enunciado;
        Foto = foto;
    }
}