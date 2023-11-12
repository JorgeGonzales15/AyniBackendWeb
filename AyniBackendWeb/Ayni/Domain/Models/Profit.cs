﻿using AyniBackendWeb.Security.Domain.Models;

namespace AyniBackendWeb.Ayni.Domain.Models;

public class Profit
{
    public int Id { get; set; }
    public string NameP { get; set; }
    public string DescriptionP { get; set; }
    public int AmountP { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
    

}