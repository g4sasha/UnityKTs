using Player;
using UnityEngine;

namespace Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField, Range(0f, 100f)]
        private float _cameraSpeed;

        [SerializeField]
        private float _facingOffset;

        [SerializeField]
        private PlayerSetup _target;

        private UnityEngine.Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = UnityEngine.Camera.main;
        }

        private void LateUpdate()
        {
            var cameraPos = _mainCamera.transform.position;
            var offsetX = Vector2.right * (_target.IsFacingRight ? _facingOffset : -_facingOffset);
            var targetPos = _target.transform.position + (Vector3)offsetX;
            var ix = Mathf.Lerp(cameraPos.x, targetPos.x, Time.deltaTime * _cameraSpeed);
            var iy = Mathf.Lerp(cameraPos.y, targetPos.y, Time.deltaTime * _cameraSpeed);

            _mainCamera.transform.position = new Vector3(ix, iy, cameraPos.z);
        }
    }
}
