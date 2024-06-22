using System;
using UnityEngine;

namespace RuntimeNodeEditor.Functions.Seed
{
    public class SeedManager : MonoBehaviour
    {
        [NonSerialized]
        public int Seed;

        private readonly int _min, _max;

        private readonly System.Random _rnd;

        public SeedManager()
        {
            _min = int.MinValue;
            _max = int.MaxValue;

            _rnd = new System.Random();
            GenerateSeed();
        }

        public SeedManager(int max)
        {
            _max = max;
        }

        public void GenerateSeed()
        {
            Seed = _rnd.Next(_min, _max);
        }

        public byte[] Save()
        {
            return BitConverter.GetBytes(Seed);
        }
    }
}
