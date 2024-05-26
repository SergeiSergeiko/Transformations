using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private ParticleSystem _blowUpEffect;
    [SerializeField] private int _bombExplosionForce;
    [SerializeField] private float _radius;
    [SerializeField] private float _upwardsModifier;
    [SerializeField] private int _explosionForce;

    public void BlowUp(Cube cube)
    {
        Vector3 explosionVector = Random.insideUnitSphere.normalized;

        if (cube.TryGetComponent(out Rigidbody rigidbody))
            rigidbody.AddForce(explosionVector * _explosionForce, ForceMode.VelocityChange);

        Instantiate(_blowUpEffect, cube.transform.position, Quaternion.identity);
    }

    public void Explode(Cube cube)
    {
        float force = _bombExplosionForce / cube.transform.localScale.x;
        float radius = _radius / cube.transform.localScale.x;
        Vector3 position = cube.transform.position;

        Collider[] hits = Physics.OverlapSphere(position, _radius);

        foreach (var hit in hits)
        {
            hit.attachedRigidbody?.AddExplosionForce(force, position, radius,
                _upwardsModifier, ForceMode.Acceleration);
        }

        Instantiate(_explosionEffect, position, Quaternion.identity);
    }
}