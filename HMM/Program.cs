using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HMM
{
    class Program
    {
        public static List<State> GetStates()
        {
            State fair = new State('F', 0);
            State unfair = new State('U', 1);
            return new List<State> { fair, unfair };
        }
        public static double[,] GetEmission()
        {
            double[,] emissionProbs = new double[2, 6];
            int i;
            for (i = 0; i < 6; i++)
            {
                emissionProbs[0, i] = 1.0/6;
                emissionProbs[1, i] = 1.0/10;
            }
            emissionProbs[1, --i] = 1.0/2;
            return emissionProbs;
        }

        public static double[,] GetTransition()
        {
            //+----+----+----+
            //|    | F  | U  |
            //+----+----+----+
            //| F  |0.95|0.05|
            //+----+----+----+
            //| U  |0.90|0.10|
            //+----+----+----+
            double[,] transitionProbs = new double[2, 2];
            transitionProbs[0, 0] = 0.95;
            transitionProbs[0, 1] = 0.05;
            transitionProbs[1, 0] = 0.1;
            transitionProbs[1, 1] = 0.9;
            return transitionProbs;
        }

        public static void WritePrediction(IEnumerable<State> prediction)
        {
            StringBuilder hmmResults = new StringBuilder();
            foreach (State state in prediction)
                hmmResults.Append(state.Symbol);

            //output the results to appropriate file
            //~\HMM\HMM\bin\Release\HMM_OUT
            File.WriteAllText("HMM_OUT", hmmResults.ToString());
        }

        static void Main(string[] args)
        {
            //read cubes results from file. the file path is the first argument of this executable.
            int[] cubesResults = File.ReadAllText(args[0]).Select(c => int.Parse(c.ToString())).ToArray();
            
            double[,] emissionProbs = GetEmission();
            double[,] transitionProbs = GetTransition();

            List<State> states = GetStates();

            IHMM hmm = new BackwardForward(states, states.First(), transitionProbs, emissionProbs, cubesResults);
            IEnumerable<State> prediction = hmm.Prediction();

            WritePrediction(prediction);
        }
    }
}
