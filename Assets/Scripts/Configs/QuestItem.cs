using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    [CreateAssetMenu(menuName = "Configs / QuestItemConfig", fileName = "QuestItemConfig", order = 0)]
    public class QuestItem : ScriptableObject
    {
        public int QuestID;
        public List<int> questItemCollection;
    }
}