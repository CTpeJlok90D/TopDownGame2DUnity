using UnityEngine;

public class GameCamera : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _target;
    [SerializeField] private float _moveSpeed = 10;

    public void LateUpdate()
    {
        Vector3 newPosition = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _moveSpeed);
        _camera.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }
}
