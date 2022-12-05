using UnityEngine;

public class RedWolfDeath : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] _deathSprites;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private GameObject _deathBloodPrefub;
    [SerializeField] private GameObject _injuredBloodPrefub;
    [SerializeField] private AI.AI _ai;
    [SerializeField] private float _deathDrug = 5;
    [SerializeField] private float _angularDrug = 5;
    [SerializeField] private float _rangeDistance = 1.2f;

    private float CloseRandomAngle => transform.rotation.eulerAngles.z - Random.Range(-30, 30);

    public void OnTakeDamage()
    {
        GameObject instance = Instantiate(_injuredBloodPrefub, new Vector3(transform.position.x + Random.Range(-_rangeDistance, _rangeDistance), transform.position.y + Random.Range(-_rangeDistance, _rangeDistance), _injuredBloodPrefub.transform.position.z), Quaternion.Euler(0, 0, 0));
        instance.transform.up = -transform.position;
    }

    public void OnDeath()
    {
        _spriteRenderer.sprite = _deathSprites[Random.Range(0, _deathSprites.Length)];

        Instantiate(_deathBloodPrefub, new Vector3(transform.position.x, transform.position.y, _deathBloodPrefub.transform.position.z), Quaternion.Euler(0, 0, CloseRandomAngle));
        transform.rotation = Quaternion.Euler(0, 0, CloseRandomAngle);

        _rigidbody2D.drag = _deathDrug;
        _rigidbody2D.angularDrag = _angularDrug;
    }
}