using UnityEngine;

namespace PlatformerMVC
{
    [CreateAssetMenu(menuName = "Configs / QuestConfig", fileName = "QuestConfig", order = 0)]
    public class QuestConfig : ScriptableObject
    {
        public int id;
        public QuestType questType;

    }

    public enum QuestType
    {
        Coins,
    }
}