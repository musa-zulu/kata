using Kata.Shared.Interfaces;

namespace Kata;

public class Copier(ISource _source, IDestination _destination)
{
    public void Copy()
    {
        char charector;

        while ((charector = _source.ReadChar()) is not '\n')
        {
            _destination.WriteChar(charector);
        }
    }
}
