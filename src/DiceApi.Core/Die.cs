using System;

namespace DiceApi.Core
{
    public class Die : IRollable
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Die" /> with a 
        /// specified number of sides.
        /// </summary>
        public Die()
        {
            this.RandomNumberGenerator = new Random();
        }

        /// <summary>
        /// Gets an instance of Random that we instantiate with the Die 
        /// constructor. This is used by Roll() to create a random value 
        /// for the die roll.
        /// </summary>
        private Random RandomNumberGenerator { get; }

        /// <summary>
        /// Rolls the die, returning its value.
        /// </summary>
        /// <param name="sides">Number of sides on the die.</param>
        /// <returns>Result of die roll.</returns>
        public int Roll(int sides) 
        {
            if (sides < 1) {
                throw new ArgumentOutOfRangeException(nameof(sides));
            }

            // Range for Next() is inclusive on the minimum, exclusive on the maximum
            return this.RandomNumberGenerator.Next(1, sides + 1);
        }
    }
}
