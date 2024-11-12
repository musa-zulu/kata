using Kata.Shared.Interfaces;

namespace Kata;

public class Copier(ISource _source, IDestination _destination)
{
    public void Copy()
    {
        char character;

        while ((character = _source.ReadChar()) is not '\n')
        {
            _destination.WriteChar(character);
        }
    }

    public void CopyMultiple(int size)
    {
        char[] chars;
        do
        {
            chars = _source.ReadChars(size);

            if (chars.Length == 0)
                break;

            var newlineIndex = Array.IndexOf(chars, '\n');
            if (newlineIndex is not -1)
            {
                _destination.WriteChars(chars[..newlineIndex]);
                break;
            }

            _destination.WriteChars(chars);
        } while (chars.Length > 0);
    }
}
