using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class BulletMoveSystem : ComponentSystem
{
    private EntityQuery _bulletQuery;

    protected override void OnCreate()
    {
        _bulletQuery = GetEntityQuery(
            ComponentType.ReadOnly<BulletData>(),
            ComponentType.ReadOnly<Transform>()
            );
    }
    protected override void OnUpdate()
    {
        Entities.With(_bulletQuery).ForEach(
           (Entity entity, Transform transform, ref BulletDat bulletData) =>
           {
               ref var bulletTransfform = ref transform;

               bulletTransfform.position += bulletTransfform.forward * bulletData.SpeedBullet * Time.DeltaTime;

           });
    }
}
