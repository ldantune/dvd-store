using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdStore.Communication.Responses;
public class ResponseErrorJson
{
    public IList<string> Errors { get; set; }
    public bool TokenIsExpired { get; set; }
    public ResponseErrorJson(IList<string> errors) => Errors = errors;
    public ResponseErrorJson(string errors)
    {
        Errors = [errors];
    }
}
