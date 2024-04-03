namespace Configuration;

public interface IConfigurator
{
    void Set(string key, object value);
    TItem Get<TItem>(string key);
}