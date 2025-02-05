using Project._Screepts.Configs;
using Project._Screepts.Screns;
using Services;
using UnityEngine;
using AudioManager = Project._Screepts.AudioManager;

public class GameUI : MonoBehaviour, IService
{
    [SerializeField] private LevelsConfig _levels;
    [SerializeField] private BackgroundScwitcher _backgroundScwitcher;
    [SerializeField] private InstanceCounter _instanceCounter;

    private DialogLauncher _dialogLauncher;
    private AudioManager _audioManager;
    private Level _instanceLevel;

    public void Init()
    {
        _dialogLauncher = ServiceLocator.Instance.GetService<DialogLauncher>();
        _audioManager = ServiceLocator.Instance.GetService<AudioManager>();
        gameObject.SetActive(true);
        _instanceLevel = Instantiate(_levels.GetLevel());
        _instanceLevel.BallInstance.OnInstance += _instanceCounter.Value;
        _instanceLevel.Gate.OnGoal += LoadNextLevel;
        _instanceLevel.StartLevel();
        _backgroundScwitcher.Init();
    }

    public void ShowMenu()
    {
        _audioManager.PlayButtonClick();
        _dialogLauncher.ShowMenuScreen();
    }


    public void RestartLevel()
    {
        _instanceLevel.BallInstance.OnInstance -= _instanceCounter.Value;
        _audioManager.PlayButtonClick();
        _instanceLevel.EndLevel();
        Destroy(_instanceLevel.gameObject);
        _instanceLevel = Instantiate(_levels.GetLevel());
        _instanceLevel.BallInstance.OnInstance += _instanceCounter.Value;
        _instanceLevel.Gate.OnGoal += LoadNextLevel;
        _instanceLevel.BallInstance.Reset();
        _instanceCounter.Reset();
    }

    public void LoadNextLevel()
    {
        _instanceLevel.Gate.OnGoal -= LoadNextLevel;
        _instanceLevel.BallInstance.OnInstance -= _instanceCounter.Value;
        RestartLevel();
    }

    public void Close()
    {
        _audioManager.PlayButtonClick();
        _instanceLevel.EndLevel();
        Destroy(_instanceLevel.gameObject);
        gameObject.SetActive(false);
    }
}