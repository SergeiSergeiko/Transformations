using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameLogic _gameLogic;

    private int _startCountCubes = 3;

    private void Start()
    {
        Spawn(_spawnPoint, _prefab.transform.localScale, _startCountCubes);
    }

    public void Spawn(Transform transform, Vector3 scale, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Cube newObject = Instantiate(_prefab, transform.position, Quaternion.identity);
            newObject.transform.localScale = scale;
            newObject.Destroying += _gameLogic.Method;
        }
    }
}