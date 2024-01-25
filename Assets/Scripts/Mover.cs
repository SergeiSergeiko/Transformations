using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Vector3 direction = transform.forward;

        transform.Translate(direction * _speed * Time.deltaTime);
    }
}