using System.IO;
using System.Text;

namespace Casino
{
    class Program
    {
        private const int TURNS = 300;
        static void Main(string[] args)
        {
            //create string builders for cubes' results and types
            StringBuilder casinoCubeResults = new StringBuilder();
            StringBuilder casinoCubeTypes = new StringBuilder();

            //create the casino
            ICubesGame game = new CasinoCubesGame();

            //play 300 games in the casino
            for (int i = 0; i < TURNS; i++)
            {
                GameResult result = game.Play();

                //save the current result and cube's type in the appropriate builder
                casinoCubeResults.Append(result.Result);
                casinoCubeTypes.Append(result.CubeType);
            }

            //output the results to appropriate files
            File.WriteAllText("TOSS_OUT", casinoCubeResults.ToString());
            File.WriteAllText("CUBES_OUT", casinoCubeTypes.ToString());
        }
    }
}
