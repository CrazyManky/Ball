using System.Collections;
using UnityEngine;

namespace Project._Screepts.GamePlayScreepts
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private Rigidbody2D _rigidbody;
        private LineRenderer _lineRenderer;
        private Vector2 _startPoint;
        private bool _isDragging;
        private Vector2 _initialTouchPos;
        private bool _isLaunched;

        public float forceMultiplier = 10f; // Сила для основного движения
        public float maxDragDistance = 5f; // Максимальное расстояние перетаскивания
        public float deviationForce = 2f; // Сила отклонения
        public int trajectorySegments = 100; // Количество точек для траектории

        private Vector2 deviationDirection; // Направление отклоняющей силы

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _lineRenderer = GetComponent<LineRenderer>();

            _lineRenderer.positionCount = 0; // Изначально линии нет
            _rigidbody.gravityScale = 0; // Отключаем гравитацию до запуска
            _isLaunched = false; // Мяч не запущен
        }

        public void SetSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }
        
        void Update()
        {
            // Блокируем ввод, если мяч уже был запущен
            if (_isLaunched) return;

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        if (IsTouchingObject(touchPos))
                        {
                            _isDragging = true;
                            _initialTouchPos = touchPos;
                            _startPoint = transform.position;
                        }

                        break;

                    case TouchPhase.Moved:
                        if (_isDragging)
                        {
                            DrawTrajectory(_startPoint, touchPos); // Обновляем траекторию
                        }

                        break;

                    case TouchPhase.Ended:
                        if (_isDragging)
                        {
                            _isDragging = false;

                            // Скрываем траекторию
                            _lineRenderer.positionCount = 0;

                            // Вычисляем направление силы
                            Vector2 releaseDirection = _initialTouchPos - touchPos;

                            // Ограничиваем максимальное расстояние
                            if (releaseDirection.magnitude > maxDragDistance)
                            {
                                releaseDirection = releaseDirection.normalized * maxDragDistance;
                            }

                            LaunchBall(releaseDirection);
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

        private void LaunchBall(Vector2 releaseDirection)
        {
            // Устанавливаем флаг, чтобы запретить повторный запуск
            _isLaunched = true;

            // Включаем гравитацию
            _rigidbody.gravityScale = 1;

            // Сбрасываем текущую скорость мяча
            _rigidbody.velocity = Vector2.zero;

            // Применяем основную силу для запуска мяча
            Vector2 mainForce = releaseDirection * forceMultiplier;
            _rigidbody.AddForce(mainForce, ForceMode2D.Impulse);

            // Запускаем дугообразное движение с отклонением
            StartCoroutine(ApplyDeviationForce(releaseDirection));
        }

        private System.Collections.IEnumerator ApplyDeviationForce(Vector2 releaseDirection)
        {
            while (true) // Сила действует постоянно
            {
                // Вектор отклонения будет зависеть от направления перемещения пальца
                Vector2 deviation = new Vector2(-releaseDirection.y, releaseDirection.x).normalized;

                _rigidbody.AddForce(deviation * deviationForce, ForceMode2D.Force);
                yield return new WaitForFixedUpdate();
            }
        }

        private void DrawTrajectory(Vector2 startPoint, Vector2 releasePoint)
        {
            // Рассчитываем направление силы
            Vector2 direction = _initialTouchPos - releasePoint;

            // Ограничиваем максимальное расстояние
            if (direction.magnitude > maxDragDistance)
            {
                direction = direction.normalized * maxDragDistance;
            }

            Vector2 force = direction * forceMultiplier;

            // Массив точек траектории
            Vector3[] trajectoryPoints = new Vector3[trajectorySegments];
            Vector2 currentPosition = startPoint;
            Vector2 currentVelocity = force / _rigidbody.mass;
            float timeStep = Time.fixedDeltaTime;

            // Симуляция траектории
            for (int i = 0; i < trajectorySegments; i++)
            {
                trajectoryPoints[i] = currentPosition;

                // Вычисляем новое положение
                currentPosition += currentVelocity * timeStep;

                // Учитываем гравитацию
                currentVelocity += Physics2D.gravity * timeStep;

                // Учтем отклоняющую силу
                Vector2 deviationDirection = new Vector2(-direction.y, direction.x).normalized;
                currentVelocity += deviationDirection * deviationForce * timeStep;
            }

            // Отображаем траекторию
            _lineRenderer.positionCount = trajectorySegments;
            _lineRenderer.SetPositions(trajectoryPoints);
        }
    }
}