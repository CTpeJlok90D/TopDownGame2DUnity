using UnityEngine;

public class RedWolfDeath : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] _deathSprites;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Collider2D _collider2D;
    [SerializeField] private GameObject _deathBloodPrefub;
    [SerializeField] private GameObject _injuredBloodPrefub;
    [SerializeField] private float _deathDrug = 5;
    [SerializeField] private float _angularDrug = 5;

    private float CloseRandomAngle => transform.rotation.eulerAngles.z - Random.Range(-30, 30);

    public void OnTakeDamage()
    {
        Instantiate(_injuredBloodPrefub, new Vector3(transform.position.x, transform.position.y, _injuredBloodPrefub.transform.position.z), Quaternion.Euler(0, 0, CloseRandomAngle));
    }

    public void OnDeath()
    {
        Instantiate(_deathBloodPrefub, new Vector3(transform.position.x, transform.position.y, _deathBloodPrefub.transform.position.z), Quaternion.Euler(0, 0, CloseRandomAngle));
        _spriteRenderer.sprite = _deathSprites[Random.Range(0, _deathSprites.Length)];
        transform.rotation = Quaternion.Euler(0, 0, CloseRandomAngle);
        _rigidbody2D.drag = _deathDrug;
        _rigidbody2D.angularDrag = _angularDrug;
        _collider2D.enabled = false;
    }
}