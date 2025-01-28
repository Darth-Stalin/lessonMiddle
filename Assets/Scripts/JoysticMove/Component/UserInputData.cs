using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class UserInputData : MonoBehaviour, IConvertGameObjectToEntity
{
    public MonoBehaviour JerkAbility => _jerkAbility;

    public float speed;
    public string moveAnimHash;
    public MonoBehaviour ShootAction;
    public string moveAnimSpeedHash;
    [SerializeField] private MonoBehaviour _jerkAbility;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new InputData());
        dstManager.AddComponentData(entity, new MoveData
        {
            Speed = speed/100
        });

        if (ShootAction != null && ShootAction is IAbility)
        {
            dstManager.AddComponentData(entity, new ShootData());
        }

        if (_jerkAbility != null && _jerkAbility is IAbility jerkAbility)
        {
            dstManager.AddComponentData(entity, new JerkData());
        }

        if (moveAnimHash != String.Empty)
        {
            dstManager.AddComponentData(entity, new AnimData());
        }
    }
}

public struct InputData : IComponentData
{
    public float2 Move;
    public float Shoot;
    public float Jerk;
}

public struct MoveData : IComponentData
{
    public float Speed;
}

public struct ShootData: IComponentData
{

}

public struct JerkData : IComponentData
{

}

public struct AnimData : IComponentData
{

}