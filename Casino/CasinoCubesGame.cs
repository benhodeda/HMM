namespace Casino
{
    public class CasinoCubesGame : ICubesGame
    {
        private ICube _cube;
        private readonly ICubesFactory _cubesFactory;

        public CasinoCubesGame() : this(new CasinoCubesFactory())
        {
            
        }

        public CasinoCubesGame(ICubesFactory cubesFactory)
        {
            _cubesFactory = cubesFactory;
            _cube = _cubesFactory.NextCube();
        }

        public GameResult Play()
        {
            //the the current cube and save its type and results
            GameResult result = new GameResult(_cube.GetCubeType(), _cube.Toss());

            //change cube
            _cube = _cubesFactory.NextCube(_cube);
            return result;
        }
    }
}