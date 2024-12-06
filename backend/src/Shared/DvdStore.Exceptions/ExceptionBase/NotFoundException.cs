using System.Net;

namespace DvdStore.Exceptions.ExceptionBase;
public class NotFoundException : DvdStoreException
{
    public NotFoundException(string message) : base(message)
    {
    }

    public override IList<string> GetErrorMessages() => [Message];

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.NotFound;
}
