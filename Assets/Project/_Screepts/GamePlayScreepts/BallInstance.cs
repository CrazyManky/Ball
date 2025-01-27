using System;
using Project._Screepts.Configs;
using UnityEngine;

namespace Project._Screepts.GamePlayScreepts
{
    public class BallInstance : MonoBehaviour
    {
        [SerializeField] private AcitvePlayerItem _acitvePlayerItem;
        [SerializeField] private BallController _playerPrefab;
        private int _maxInstance = 3;

        private BallController _ballControllerInstance;
        private int _instanceCounter;
        public int InstanceCounter => _instanceCounter;
        public event Action<int> OnInstance;
        public void Start() => Instance();

        private void Instance()
        {
            if (_instanceCounter <= _maxInstance)
            {
                _instanceCounter++;
                var sprite = _acitvePlayerItem.GetActiveSprite();
                _ballControllerInstance = Instantiate(_playerPrefab);
                _ballControllerInstance.transform.position = transform.position;
                _ballControllerInstance.SetSprite(sprite);
                OnInstance?.Invoke(_instanceCounter);
            }
        }

        public void Update()
        {
            if (_ballControllerInstance == null)
            {
                Instance();
            }
            
            if (_ballControllerInstance != null)
            {
                Vector3 viewportPos = Camera.main.WorldToViewportPoint(_ballControllerInstance.transform.position);
                if (viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1)
                {
                    Destroy(_ballControllerInstance.gameObject);
                    _ballControllerInstance = null;
                }
            }
        }


        public void Close()
        {
            Destroy(_ballControllerInstance.gameObject);
        }
    }
}