using System.Collections.Generic;

namespace HMM
{
    internal interface IHMM
    {
        IEnumerable<State> Prediction();
    }
}
