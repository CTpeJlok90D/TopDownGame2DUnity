using TMPro;
using UnityEngine;

public class BloodGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _deathBlood;
    [SerializeField] private GameObject _injuredBlood;

    public void OnTakeDamage()
    {
        Instantiate(_injuredBlood,transform.position, Quaternion.identity);
    }

    public void OnDeath()
    {
        Instantiate(_deathBlood, transform.position, Quaternion.identity);
    }
}
