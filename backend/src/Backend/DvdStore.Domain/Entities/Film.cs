namespace DvdStore.Domain.Entities;

public class Film
{
    public int FilmId { get; set; }
    public string ?Title { get; set; } 
    public string ?Description { get; set; } 
    public int ReleaseYear { get; set; }
    public int LanguageId { get; set; }
    public int RentalDuration { get; set; }
    public double RentalRate { get; set; }
    public int Length { get; set; }
    public double ReplacementCost { get; set; }
    public string ?Rating { get; set; } 
    public string ?SpecialFeatures { get; set; } 
    public string LastUpdate { get; set; } = string.Empty;
    public string ?FullText { get; set; }
    public Language Language { get; set; } = null!;
}   
