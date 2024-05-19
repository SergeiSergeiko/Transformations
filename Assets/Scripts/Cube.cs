using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private ParticleSystem _dieEffect;

    private Renderer _renderer;

    public event Action<Cube, Vector3> Destroying;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();

        ChangeColorRandomly();
    }

    private void OnMouseDown()
    {
        Destroy();
    }

    private void Destroy()
    {
        Destroying?.Invoke(this, transform.localScale);
        Explode();
        StartDieEffect();
        Destroy(gameObject);
    }

    private void StartDieEffect()
    {
        ChangeColorEffect(_dieEffect, _renderer.material.color);
        Instantiate(_dieEffect, transform.position, Quaternion.identity);
    }

    private void ChangeColorRandomly()
    {
        float red = UnityEngine.Random.Range(0f, 1f);
        float green = UnityEngine.Random.Range(0f, 1f);
        float blue = UnityEngine.Random.Range(0f, 1f);

        _renderer.material.color = new Color(red, green, blue);
    }

    private void ChangeColorEffect(ParticleSystem particleSystem, Color color)
    {
        ParticleSystem.MainModule mainModule = particleSystem.main;
        mainModule.startColor = color;
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (var collider in colliders)
            collider.attachedRigidbody?.AddExplosionForce(_explosionForce,
                transform.position, _explosionRadius);
    }
}