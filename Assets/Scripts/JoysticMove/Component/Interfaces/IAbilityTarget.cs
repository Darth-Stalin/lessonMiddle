using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace lesson2M.Assets.Scripts.JoysticMove.Component.Interfaces
{
    public interface IAbilityTarget: IAbility
    {
        List<GameObject> Targets { get; set; }
    }
}