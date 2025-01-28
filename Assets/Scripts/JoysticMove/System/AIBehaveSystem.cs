using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using lesson2M.Assets.Scripts.JoysticMove.Component.Interfaces;
using Unity.Entities;
using UnityEngine;

namespace lesson2M.Assets.Scripts.JoysticMove.System
{
    public class AIBehaveSystem : ComponentSystem
    {
        private EntityQuery _behaveQuery;

        protected override void OnCreate()
        {
            _behaveQuery = GetEntityQuery(ComponentType.ReadOnly<AIAgent>());
        }
        protected override void OnUpdate()
        {
            Entities.With(_behaveQuery).ForEach(
               (Entity entity, BehaviorManager manager) =>
               {
                   manager.activeBehaviour?.Behave();
               });
        }
    }
}