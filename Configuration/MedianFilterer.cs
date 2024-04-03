namespace Configuration;

class MedianFilterer : IFilter
{
    private IConfigurator _config;
    public int Treshold { get; set; }
    public MedianFilterParamter FilterParamter { get; set; }

    public MedianFilterer(IConfigurator config, object filterParamter)
    {
        FilterParamter = (MedianFilterParamter)filterParamter;
        _config = config;
        Treshold = _config.Get<int>("MedianTreshold");
    }

    public object Apply(object data)
    {
        return default;
    }
}