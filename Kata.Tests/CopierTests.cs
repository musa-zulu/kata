using Kata.Shared.Interfaces;
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



