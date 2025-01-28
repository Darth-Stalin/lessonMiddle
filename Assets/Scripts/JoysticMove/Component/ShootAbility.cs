using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using lesson2M.Assets.Scripts.JoysticMove.Component;
using System;

public class ShootAbility : MonoBehaviour, IAbility
{
    public GameObject bullet;
    public float shootDelay;
    
    private float _shootTime = float.MinValue;
    public PlayerStats stats;

    private void Start()
    {
         var jsonString = PlayerPrefs.GetString("Stats");
         if(!jsonString.Equals(String.Empty,StringComparison.Ordinal))
         {
            stats =JsonUtility.FromJson<PlayerStats>(jsonString);
         }
         else
         {
            stats = new PlayerStats();
         }
         
    }

    public void Execute()
    {
        if (Time.time < _shootTime + shootDelay) return; 
        
        _shootTime = Time.time;

        if (bullet != null)
        {
            var t = transform;
            var newBullet = Instantiate(bullet, t.position, t.rotation);
            stats.shotsCount++;
        }
        else
        {
            Debug.LogError("[SHOOT ABILITY] No bullet prefab link!");
        }
    }
}
