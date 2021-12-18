using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "ProvideTypeConfig", menuName = "ProvideTypeConfigMenu", order = 0)]
    public class ProvideTypeConfig : ScriptableObject
    {
        [SerializeField] private ProvideType provideType = default;
        internal ProvideType ProvideType => provideType;
    }
}