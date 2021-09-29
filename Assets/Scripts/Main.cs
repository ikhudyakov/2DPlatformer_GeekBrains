using UnityEngine;

namespace PlatformerMVC
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private int _animationSpeed = 10;
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private CannonView _cannonView;
        [SerializeField] private GeneratorLevelView _generatorView;

        private SpriteAnimatorController _playerAnimator;

        private PlayerController _playerController;
        private CannonController _cannon;
        private BulletEmitterController _bulletEmiterController;
        private CameraController _cameraController;
        private TilemapGenerator _tilemapGenerator;

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
            _cameraController = new CameraController(_playerView._transform, Camera.main.transform);

            _tilemapGenerator = new TilemapGenerator(_generatorView);
            _tilemapGenerator.Start();
        }

        private void Update()
        {
            _playerAnimator.Update();
            _playerController.Update();
            _cannon.Update();
            _bulletEmiterController.Update();
            _cameraController.Update();
        }

        private void FixedUpdate()
        {
            
        }
    }
}