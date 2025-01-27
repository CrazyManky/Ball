using Project._Screepts.Configs;
using Project._Screepts.GamePlayScreepts;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Gate _gate;
    [SerializeField] private BallInstance _ballInstance;
    [SerializeField] private PlayerRecords _playerRecords;

    private float _elapsedTime;
    private bool _levelActive; 

    public Gate Gate => _gate;
    public BallInstance BallInstance => _ballInstance;

    void Start()
    {
        _elapsedTime = 0f;
        _levelActive = false;
    }

    void Update()
    {
        if (_levelActive)
        {
            _elapsedTime += Time.deltaTime;
        }
    }

    public void StartLevel()
    {
        _levelActive = true;
        _elapsedTime = 0f;
    }

    public void EndLevel()
    {
        _levelActive = false;
        _playerRecords.AddRecord((int)_elapsedTime);
        _ballInstance.Close();
    }
}