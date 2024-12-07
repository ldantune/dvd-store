using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdStore.Domain.Repositories.Film;
public interface IFilmCategory
{
    Task<IList<Entities.MovieByCategory>> GetMoviesByCategoryAsync(int category_id);
}
