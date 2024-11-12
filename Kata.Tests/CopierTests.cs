using NSubstitute;
using NUnit.Framework;

namespace Kata.Tests;

public class CopierTests
{
    [Test]
    public void Copy_GivenNoCharsToCopy_ShouldNotCopyAnything()
    {
        // Arrange
        var source = Substitute.For<ISource>();
        var destination = Substitute.For<IDestination>();
        var copier = new Copier(source, destination);

        source.ReadChar().Returns('\n');

        // Act
        copier.Copy();
        // Assert
        destination.DidNotReceive().WriteChar(Arg.Any<char>());
    }    
}

public class Copier(ISource source, IDestination destination)
{
    internal void Copy()
    {
        
    }
}

public interface ISource
{
    char ReadChar();
}

public interface IDestination
{
    void WriteChar(char charToCopy);
}