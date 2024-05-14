using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _count;
    private float _numberIncrease = 1;
    private float _delay = 0.5f;
    private bool _isActive = false;
    private Coroutine _coroutine = null;

    public float Count
    {
        get => _count;

        private set
        {
            _count = value;
            CountChanged?.Invoke();
        }
    }
    public bool IsActive
    {
        get => _isActive;

        private set
        {
            _isActive = value;
            ActiveChanged?.Invoke();
        }
    }

    public event Action CountChanged;
    public event Action ActiveChanged;

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void Start()
    {
        Count = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            IsActive = !IsActive;
            RestartCoroutine(ref _coroutine, CountIncrease());
        }
    }

    private IEnumerator CountIncrease()
    {
        WaitForSeconds delay = new(_delay);

        while (_isActive)
        {
            yield return delay;

            Count += _numberIncrease;
        }
    }

    private void RestartCoroutine(ref Coroutine coroutine, IEnumerator method)
    {
        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(method);
    }
}