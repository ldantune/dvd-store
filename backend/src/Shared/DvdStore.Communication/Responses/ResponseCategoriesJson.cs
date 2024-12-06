using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdStore.Communication.Responses;
public class ResponseCategoriesJson
{
    public IList<ResponseCategoryJson> Categories { get; set; } = [];
}
