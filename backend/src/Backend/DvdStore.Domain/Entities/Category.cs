﻿
namespace DvdStore.Domain.Entities;
public class Category
{
    public int CategoryId { get; set; }
    public string ?Name { get; set; } 
    public string LastUpdate { get; set; } = string.Empty;
}
