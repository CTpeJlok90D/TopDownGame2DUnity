using UnityEngine;

public class TimedObject : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private bool _destroyItOnExitTime = false;

    private float _startLifeTime;

    private void Awake()
    {
        _startLifeTime = _lifeTime;
    }

    private void OnEnable()
    {
        _lifeTime = _startLifeTime;
    }

    private void Update()
    {
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0)
        {
            if (_destroyItOnExitTime)
            {
                Destroy(gameObject);
            }
            gameObject.SetActive(false);
        }
    }
}
