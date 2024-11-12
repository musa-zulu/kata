namespace Kata.Shared.Interfaces;
public interface ISource
{
    char ReadChar();

    char[] ReadChars(int size);
}