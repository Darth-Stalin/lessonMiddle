
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public Settings settings;
    public ShootAbility ShootAbility;
    private int _health = int.MaxValue;

    public int Health
    {
        get => _health;
        set
        {
            _health = value;
            
            if (_health <=0) 
            {
                WriteStatistics();
                Destroy(this.gameObject);
            }
        }
    }

    private void WriteStatistics()
    {
        var jsonString = JsonUtility.ToJson(ShootAbility.stats);
        Debug.Log(jsonString);
        PlayerPrefs.SetString("Stats", jsonString);
        PlayerPrefs.Save();
    }

    private void Start()
    {
        Health = settings.HeroHealth;
    }
}
