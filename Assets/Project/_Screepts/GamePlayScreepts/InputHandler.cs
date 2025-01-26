using UnityEngine;

namespace Project._Screepts.GamePlayScreepts
{
    public class InputHandler
    {
        private Vector2 _startDragPosition;
        private Vector2 _releasePosition;
        private bool _isDragging;

        public bool IsDragging => _isDragging;

        public Vector2 StartDragPosition => _startDragPosition;

        public Vector2 GetThrowForce(float forceMultiplier)
        {
            return (_startDragPosition - _releasePosition) * forceMultiplier;
        }

        public void HandleTouchInput()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        _isDragging = true;
                        _startDragPosition = Camera.main.ScreenToWorldPoint(touch.position);
                        break;

                    case TouchPhase.Moved:
                        if (_isDragging)
                        {
                            _releasePosition = Camera.main.ScreenToWorldPoint(touch.position);
                        }
                        break;

                    case TouchPhase.Ended:
                        _isDragging = false;
                        break;
                }
            }
        }
    }
}