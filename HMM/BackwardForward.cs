using System.Collections.Generic;
using System.Linq;

namespace HMM
{
    internal class BackwardForward : IHMM
    {
        private readonly IEnumerable<State> _states;
        private readonly State _starter;
        private readonly double[,] _transitionProbs;
        private readonly double[,] _emissionProbs;
        private readonly int[] _observers;
        private readonly double[,] _forwardBackup;
        private readonly double[,] _backwardBackup;
        private readonly double _observerProb;

        private void ResetBackups()
        {
            //initialize forward and backward matrix for dynamic programming algorithm
            for (int i = 0; i < _forwardBackup.GetLength(0); i++)
            {
                if (i == _starter.ID) _forwardBackup[i, 0] = _emissionProbs[i, _observers[0] - 1];
                else _forwardBackup[i, 0] = 0;
                for (int j = 1; j < _forwardBackup.GetLength(1); j++)
                    _forwardBackup[i, j] = -1;
            }

            for (int i = 0; i < _backwardBackup.GetLength(0); i++)
            {
                int j;
                for (j = 0; j < _backwardBackup.GetLength(1); j++)
                    _backwardBackup[i, j] = -1;
                _backwardBackup[i, --j] = 1;
            }
        }

        public BackwardForward(ICollection<State> states, State starter,  double[,] transitionProbs, double[,] emissionProbs, int[] observers)
        {
            _states = states;
            _starter = starter;
            _transitionProbs = transitionProbs;
            _emissionProbs = emissionProbs;
            _observers = observers;
            _forwardBackup = new double[states.Count, observers.Length];
            _backwardBackup = new double[states.Count, observers.Length];
            ResetBackups();
            _observerProb = _states.Sum(state => Forward(_observers.Length - 1, state));
        }

        public IEnumerable<State> Prediction()
        {
            List<State> prediction = new List<State>();
            //predict the cube foreach result index
            for (int i = 0; i < _observers.Length; i++)
                prediction.Add(SinglePrediction(i));
            return prediction;
        }

        private State SinglePrediction(int index)
        {
            double maxProb = -1;
            State predicted = null;
            foreach (State state in _states)
            {
                //the prob for current state is backward(i, s) * forward(i, s)
                double prob = Backward(index, state) * Forward(index, state) / _observerProb;
                if (prob > maxProb)
                {
                    //if this state have hight prob last states - compare next states to this state
                    maxProb = prob;
                    predicted = state;
                }
            }
            //return the state with that have the highest prob
            return predicted;
        }

        private double Forward(int index, State state)
        {
            //forward algoithm
            if (_forwardBackup[state.ID, index] != -1)
                return _forwardBackup[state.ID, index];
            double forward = _states.Sum(s => Forward(index - 1, s) * _transitionProbs[s.ID, state.ID]);
            _forwardBackup[state.ID, index] = forward * _emissionProbs[state.ID, _observers[index] - 1];
            return _forwardBackup[state.ID, index];
        }

        private double Backward(int index, State state)
        {
            //backward algorithm
            if (_backwardBackup[state.ID, index] != -1)
                return _backwardBackup[state.ID, index];
            _backwardBackup[state.ID, index] = _states.Sum(s => _emissionProbs[s.ID, _observers[index + 1] - 1]*Backward(index + 1, s)*_transitionProbs[state.ID, s.ID]);
            return _backwardBackup[state.ID, index];
        }
    }
}