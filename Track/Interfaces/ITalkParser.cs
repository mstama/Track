using Track.Models;

namespace Track.Interfaces
{
    public interface ITalkParser
    {
        Talk Parse(string text);
    }
}