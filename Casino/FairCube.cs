using System;

namespace Casino
{
    public class FairCube : ICube
    {
        private readonly Random _random = new Random();

        /// <summary>
        /// this cube have the same chance (1/6) for all numbers
        /// </summary>
        /// <returns>number between 1 to 6</returns>
        public int Toss()
        {
            //return random number between 1 to 6 (same probability for all numbers)
            return _random.Next(1, 7);
        }

        /// <summary>
        /// The Symbol for Fair cube
        /// </summary>
        /// <returns>always return 'F'</returns>
        public char GetCubeType()
        {
            return 'F';
        }
    }
}