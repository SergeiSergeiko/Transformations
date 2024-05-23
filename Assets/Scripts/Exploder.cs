using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private int _explosionForce;

    public void BlowUp(Cube cube)
    {
        Vector3 explosionVector = Random.insideUnitSphere.normalized;

        if (cube.TryGetComponent(out Rigidbody rigidbody))
            rigidbody.AddForce(explosionVector * _explosionForce, ForceMode.VelocityChange);
    }
}