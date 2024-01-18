using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float _speed;

    private void Update()
    {
        Vector3 direction = transform.forward;

        transform.Translate(direction * _speed * Time.deltaTime);
    }
}
