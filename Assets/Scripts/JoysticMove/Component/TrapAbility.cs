using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapAbility : CollisionAbility
{
    public int Damage = 10;

    public void Execute()
    {
        foreach (var target in collisions)
        {
            var targetHealth = target?.gameObject?.GetComponent<CharacterHealth>();
            if (targetHealth != null)
            {
                targetHealth.Health -= Damage;
            }
        }
    }
}
