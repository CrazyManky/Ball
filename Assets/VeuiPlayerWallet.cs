using Project._Screepts.Configs;
using TMPro;
using UnityEngine;

public class VeuiPlayerWallet : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    void Start()
    {
        _textMeshPro.text = $"{_playerWallet.Value}";
    }
}