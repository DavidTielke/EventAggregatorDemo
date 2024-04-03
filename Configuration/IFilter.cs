namespace Configuration;

public interface IFilter
{
    object Apply(object data);
}