using UnityEngine;

public class Scale : MonoBehaviour
{
    [SerializeField] float _speed;

    private void Update()
    {
        var scale = _speed * Time.deltaTime;

        transform.localScale += GetNewScale(scale, scale, scale);
    }

    private Vector3 GetNewScale(float x, float y, float z) => new Vector3 (x, y, z);
}