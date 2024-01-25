using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed;
        
    private void Update()
    {
        float rotationY = _speed * Time.deltaTime;
        Vector3 eulers = new(0, rotationY, 0);

        transform.Rotate(eulers);
    }
}