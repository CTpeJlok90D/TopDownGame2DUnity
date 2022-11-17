using TMPro;
using UnityEngine;

public class Monet : MonoBehaviour
{
    [SerializeField] private TMP_Text _xpGainCountText;
    [SerializeField] private XPgain _xpGain;

    private void Awake()
    {
        _xpGainCountText.text = _xpGain.Count.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out XPcontainer container)) 
        {
            container.XP += _xpGain.Count;
            Destroy(gameObject);
        }
    }
}
