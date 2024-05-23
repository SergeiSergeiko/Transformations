using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    [SerializeField] private Cube _prefab;

    public Cube CreateCube() =>
        Instantiate(_prefab);
}