using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float _speed;
        
    private void Update()
    {
        var rotationY = _speed * Time.deltaTime;
        var eulers = GetNewRotation(0, rotationY, 0);

        transform.Rotate(eulers);
    }

    private Vector3 GetNewRotation(float x, float y, float z) => new Vector3(x, y, z);
}