namespace AdofaiBin.Serialization.Encoding.Exception;

public class EncodingFutureVersionException : EncodingException
{
    public EncodingFutureVersionException(int version) : base($"The provided data is from a future version \"{version}\" which is not supported by this encoder.")
    {
    }
}