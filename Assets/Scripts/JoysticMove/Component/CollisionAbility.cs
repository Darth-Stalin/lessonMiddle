using System.Collections;
using System.Collections.Generic;
using lesson2M.Assets.Scripts.JoysticMove.Component.Interfaces;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using UtilitCode;

public class CollisionAbility : MonoBehaviour, IConvertGameObjectToEntity, IAbility
{
    public Collider Collider;

    public List<MonoBehaviour> collisionActions = new List<MonoBehaviour>();
    public List<IAbility> collisionActionsAbilities = new List<IAbility>();

    [HideInInspector] public List<Collider> collisions;

    private void Start()
    {
        foreach (var action in collisionActions)
        {
            if (action is IAbility ability)
            {
                collisionActionsAbilities.Add(ability);
            }
            else
            {
                Debug.LogError("Collision action must from IAbility!!!");
            }
        }
    }

    public void Execute()
    {
        foreach (var action in collisionActionsAbilities)
        {
            if (action is IAbilityTarget actionTarget)
            {
                actionTarget.Targets = new List<GameObject>();
                collisions.ForEach(c =>
                {
                    if (c != null) actionTarget.Targets.Add(c.gameObject);
                });
                
            }
            action.Execute();
            
        }
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        //пересчитываем локальные координаты коллайдеров в мировые(глобальные)
        float3 position = gameObject.transform.position; //
        switch (Collider)
        {
            case SphereCollider sphere:
                sphere.ToWorldSpaceSphere(out var spereCenter, out var sphereRadius);
                dstManager.AddComponentData(entity, new ActorColliderData
                {
                    ColliderType = ColliderType.Sphere,
                    SphereCenter = spereCenter - position,
                    SphereRadius = sphereRadius,
                    initialTakeOff = true
                });
                break;
            case CapsuleCollider capsule:
                capsule.ToWorldSpaceCapsule(out var capsuleStart, out var capsuleEnd, out var capsuleRadius);
                dstManager.AddComponentData(entity, new ActorColliderData
                {
                    ColliderType = ColliderType.Capsule,
                    CapsuleStart = capsuleStart - position,
                    CapsuleEnd = capsuleEnd,
                    CapsuleRadius = capsuleRadius,
                    initialTakeOff = true
                });
                break;
            case BoxCollider box:
                box.ToWorldSpaceBox(out var boxCenter, out var boxHalfExtents, out var boxOrientation);
                dstManager.AddComponentData(entity, new ActorColliderData
                {
                    ColliderType = ColliderType.Box,
                    BoxCenter = boxCenter - position,
                    BoxHalfExtents = boxHalfExtents,
                    BoxOrientation = boxOrientation,
                    initialTakeOff = true
                });
                break;

        }
        Collider.enabled = false;

    }
}

//Описываем какие коллайдеры есть у нас на этой сущности
public struct ActorColliderData : IComponentData
{
    public ColliderType ColliderType;
    public float3 SphereCenter;
    public float SphereRadius;
    public float3 CapsuleStart;
    public float3 CapsuleEnd;
    public float CapsuleRadius;
    public float3 BoxCenter;
    public float3 BoxHalfExtents;
    public quaternion BoxOrientation;
    public bool initialTakeOff;
}

//Описание типов коллайдера
public enum ColliderType
{
    Sphere = 0,
    Capsule = 1,
    Box = 2
}
