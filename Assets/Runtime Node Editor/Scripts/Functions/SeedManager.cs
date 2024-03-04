using UnityEngine;

namespace RuntimeNodeEditor.Functions.Seed
{
    public class SeedManager : MonoBehaviour
    {
        private int _min, _max;

        private System.Random _rnd;

        public SeedManager()
        {
            _min = int.MinValue;
            _max = int.MaxValue;

            _rnd = new System.Random();
        }

        public void GenerateSeed()
        {
            Debug.Log(_rnd.Next(_min, _max));
        }
    }
}
