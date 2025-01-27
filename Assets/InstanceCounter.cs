using TMPro;
using UnityEngine;

public class InstanceCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void Value(int value)
    {
        _text.text = $"{value}/3";
    }
}