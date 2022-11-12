using DG.Tweening;
using UnityEngine;

namespace Source.Level
{
    public class CameraController
    {
        private Camera _camera;
        private Vector2 _endPosition;
        private float _timeDestination;
        public CameraController(Camera cam, Vector2 endPosition, float time)
        {
            _camera = cam;
            _endPosition = endPosition;
            _timeDestination = time;
        }

        public void StartMove()
        {
            _camera.transform.DOMoveX(_endPosition.x, _timeDestination);
        }

        public void StopMove()
        {
            _camera.DOPause();
        }
    }
}
