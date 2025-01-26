using UnityEngine;

namespace Project._Screepts.GamePlayScreepts
{
    public class BallController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private LineRenderer _lineRenderer;
        private Vector2 _startPoint;
        private Vector2 _dragPoint;
        private bool _isDragging;
        private float _maxForce = 1000f; // Увеличенная максимальная сила
        private int _arcSegments = 50; // Увеличено количество сегментов траектории

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.positionCount = _arcSegments;
            _rigidbody.isKinematic = true;
        }

        void Update()
        {
            if (_isDragging)
            {
                _dragPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                DrawTrajectory(_startPoint, _dragPoint);
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        if (IsTouchingObject(touchPos))
                        {
                            _startPoint = touchPos;
                            _isDragging = true;
                        }

                        break;
                    case TouchPhase.Moved:
                        if (_isDragging)
                        {
                            _dragPoint = touchPos;
                            DrawTrajectory(_startPoint, _dragPoint);
                        }

                        break;
                    case TouchPhase.Ended:
                        if (_isDragging)
                        {
                            Vector2 releasePoint = touchPos;
                            Vector2 force = CalculateForce(_startPoint, releasePoint);
                            _rigidbody.isKinematic = false;
                            _rigidbody.velocity = Vector2.zero; // Сброс скорости
                            _rigidbody.angularVelocity = 0f; // Сброс угловой скорости
                            _rigidbody.AddForce(force, ForceMode2D.Impulse);
                            _isDragging = false;
                            _lineRenderer.positionCount = 0;
                        }

                        break;
                }
            }
        }

        private bool IsTouchingObject(Vector2 touchPos)
        {
            Collider2D col = Physics2D.OverlapPoint(touchPos);
            return col != null && col.gameObject == gameObject;
        }

        private void DrawTrajectory(Vector2 startPoint, Vector2 dragPoint)
        {
            Vector3[] arcPoints = new Vector3[_arcSegments];
            Vector2 direction = dragPoint - startPoint;
            float distance = direction.magnitude;
            Vector2 velocity = CalculateForce(startPoint, dragPoint) / _rigidbody.mass;
            float timeStep = 0.05f; // Меньший шаг времени для более длинной траектории

            for (int i = 0; i < _arcSegments; i++)
            {
                float t = i * timeStep;
                float x = velocity.x * t;
                float y = velocity.y * t + 0.5f * Physics2D.gravity.y * t * t;
                arcPoints[i] = new Vector3(startPoint.x + x, startPoint.y + y, 0);
            }

            _lineRenderer.positionCount = _arcSegments;
            _lineRenderer.SetPositions(arcPoints);
        }

        private Vector2 CalculateForce(Vector2 startPoint, Vector2 endPoint)
        {
            Vector2 forceDirection = startPoint - endPoint;
            float forceMagnitude = forceDirection.magnitude * 100; // Увеличена сила для быстрого движения
            return Vector2.ClampMagnitude(forceDirection.normalized * forceMagnitude, _maxForce);
        }
    }
}