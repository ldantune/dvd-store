using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DvdStore.Communication.Responses.Actors;

public class ResponseActorJson
{
    public int ActorId { get; set; }
    public string ?FirstName { get; set; }
    public string ?LastName { get; set; }
    public string LastUpdate { get; set; } = string.Empty;
}
