using FluentAssertions;
using RodriBus.MartianRobots.Domain;
using System;
using System.ComponentModel;
using Xunit;

namespace RodriBus.MartianRobots.UnitTests.Domain
{
    public class CoordinatesTest
    {
        [Fact]
        public void ShouldImplementEquals()
        {
            // Arrange
            var arrange = new CoordinatesViewModel(1, 2, 3);
            var expected = new CoordinatesViewModel(1, 2, 3);

            // Assert
            arrange.Equals(expected).Should().BeTrue();
        }

        [Theory]
        [InlineData(1, 2, 3, 1, 1, 1, 2, 3, 4)]
        [InlineData(1, 0, 0, 1, 0, 0, 2, 0, 0)]
        [InlineData(0, 1, 0, 0, 1, 0, 0, 2, 0)]
        [InlineData(0, 0, 1, 0, 0, 1, 0, 0, 2)]
        public void ShouldImplementSumOperator(int xA, int yA, int zA, int xB, int yB, int zB, int xR, int yR, int zR)
        {
            // Act
            var result = new CoordinatesViewModel(xA, yA, zA) + new CoordinatesViewModel(xB, yB, zB);
            // Assert
            result.Should().Be(new CoordinatesViewModel(xR, yR, zR));
        }

        [Fact]
        public void ShouldImplementEqualsOperator()
        {
            // Arrange
            var arrange = new CoordinatesViewModel(1, 2, 3);
            var expected = new CoordinatesViewModel(1, 2, 3);

            // Act
            var result = arrange == expected;

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldImplementNotEqualsOperator()
        {
            // Arrange
            var arrange = new CoordinatesViewModel(1, 2, 3);
            var expected = new CoordinatesViewModel(3, 2, 1);

            // Act
            var result = arrange != expected;

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        [Description("The maximum value for any coordinate is 50.")]
        public void ShouldNotAllowOverMax()
        {
            // Act
            Action act = () => new CoordinatesViewModel(CoordinatesViewModel.Max + 1, 0, 0);

            // Assert
            act.Should().Throw<ArgumentException>();

            // Act
            act = () => new CoordinatesViewModel(0, CoordinatesViewModel.Max + 1, 0);

            // Assert
            act.Should().Throw<ArgumentException>();

            // Act
            act = () => new CoordinatesViewModel(0, 0, CoordinatesViewModel.Max + 1);

            // Assert
            act.Should().Throw<ArgumentException>();
        }
    }
}