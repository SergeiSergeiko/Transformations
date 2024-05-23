using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void Spawn(Cube cube, Vector3 position) =>
                cube.transform.position = position;
}