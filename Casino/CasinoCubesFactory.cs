using System;

namespace Casino
{
    public class CasinoCubesFactory : ICubesFactory
    {
        private const int STAY_FAIR_CHANCE = 95;
        private const int STAY_UNFAIR_CHANCE = 90;
        private readonly Random _random = new Random();
        private readonly FairCube _fair = new FairCube();
        private readonly UnfairCube _unfair = new UnfairCube();

        /// <summary>
        /// get a cube without taking into account the previous cube
        /// </summary>
        /// <returns>always return Fair cube</returns>
        public ICube NextCube()
        {
            return _fair;
        }

        /// <summary>
        /// change fair cube with probability of 5% or unfair cube with probability of 10%
        /// </summary>
        /// <param name="current">The current cube that in use</param>
        /// <returns></returns>
        public ICube NextCube(ICube current)
        {
            //get random number between 1 to 10 (same probability for all numbers)
            int chance = _random.Next(1, 101);
            //if the current cube is fair, and the random number is in the range of 96-100 (means 5% of the options)
            //then switch to unfair cube
            if (current.GetType() == typeof(FairCube) && chance > STAY_FAIR_CHANCE)
                return _unfair;

            //if the current cube is unfair, and the random number is in the range of 91-100 (means 10% of the options)
            //then switch to fair cube
            if (current.GetType() == typeof(UnfairCube) && chance > STAY_UNFAIR_CHANCE)
                return _fair;

            //if the current cube is fair, and the random number is in the range of 1-95 (means 95% of the options)
            //or the current cube is unfair, and the random number is in the range of 1-90 (means 90% of the options)
            //then stay with the current cube
            return current;
        }
    }
}