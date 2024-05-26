using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _chanceSplit;

    private Renderer _renderer;

    public event System.Action<Cube> Diying;

    public int ChanceSplit { get => _chanceSplit; }

    public void Init(Vector3 scale, int chanceSplit)
    {
        _chanceSplit = chanceSplit;
        gameObject.transform.localScale = scale;
    }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();

        ChangeColorRandomly();
    }

    private void OnMouseDown() => Destroy();

    private void Destroy()
    {
        Diying?.Invoke(this);
        Destroy(gameObject);
    }

    private void ChangeColorRandomly()
    {
        float red = Random.Range(0f, 1f);
        float green = Random.Range(0f, 1f);
        float blue = Random.Range(0f, 1f);

        _renderer.material.color = new Color(red, green, blue);
    }
}