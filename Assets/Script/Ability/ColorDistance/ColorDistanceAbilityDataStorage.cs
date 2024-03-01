using System.Collections.Generic;
using UnityEngine;

namespace VacoTest.Ability
{
    //[CreateAssetMenu(menuName = "Ability/DistanceStorage")]
    public class ColorDistanceAbilityDataStorage : ScriptableObject
    {
        private Queue<ColorDistanceAbilityData> _data = new Queue<ColorDistanceAbilityData>();
        public Queue<ColorDistanceAbilityData> _lastData = new Queue<ColorDistanceAbilityData>();

        public void Add(Color color) => Add(new ColorDistanceAbilityData(color));

        public void Add(ColorDistanceAbilityData data)
        {
            _data.Enqueue(data);
        }

        public void ResetCurrentData()
        {
            _lastData = new Queue<ColorDistanceAbilityData>(_data);
            _data.Clear();
        }

        public ColorDistanceAbilityData? Get()
        {
            if (_lastData.Count == 0)
                return null;

            return _lastData.Dequeue();
        }
    }
}