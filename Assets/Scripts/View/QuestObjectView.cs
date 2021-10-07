using UnityEngine;

namespace PlatformerMVC
{
    public class QuestObjectView : LevelObjectView
    {
        [SerializeField] private int ID;
        [SerializeField] private Color _completedColor;
        private Color _defaultColor;

        public int Id => ID;

        private void Awake()
        {
            _defaultColor = _spriteRenderer.color;
        }

        public void Complete()
        {
            _spriteRenderer.color = _completedColor;
        }

        public void Activate()
        {
            _spriteRenderer.color = _defaultColor;
        }
    }
}