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

        private PlayerController _playerController;

        private void Awake()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            if (_playerConfig)
            {
                _playerAnimator = new SpriteAnimatorController(_playerConfig);
            }

            _playerController = new PlayerController(_playerView, _playerAnimator);
        }

        private void Update()
        {
            _playerAnimator.Update();
            _playerController.Update();
        }

        private void FixedUpdate()
        {
            
        }
    }
}