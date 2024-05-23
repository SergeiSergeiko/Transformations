using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private CubeCreator _cubeCreator;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private int _deviderScale;
    [SerializeField] private int _deviderSplit;
    [SerializeField, Min(0)] private int _minCountSplitCubes;
    [SerializeField] private int _maxCountSplitCubes;

    private void OnValidate()
    {
        if (_minCountSplitCubes >= _maxCountSplitCubes)
            _maxCountSplitCubes = _minCountSplitCubes + 1;
    }

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Cube cube = _cubeCreator.CreateCube();
            cube.Diying += SplitUp;
            _spawner.Spawn(cube, transform.position);
        }
    }

    private void SplitUp(Cube cube)
    {
        cube.Diying -= SplitUp;

        if (CanSplit(cube.ChanceSplit) == false)
            return;

        int randomCountCubes = GetRandomCountCubes();

        for (int i = 0; i < randomCountCubes; i++)
        {
            Vector3 scale = cube.transform.localScale / _deviderScale;
            int chanceSplit = cube.ChanceSplit / _deviderSplit;

            Cube newCube = CreateCube(scale, chanceSplit);
            _spawner.Spawn(newCube, cube.transform.position);
            _exploder.BlowUp(newCube);
        }
    }

    private Cube CreateCube(Vector3 scale, int chanceSplit)
    {
        Cube cube = _cubeCreator.CreateCube();
        cube.Diying += SplitUp;
        cube.Init(scale, chanceSplit);

        return cube;
    }

    private bool CanSplit(int chanceSplit)
    {
        int minValue = 0;
        int maxValue = 100;
        int randomNumber = Random.Range(minValue, maxValue);

        return randomNumber <= chanceSplit;
    }

    private int GetRandomCountCubes() => 
        Random.Range(_minCountSplitCubes, _maxCountSplitCubes);
}