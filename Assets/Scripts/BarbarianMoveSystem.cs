using Unity.Entities;
using UnityEngine;

public class BarbarianMoveSystem : ComponentSystem
{
    private EntityQuery _query;
    protected override void OnCreate()
    {
        _query = GetEntityQuery(ComponentType.ReadOnly<BarbarianMoveComponent>());
    }
    protected override void OnUpdate()
    {
        Entities.With(_query).ForEach((Entity entity, Transform transform, BarbarianMoveComponent barbarianMove) => 
        {
            var p = transform.position;
            p.y += (barbarianMove.moveSpeed/1000);
            transform.position = p;
        });
    }
}
