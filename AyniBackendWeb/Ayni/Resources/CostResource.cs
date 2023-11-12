using AyniBackendWeb.Security.Resources;

namespace AyniBackendWeb.Ayni.Resources;

public class CostResource
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Amount { get; set; }
    
    public UserResource User { get; set; }
}