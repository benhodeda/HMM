using System.Text;

namespace AnalysisHMM
{
    public class StringsComparisonsStatistics
    {
        //The original results
        public string Original { get; private set; }
        //The predicted results
        public string Predicted { get; private set; }
        //True Fair
        public int TF { get; private set; }
        //True Unfair
        public int TU { get; private set; }
        //False Fair
        public int FF { get; private set; }
        //False Unfair
        public int FU { get; private set; }
        public string MatchLine { get; private set; }

        public StringsComparisonsStatistics(string original, string predicted)
        {
            Original = original;
            Predicted = predicted;
            StringBuilder matchLineBuilder = new StringBuilder();
            for (int i = 0; i < Original.Length; i++)
            {
                //write + iff the current chars in both CUBES_OUT and HMM_OUT are the same
                if (Original[i] == Predicted[i])
                {
                    matchLineBuilder.Append('+');
                    if (Predicted[i] == 'F') //match of Fair cube
                        TF++; //increase True Fair
                    else //match of Unfair cube
                        TU++; //increase True Unfair
                }
                else
                {
                    matchLineBuilder.Append(' ');
                    if (Predicted[i] == 'F') //mismatch of Fair cube
                        FF++; //increase False Fair
                    else //mismatch of Unfair cube
                        FU++;  //increase False Unfair
                }
            }
            MatchLine = matchLineBuilder.ToString();
        }
    }
}