using UnityEngine;

namespace PlatformerMVC
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private int _animationSpeed = 10;
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private AnimState _state;

        private SpriteAnimatorController _playerAnimator;

        private void Awake()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            if (_playerConfig)
            {
                _playerAnimator = new SpriteAnimatorController(_playerConfig);
            }

            if (_playerView)
            {
                _playerAnimator.StartAnimation(_playerView._spriteRenderer, _state, true, _animationSpeed);
            }
        }

        private void Update()
        {
            _playerAnimator.Update();
        }
    }
}