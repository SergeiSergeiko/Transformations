using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _defaultSpawnPoint;
    [SerializeField] private Cube _prefab;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private int _deviderScale;
    [SerializeField] private int _deviderSplit;
    [SerializeField, Min(0)] private int _minNumberSplitCubes;
    [SerializeField] private int _maxNumberSplitCubes;
    [SerializeField] private int _initialNumberCubes;

    private void OnValidate()
    {
        if (_minNumberSplitCubes >= _maxNumberSplitCubes)
            _maxNumberSplitCubes = _minNumberSplitCubes + 1;
    }

    private void Start()
    {
        for (int i = 0; i < _initialNumberCubes; i++)
        {
            Spawn(_defaultSpawnPoint.transform.position, 
                _prefab.transform.localScale, _prefab.ChanceSplit);
        }
    }

    private void Spawn(Vector3 position, Vector3 scale, int chanceSplit)
    {
        Cube cube = Instantiate(_prefab, position, Quaternion.identity);
        cube.Init(scale, chanceSplit);
        cube.Diying += SplitUp;

        _exploder.BlowUp(cube);
    }

    private void SplitUp(Cube cube)
    {
        cube.Diying -= SplitUp;

        if (CanSplit(cube.ChanceSplit) == false)
        {
            _exploder.Explode(cube);

            return;
        }

        int randomNumberCubes = GetRandomNumberCubes();
        int chanceSplit = cube.ChanceSplit / _deviderSplit;
        Vector3 scale = cube.transform.localScale / _deviderScale;

        for (int i = 0; i < randomNumberCubes; i++)
            Spawn(cube.transform.position, scale, chanceSplit);
    }

    private bool CanSplit(int chanceSplit)
    {
        int minValue = 0;
        int maxValue = 100;
        int randomNumber = Random.Range(minValue, maxValue);

        return randomNumber <= chanceSplit;
    }

    private int GetRandomNumberCubes() => Random.Range(_minNumberSplitCubes, _maxNumberSplitCubes);
}