using System;
using System.IO;

namespace AnalysisHMM
{
    public class ReportsGenerator
    {
        private const string COMPARE_FILE = "COMPARE";
        private const string SUMMARY_FILE = "SUMMARY";

        private readonly StringsComparisonsStatistics _statistics;
        public void WriteCompare()
        {
            //first line for the final result is the same as the line in CUBE_OUT
            //third line for the final result is the same as the line in HMM_OUT
            string content = _statistics.Original + Environment.NewLine +
                             _statistics.MatchLine + Environment.NewLine +
                             _statistics.Predicted;

            //output the comparison to appropriate file
            File.WriteAllText(COMPARE_FILE, content);
        }

        public void WriteSummary()
        {
            //true predicted fair cubes of all fair cubes
            double snF = _statistics.TF / (_statistics.TF + _statistics.FU);
            //true predicted fair cubes of all predicted fair cubes
            double spF = _statistics.TF / (_statistics.TF + _statistics.FF);
            //true predicted unfair cubes of all unfair cubes
            double snU = _statistics.TU / (_statistics.TU + _statistics.FF);
            //true predicted unfair cubes of all predicted unfair cubes
            double spU = _statistics.TU / (_statistics.TU + _statistics.FU);

            string summary = String.Format("Sensitivity Fair: {0}" + Environment.NewLine +
                                           "specificity Fair: {1}" + Environment.NewLine +
                                           "Sensitivity Unfair: {2}" + Environment.NewLine +
                                           "specificity Unfair: {3}" + Environment.NewLine, snF, spF, snU, spU);

            File.WriteAllText(SUMMARY_FILE, summary);
        }

        public ReportsGenerator(StringsComparisonsStatistics statistics)
        {
            _statistics = statistics;
        }
    }
}