using Newtonsoft.Json.Linq;

namespace AdofaiBin.Serialization.Schema;

public interface IMigration
{
    public EventType[] EventTypes { get; }
    public void Migrate(JObject obj);
}