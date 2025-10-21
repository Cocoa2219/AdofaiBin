namespace AdofaiBin.Serialization.Encoding.Exception;

public class EncodingInvalidDataException(string message) : EncodingException(message)
{
    public EncodingInvalidDataException() : this("The provided data is invalid and cannot be encoded.")
    {
    }
}