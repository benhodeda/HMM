using System;

namespace Casino
{
    public class UnfairCube : ICube
    {
        private readonly Random _random = new Random();

        /// <summary>
        /// this cube have a chance of 1/10 for {1,2,3,4,5} and chance of 1/2 for 6
        /// </summary>
        /// <returns>number between 1 to 6</returns>
        public int Toss()
        {
            //get random number between 1 to 10 (same probability for all numbers)
            int result = _random.Next(1, 11);
            
            //in case of 6 or greater (exectly half of the possible number) return 6 (chance of 1/2 for 6)
            //else return the real number (chance of 1/10 for each 1-5)
            return result <= 6 ? result : 6;
        }

        /// <summary>
        /// The Symbol for Unfair cube
        /// </summary>
        /// <returns>always return 'U'</returns>
        public char GetCubeType()
        {
            return 'U';
        }
    }
}