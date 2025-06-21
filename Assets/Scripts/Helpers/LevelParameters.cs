namespace Helpers
{
    public struct LevelParameters
    {
        public int RandomHash;
        public int FlaskCount;
        public int FlaskHeight;

        public LevelParameters(int hash, int flaskCount, int flaskHeight)
        {
            RandomHash = hash;
            FlaskCount = flaskCount;
            FlaskHeight = flaskHeight;
        }
    }
}