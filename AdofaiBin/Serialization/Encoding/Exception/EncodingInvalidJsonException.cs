namespace AdofaiBin.Serialization.Encoding.Exception;

public class EncodingInvalidJsonException(string message) : EncodingException(message)
{
    public EncodingInvalidJsonException() : this("The provided JSON is invalid and cannot be encoded.")
    {
    }
}