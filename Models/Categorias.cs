    public class Categorias
{
    public int IdCategoria { get; set; }
    public string Nombre { get; set; }
    public string Foto { get; set; }
    
    public Categorias(){ }
    public Categorias(string nombre, string foto)
    {
        Nombre = nombre;
        Foto = foto;
    }
}