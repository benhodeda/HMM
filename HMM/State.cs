namespace HMM
{
    internal class State
    {
        public int ID { get; private set; }
        public char Symbol { get; private set; }

        public State(char symbol, int id)
        {
            Symbol = symbol;
            ID = id;
        }
    }
}