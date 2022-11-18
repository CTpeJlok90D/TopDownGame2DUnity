using System.Collections.Generic;
using UnityEngine;
using Abilitys;
using UnityEngine.Events;

public class XPcontainer : MonoBehaviour
{
    [SerializeField] private int _level = 1;
    [SerializeField] private int _skillPoints = 0;
    [SerializeField] private int _currentXP = 0;
    [SerializeField] private int _xpToNextLevel = 100;
    [SerializeField] private float _xpBoost = 1.15f;
    [SerializeField] private List<Ability> _abilities = new();
    [SerializeField] private UnityEvent<int> _levelUp = new();
    [SerializeField] private UnityEvent<int,int> _xpCountChange = new();
    [SerializeField] private UnityEvent<int> _gotXP = new();

    public UnityEvent<int> LevelUp => _levelUp;
    
    public int XP
    {
        get 
        {
            return _currentXP;
        }
        set
        {
            _xpCountChange.Invoke(value, _xpToNextLevel);
            _gotXP.Invoke(value - _currentXP);
            _currentXP = value;
            if (_currentXP >= _xpToNextLevel)
            {
                _level ++;
                _currentXP = _currentXP - _xpToNextLevel;
                _xpToNextLevel = (int)(_xpToNextLevel * _xpBoost);
            }
        }
    }

    public void ByAbility(Ability ability)
    {
        if (ability.MinLevelToUnlock <= _level && _skillPoints >= ability.SkillPointCost)
        {
            _abilities.Remove(ability);
            ability.enabled = true;
            _skillPoints -= ability.SkillPointCost;
        }
    }
}
