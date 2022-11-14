using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.Test
{
    public class HighScoreTest
    {
        [Test]
        public void UpdateScore_WhenScoreNameIsNew_ShouldAddNewEntry() {
            // Arrange
            Score myScore = new Score("Test", 123);

            HighScores sut = new(new Score[] { });
            sut.Count.Should().Be(0);
            
            // Act
            sut.Add(myScore);

            // Assert
            sut.Count.Should().Be(1);
        }

        [Test]
        public void UpdateScore_WhenScoreNameIsExisting_ShouldNotAddNewEntry() {
            // Arrange
            Score myScore = new Score("Test", 123);

            HighScores sut = new(new Score[] { });
            sut.Count.Should().Be(0);

            // Act
            sut.Add(myScore);
            sut.Add(myScore);
            
            // Assert
            sut.Count.Should().Be(1);
        }


        [Test]
        public void UpdateScore_WhenScoreNameIsExisting_ShouldUpdateScorePointsIfGreater() {
            // Arrange
            Score myScore = new Score("Test", 123);
            HighScores sut = new(new Score[] { });
            sut.Add(myScore);
            
            // Act
            myScore.Points = 5555;
            sut.Add(myScore);

            // Assert
            sut.First().Points.Should().Be(5555);
        }

        [Test]
        public void DeleteScore_WhenScoreDoesNotExisit_ShouldReturnFalse() {
            // Arrange
            Score myScore = new Score("Test", 123);
            HighScores sut = new(new Score[] { });
            
            //Act
            bool result = sut.Remove(myScore);
            
            //Assert
            result.Should().BeFalse();
        }

        [Test]
        public void DeleteScore_WhenScoreDoesExisit_ShouldReturnRemoveItAndReturnTrue() {
            // Arrange
            Score myScore = new Score("Test", 123);
            HighScores sut = new(new Score[] { });
            sut.Add(myScore);

            //Act
            bool result = sut.Remove(myScore);
            
            //Assert
            result.Should().BeTrue();
            sut.Count.Should().Be(0);
        }

    }
}
