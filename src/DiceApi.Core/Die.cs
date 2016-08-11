using System;

namespace DiceApi.Core
{
    public class Die
    {
        /// <summary>
        /// Instance of Random that we'll instantiate with the die 
        /// and use within the Roll() method.
        /// </summary>
        private readonly Random rng;

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

            this.rng = new Random();
        }

        /// <summary>
        /// Gets the number of sides on the die.
        /// </summary>
        /// <returns></returns>
        public int Sides { get; }

        /// <summary>
        /// Rolls the die, returning its value.
        /// </summary>
        /// <returns>Result of die roll.</returns>
        public int Roll() 
        {
            // Range for Next() is inclusive on the minimum, exclusive on the maximum
            return rng.Next(1, this.Sides + 1);
        }
    }
}
