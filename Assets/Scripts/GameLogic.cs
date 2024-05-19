using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private int _deviderScale;
    private int _deviderSplit;
    private int _changeSplit;

    private void Start()
    {
        _deviderScale = 2;
        _deviderSplit = 2;
        _changeSplit = 100;
    }

    public void Method(Cube gameObject, Vector3 scale)
    {
        gameObject.Destroying -= Method;

        if (CanSplit() == false)
            return;

        int countCubes = GetCountCubes();
        scale /= _deviderScale;
        _spawner.Spawn(gameObject.transform, scale, countCubes);
        _changeSplit /= _deviderSplit;
    }

    private bool CanSplit()
    {
        int minValue = 0;
        int maxValue = 100;
        int randomNumber = Random.Range(minValue, maxValue);

        return randomNumber <= _changeSplit;
    }

    private int GetCountCubes()
    {
        int minValue = 2;
        int maxValue = 6;

        return Random.Range(minValue, maxValue);
    }
}