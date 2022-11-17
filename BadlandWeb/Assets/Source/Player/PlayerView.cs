using System;
using DG.Tweening;
using UnityEngine;

namespace Source.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private float timeAnimation;
        private int _size = 1;
        private Transform _body;

        private void OnEnable()
        {
            _body = GetComponent<Transform>();
        }

        public void UpSize()
        {
            if (_size < 1)
            {
                _size += _size;
                _body.DOScale(_size, timeAnimation);
                return;
            }
            _size++;
            _body.DOScale(_size, timeAnimation);
        }

        public void DownSize()
        {
            if (_size == 1)
            {
                _body.DOScale(0.5f, timeAnimation);
                return;
            }
            _size--;
            _body.DOScale(_size, timeAnimation);
        }
    }
}
