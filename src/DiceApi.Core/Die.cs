using System;

namespace DiceApi.Core
{
    public class Die
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Die" /> with a 
        /// specified number of sides.
        /// </summary>
        /// <param name="sides">Number of sides on the die.</param>
        public Die(int sides)
        {
            if (sides < 1) {
                throw new ArgumentOutOfRangeException(nameof(sides));
            }

            this.Sides = sides;

            this.RandomNumberGenerator = new Random();
        }

        /// <summary>
        /// Gets the number of sides on the die.
        /// </summary>
        /// <returns></returns>
        public int Sides { get; }

        /// <summary>
        /// Gets an instance of Random that we instantiate with the Die 
        /// constructor. This is used by Roll() to create a random value 
        /// for the die roll.
        /// </summary>
        private Random RandomNumberGenerator { get; }

        /// <summary>
        /// Rolls the die, returning its value.
        /// </summary>
        /// <returns>Result of die roll.</returns>
        public int Roll() 
        {
            // Range for Next() is inclusive on the minimum, exclusive on the maximum
            return this.RandomNumberGenerator.Next(1, this.Sides + 1);
        }
    }
}
