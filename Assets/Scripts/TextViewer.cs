using UnityEngine;
using TMPro;

public class TextViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private Counter _counter;

    private void OnEnable()
    {
        _counter = GetComponent<Counter>();
        _counter.Changed += ViewText;
    }

    private void OnDisable()
    {
        _counter.Changed -= ViewText;
    }

    private void ViewText()
    {
        _text.text = _counter.Count.ToString();
    }
}