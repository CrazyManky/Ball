using Project._Screepts.Configs;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScwitcher : MonoBehaviour
{
    [SerializeField] private BackgroundConfig _backgroundConfig;
    [SerializeField] private Image _backgroundImage;

    public void Init()
    {
        _backgroundImage.sprite = _backgroundConfig.GetSprites();
    }
}