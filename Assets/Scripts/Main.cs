using UnityEngine;

namespace PlatformerMVC
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private int _animationSpeed = 10;
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private CannonView _cannonView;

        private SpriteAnimatorController _playerAnimator;

        private PlayerController _playerController;
        private CannonController _cannon;
        private BulletEmitterController _bulletEmiterController;

        private void Awake()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            if (_playerConfig)
            {
                _playerAnimator = new SpriteAnimatorController(_playerConfig);
            }

            _playerController = new PlayerController(_playerView, _playerAnimator);
            _cannon = new CannonController(_cannonView._muzzleTransform, _playerView.transform);
            _bulletEmiterController = new BulletEmitterController(_cannonView._bullets, _cannonView._emiterTransform);
        }

        private void Update()
        {
            _playerAnimator.Update();
            _playerController.Update();
            _cannon.Update();
            _bulletEmiterController.Update();
        }

        private void FixedUpdate()
        {
            
        }
    }
}