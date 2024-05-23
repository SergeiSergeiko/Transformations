using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private Cube _prefab;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private int _deviderScale;
    [SerializeField] private int _deviderSplit;
    [SerializeField] private int _maxCountSplitCubes;
    [SerializeField, Min(0)] private int _minCountSplitCubes;

    private void OnValidate()
    {
        if (_minCountSplitCubes >= _maxCountSplitCubes)
            _maxCountSplitCubes = _minCountSplitCubes + 1;
    }

    public void Spawn(Cube cube, Vector3 position) => cube.transform.position = position;

    private void SplitUp(Cube cube)
    {
        cube.Diying -= SplitUp;

        if (CanSplit(cube.ChanceSplit) == false)
            return;

        int randomCountCubes = GetRandomCountCubes();
        int chanceSplit = cube.ChanceSplit / _deviderSplit;
        Vector3 scale = cube.transform.localScale / _deviderScale;

        for (int i = 0; i < randomCountCubes; i++)
        {
            Cube newCube = CreateCube(scale, chanceSplit);
            Spawn(newCube, cube.transform.position);
            _exploder.BlowUp(newCube);
        }
    }

    private Cube CreateCube(Vector3 scale, int chanceSplit)
    {
        Cube cube = Instantiate(_prefab);
        cube.Init(scale, chanceSplit);
        cube.Diying += SplitUp;

        return cube;
    }

    private bool CanSplit(int chanceSplit)
    {
        int minValue = 0;
        int maxValue = 100;
        int randomNumber = Random.Range(minValue, maxValue);

        return randomNumber <= chanceSplit;
    }

    private int GetRandomCountCubes() => Random.Range(_minCountSplitCubes, _maxCountSplitCubes);
}