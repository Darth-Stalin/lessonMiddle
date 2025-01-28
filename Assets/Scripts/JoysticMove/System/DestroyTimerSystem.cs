using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class DestroyTimerSystem : ComponentSystem
{

    private EntityQuery _timerQuery;
    private EntityManager _entityManager;

    protected override void OnCreate()
    {
        _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        _timerQuery = GetEntityQuery(ComponentType.ReadOnly<Transform>(),
                                     ComponentType.ReadOnly<DestroyTimer>()
                                     );
    }
    protected override void OnUpdate()
    {
        Entities.With(_timerQuery).ForEach(
           (Entity entity, Transform transform, ref DestroyTimer destroyTimer) =>
           {
               ref var time = ref destroyTimer.DestroyTime;
               time -= Time.DeltaTime;
               if (time <= 0)
               {
                   _entityManager.DestroyEntity(entity);
                   Object.Destroy(transform.gameObject);
               }
           });
    }
}
