using UnityEngine;

namespace PlatformerMVC
{

    public class CameraController
    {
        private float X;
        private float Y;

        private float offsetX = 0f;
        private float offsetY = 1.0f;

        private float camSpeed = 300.0f;

        private Transform _playerTransform;
        private Transform _cameraTransform;

        public CameraController(Transform playerTransform, Transform cameraTransform)
        {
            _playerTransform = playerTransform;
            _cameraTransform = cameraTransform;
        }

        public void Update()
        {
            X = _playerTransform.position.x;
            Y = _playerTransform.position.y;

            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position,
                                                    new Vector3(X + offsetX, Y + offsetY, _cameraTransform.position.z),
                                                    Time.deltaTime * camSpeed);
        }
    }
}