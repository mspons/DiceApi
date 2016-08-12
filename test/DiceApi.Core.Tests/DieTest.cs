using System;
using Xunit;

using DiceApi.Core;

namespace DiceApi.Core.Tests
{
    public class DieTest
    {
        /// <summary>
        /// Verifies the constructor throws an ArgumentOutOfRangeException when given 
        /// an invalid number of sides.
        /// </summary>
        [Fact]
        public void Constructor_GivenZeroSides_ThrowsException()
        {
            var exception = Record.Exception(() => new Die(0));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentOutOfRangeException>(exception);
        }

        /// <summary>
        /// Verifies that die rolls return a value within the expected range for its
        /// number of sides.
        /// </summary>
        [Fact]
        public void Roll_GivenValidSides_ReturnsValueWithinRange()
        {
            int sides = 6;
            var die = new Die(sides);

            // Naive brute force verification that we always get a correct value
            // within range.
            for (int i = 0; i < 100; i++) 
            {
                var result = die.Roll();

                Assert.True(this.WithinRange(sides, result));
            }
        }

        /// <summary>
        /// Helper method to check whether value falls within the 
        /// valid range for a die with given number of sides
        /// </summary>
        /// <param name="sides">Number of sides on die, defines max of range.</param>
        /// <param name="value">Value to check</param>
        /// <returns>True if it's a valid result for die, false otherwise.</returns>
        private bool WithinRange(int sides, int value)
        {
            if (value > 0 && value <= sides) 
            { 
                return true; 
            }

            return false;
        }
    }
}
