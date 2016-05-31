namespace Casino
{
    public class GameResult
    {
        public char CubeType { get; private set; }
        public int Result { get; private set; }

        public GameResult(char cubeType, int result)
        {
            Result = result;
            CubeType = cubeType;
        }
        public GameResult(int result)
        {
            Result = result;
            CubeType = '?';
        }
    }
}