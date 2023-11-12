﻿using AyniBackendWeb.Security.Resources;

namespace AyniBackendWeb.Ayni.Resources;

public class ProfitResource
{
    public int Id { get; set; }
    public string NameP { get; set; }
    public string DescriptionP { get; set; }
    public int AmountP { get; set; }
    
    public UserResource User { get; set; }
}