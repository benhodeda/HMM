using System.IO;

namespace AnalysisHMM
{
    class Program
    {

        static void Main(string[] args)
        {
            //reade CUBE_OUT file as the first argument
            string cubes = File.ReadAllText(args[0]);
            //reade HMM_OUT file as the second argument
            string hmm = File.ReadAllText(args[1]);

            StringsComparisonsStatistics statistics = new StringsComparisonsStatistics(cubes, hmm);
            ReportsGenerator reports = new ReportsGenerator(statistics);
            
            reports.WriteCompare();
            reports.WriteSummary();
        }
    }
}
