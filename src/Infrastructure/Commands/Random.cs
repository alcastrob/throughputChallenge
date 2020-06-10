using Application.Ports;

namespace Infrastructure.Commands
{
    class Random : IRandom
    {
        private readonly System.Random rng = new System.Random();

        public int generateRnd(int minValue, int maxValue)
        {
            return rng.Next(minValue, maxValue);
        }

        public int generateRnd(int maxValue)
        {
            return rng.Next(maxValue);
        }
    }
}
