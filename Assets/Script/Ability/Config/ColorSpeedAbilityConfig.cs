using UnityEngine;

namespace VacoTest.Ability.Config
{
    [CreateAssetMenu(menuName = "Ability/ColorSpeed")]
    public class ColorSpeedAbilityConfig : ScriptableObject
    {
        [field: SerializeField, Range(1f, 5f)] public float SpeedOfChange { get; private set; } = 3;
        [field: SerializeField] public Color Color { get; private set; } = Color.green;
    }
}