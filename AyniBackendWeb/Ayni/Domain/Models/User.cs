namespace AyniBackendWeb.Ayni.Domain.Models;

public class User
{
    public int Id {get; set;}
    public string Name {get; set;}
    
    public IList<Crop> Crops { get; set; } = new List<Crop>();
}