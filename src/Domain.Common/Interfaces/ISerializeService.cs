namespace Luna.Core.Domain.Common.Interfaces
{
    public interface ISerializeService : ITransientService
    {
        string Serialize<T>(T obj);

        string Serialize<T>(T obj, Type type);

        T Deserialize<T>(string text);
    }
}
