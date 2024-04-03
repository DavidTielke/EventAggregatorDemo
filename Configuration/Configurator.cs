namespace Configuration
{
    // Registrierung als Singleton

    public class Configurator : IConfigurator
    {
        private Dictionary<string, object> _items = new Dictionary<string, object>();

        public void Set(string key, object value)
        {
            _items.Add(key, value);
        }

        public TItem Get<TItem>(string key)
        {
            return (TItem)_items[key];
        }
    }
}
