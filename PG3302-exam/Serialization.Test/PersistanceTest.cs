using FluentAssertions;
using Moq;
using System.IO.Abstractions;
using static System.Formats.Asn1.AsnWriter;

namespace Serialization.Test
{
    public class PersistanceTest
    {

        [Test]
        public void LoadHighScores_WhenFileIsEmpty_ShouldReturnEmptyHighscore() {
            // Arange
            Mock<IFileSystem> fileSystem = new Mock<IFileSystem>();
            fileSystem.Setup(
                f => f.File.ReadAllText( It.IsAny<string>() )
                ).Returns("");

            IPersistance sut = new JsonPersistance("", fileSystem.Object);

            // Act
            HighScores highScores = sut.LoadHighScores();

            // Assert
            highScores.Should().Equal(new List<Score>());
        }

        [Test]
        public void LoadHighScores_WhenContainsAScore_ShouldReturnListWithThatScore() {
            // Arange
            Mock<IFileSystem> fileSystem = new Mock<IFileSystem>();
            fileSystem.Setup(
                f => f.File.Exists(It.IsAny<string>())
                ).Returns(true);

            fileSystem.Setup(
                f => f.File.ReadAllText( It.IsAny<string>(), It.IsAny<System.Text.Encoding>() )
                ).Returns("[{\"Name\":\"Martin\",\"Points\":50}]");

            IPersistance sut = new JsonPersistance("", fileSystem.Object);

            // Act
            HighScores highScores = sut.LoadHighScores();

            // Assert
            highScores.First().Should().Be(new Score("Martin", 50));
        }
    }
}