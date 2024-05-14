using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountViewer : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _image;

    private Color _defaultColor;

    private void Start()
    {
        _defaultColor = _image.color;
    }

    private void OnEnable()
    {
        _counter.CountChanged += ViewCount;
        _counter.ActiveChanged += ChangeColor;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= ViewCount;
        _counter.ActiveChanged -= ChangeColor;
    }

    private void ViewCount()
    {
        _text.text = _counter.Count.ToString();
    }

    private void ChangeColor()
    {
        if (_counter.IsActive)
            _image.color = Color.red;
        else
            _image.color = _defaultColor;
    }
}