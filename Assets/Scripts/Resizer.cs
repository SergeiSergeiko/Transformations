using UnityEngine;

public class Resizer : MonoBehaviour
{
    [SerializeField] float _speed;

    private void Update()
    {
        float newSize = _speed * Time.deltaTime;

        transform.localScale += Vector3.one * newSize;
    }
}