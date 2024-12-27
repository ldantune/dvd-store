using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DvdStore.Domain.Entities;

public class Actor
{
    public int ActorId { get; set; }
    public string ?FirstName { get; set; }
    public string ?LastName { get; set; }
    public string LastUpdate { get; set; } = string.Empty;
}
