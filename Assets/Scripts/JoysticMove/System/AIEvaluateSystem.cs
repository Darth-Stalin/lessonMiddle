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
    public class AIEvaluateSystem: ComponentSystem
    {
            private EntityQuery _evaluateQuery;

    protected override void OnCreate()
    {
        _evaluateQuery = GetEntityQuery(ComponentType.ReadOnly<AIAgent>());
    }
    protected override void OnUpdate()
    {
        Entities.With(_evaluateQuery).ForEach(
           (Entity entity, BehaviorManager manager) =>
           {
                
                float highScore = float.MinValue;

                manager.activeBehaviour = null;
                foreach (var behaviour in manager.behaviours)
                {
                    if (behaviour is IBehaviour ai)
                    {
                        var currentScore = ai.Evaluate();
                        if (currentScore > highScore)
                        {
                            highScore = currentScore;
                            manager.activeBehaviour =ai;
                        }  
                    }
                }
           });
    }
    }
}