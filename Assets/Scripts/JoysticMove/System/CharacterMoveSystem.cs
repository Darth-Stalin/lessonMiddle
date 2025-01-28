using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class CharacterMoveSystem : ComponentSystem
{
    private EntityQuery _moveQuery;

    protected override void OnCreate()
    {
        _moveQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(), 
            ComponentType.ReadOnly<MoveData>(),
            ComponentType.ReadOnly<Transform>());
    }
    protected override void OnUpdate()
    {
        Entities.With(_moveQuery).ForEach(
           (Entity entity, Transform transform, ref InputData inputData, ref MoveData move) =>
           {
               Vector3 direction =
                    new Vector3(inputData.Move.x, 0, inputData.Move.y);
               if (direction.sqrMagnitude < 0.01f)
                   return;
               ref var playerTransform = ref transform;
               ref var speed = ref move.Speed;
               playerTransform.position += direction * speed;
               playerTransform.rotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
               /*
               var pos = transform.position;
               pos += new Vector3(inputData.Move.x * move.Speed, 0, inputData.Move.y * move.Speed);
               transform.position = pos;
               */
           });
    }
}
