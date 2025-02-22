using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class CharacterJerkSystem : ComponentSystem
{
    private EntityQuery     _jerkQuery;

    protected override void OnCreate()
    {
        _jerkQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(),
                                    ComponentType.ReadOnly<JerkData>(),
                                    ComponentType.ReadOnly<UserInputData>()
                                    );
    }

    protected override void OnUpdate()
    {
        Entities.With(_jerkQuery).ForEach(
           (Entity entity, UserInputData userInputData, ref InputData inputData) =>
           {
               if (inputData.Jerk > 0f && userInputData.JerkAbility is IAbility jerkAbility)
               {
                   jerkAbility.Execute();
               }
           });
    }
}
