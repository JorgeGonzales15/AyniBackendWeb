using Swashbuckle.AspNetCore.Annotations;

namespace AyniBackendWeb.Ayni.Resources;

[SwaggerSchema(Required = new []{"Name"})]
public class SaveCostResource
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Amount { get; set; }
    public int UserId { get; set; }
}