using DvdStore.Communication.Responses.Language;

namespace DvdStore.Communication.Responses.Film;

public class ResponseFilmJson
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
    public DateTime LastUpdate { get; set; }
    public string ?FullText { get; set; }
    public ResponseLanguageJson Language { get; set; } = null!;
}
