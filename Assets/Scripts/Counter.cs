using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TextViewer))]
public class Counter : MonoBehaviour
{
    private float _count;
    private float _numberIncrease = 1;
    private float _delay = 0.5f;
    private bool _isActive = false;

    public float Count
    {
        get => _count;

        private set
        {
            _count += value;
            Changed?.Invoke();
        }
    }

    public UnityAction Changed;

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void Start()
    {
        Count = 0;
        StartCoroutine(CountIncrease());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            _isActive = !_isActive;
    }

    private IEnumerator CountIncrease()
    {
        bool isOpen = true;

        while (isOpen)
        {
            yield return new WaitUntil(() => _isActive);
            yield return new WaitForSeconds(_delay);

            Count = _numberIncrease;
        }
    }
}