using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdStore.Communication.Responses;
public class ResponseMovieByCategoryJson
{
    public int FilmId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ReleaseYear { get; set; }
    public string Language { get; set; } = string.Empty;
    public double ReplacementCost { get; set; }
    public string NameCategory { get; set; } = string.Empty;
}
