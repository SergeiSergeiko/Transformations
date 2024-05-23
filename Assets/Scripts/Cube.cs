using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private ParticleSystem _dieEffect;
    [SerializeField] private int _changeSplit;

    private Renderer _renderer;

    public event System.Action<Cube> Diying;

    public int ChanceSplit { get => _changeSplit; }

    public void Init(Vector3 scale, int chanceSplit)
    {
        _changeSplit = chanceSplit;
        gameObject.transform.localScale = scale;
    }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();

        ChangeColorRandomly();
    }

    private void OnMouseDown() =>
        Destroy();

    private void Destroy()
    {
        Diying?.Invoke(this);
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
        float red = Random.Range(0f, 1f);
        float green = Random.Range(0f, 1f);
        float blue = Random.Range(0f, 1f);

        _renderer.material.color = new Color(red, green, blue);
    }

    private void ChangeColorEffect(ParticleSystem particleSystem, Color color)
    {
        ParticleSystem.MainModule mainModule = particleSystem.main;
        mainModule.startColor = color;
    }
}