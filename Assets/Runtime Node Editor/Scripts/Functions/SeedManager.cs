using System;
using UnityEngine;

namespace RuntimeNodeEditor.Functions.Seed
{
    public class SeedManager : MonoBehaviour
    {
        [NonSerialized]
        public int Seed;

        private readonly System.Random _rnd = new();

        public void GenerateSeed()
        {
            Seed = _rnd.Next(int.MinValue, int.MaxValue);
        }

        public byte[] Save()
        {
            return BitConverter.GetBytes(Seed);
        }
    }
}
