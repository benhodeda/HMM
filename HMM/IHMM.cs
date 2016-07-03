using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMM
{
    internal interface IHMM
    {
        IEnumerable<State> Prediction();
    }
}
