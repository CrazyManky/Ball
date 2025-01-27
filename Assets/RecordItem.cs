using TMPro;
using UnityEngine;

public class RecordItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textItemIndex;
    [SerializeField] private TextMeshProUGUI _textValue;

    public void SetData(int index, int value)
    {
        _textItemIndex.text = $"{index + 1}";
        _textValue.text = value.ToString();
    }
}