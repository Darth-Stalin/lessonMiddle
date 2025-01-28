using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class BulletData : MonoBehaviour, IConvertGameObjectToEntity
{
    [SerializeField] private float _speedBullet;
    [SerializeField] private float _destroyTime;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {

        dstManager.AddComponentData(entity, new BulletDat
        {
            SpeedBullet = _speedBullet
        });

        dstManager.AddComponentData(entity, new DestroyTimer
        {
            DestroyTime = _destroyTime
        });

    }
}

public struct BulletDat : IComponentData
{
    public float SpeedBullet;
}

public struct DestroyTimer : IComponentData
{
    public float DestroyTime;
}


