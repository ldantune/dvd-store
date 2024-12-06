using System.Net;


namespace DvdStore.Exceptions.ExceptionBase;
public abstract class DvdStoreException : SystemException
{
    public DvdStoreException(string message) : base(message) { }

    public abstract IList<string> GetErrorMessages();
    public abstract HttpStatusCode GetStatusCode();
}
