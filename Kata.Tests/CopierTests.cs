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

        char empty = '\n';

        source.ReadChar().Returns(empty);

        // Act
        copier.Copy();

        // Assert
        destination.DidNotReceive().WriteChar(Arg.Any<char>());
    }

    [Test]
    public void Copy_GivenSourceContainsOnlyNewLineChar_ShouldNotWriteAnything()
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

    [Test]
    public void Copy_GivenSingleCharacterIsAvailable_ShouldWriteOneCharToTheDestination()
    {
        // Arrange 
        var source = Substitute.For<ISource>();
        var destination = Substitute.For<IDestination>();
        var copier = new Copier(source, destination);

        source.ReadChar().Returns('A', '\n');

        // Act 
        copier.Copy();

        // Assert
        destination.Received(1).WriteChar('A');
        destination.DidNotReceive().WriteChar('\n');
    }

    [Test]
    public void Copy_GivenTwoCharacterIsAvailable_ShouldWriteTwoCharToTheDestination()
    {
        // Arrange 
        var source = Substitute.For<ISource>();
        var destination = Substitute.For<IDestination>();
        var copier = new Copier(source, destination);

        source.ReadChar().Returns('A', 'B', '\n');

        // Act 
        copier.Copy();

        // Assert
        destination.Received(1).WriteChar('A');
        destination.Received(1).WriteChar('B');
        destination.DidNotReceive().WriteChar('\n');
    }

    [Test]
    public void CopyMultiple_GivenNoCharsToCopy_ShouldNotCopyAnything()
    {
        // Arrange
        var source = Substitute.For<ISource>();
        var destination = Substitute.For<IDestination>();
        var copier = new Copier(source, destination);

        char[] empty = Array.Empty<char>();

        source.ReadChars(0).Returns(empty);

        // Act
        copier.CopyMultiple(0);

        // Assert
        destination.DidNotReceive().WriteChar(Arg.Any<char>());
    }

    [Test]
    public void CopyMultiple_GivenSourceContainsOnlyNewLineChar_ShouldNotWriteAnything()
    {
        // Arrange
        var source = Substitute.For<ISource>();
        var destination = Substitute.For<IDestination>();
        var copier = new Copier(source, destination);

        source.ReadChars(0).Returns(['\n']);

        // Act
        copier.CopyMultiple(0);

        // Assert
        destination.DidNotReceive().WriteChar(Arg.Any<char>());
    }

    [Test]
    public void CopyMultiple_GivenMultipleCharactersAreAvailable_ShouldWriteMultipleCharsToTheDestination()
    {
        // Arrange 
        var source = Substitute.For<ISource>();
        var destination = Substitute.For<IDestination>();
        var copier = new Copier(source, destination);

        char[] values1 = ['Q', 'U', 'Y', 'm', 'a'];
        char[] values2 = ['i', 'o', 'M'];

        source.ReadChars(3).Returns(values1, values2, Array.Empty<char>());

        // Act 
        copier.CopyMultiple(3);

        // Assert
        Received.InOrder(() =>
        {
            destination.WriteChars(values1);
            destination.WriteChars(values2);
        });
        destination.DidNotReceive().WriteChars(Arg.Is<char[]>(x => x.Contains('\n')));
    }
}



