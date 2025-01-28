using System.Collections;
using System.Collections.Generic;
using lesson2M.Assets.Scripts.JoysticMove.Component.Interfaces;
using Unity.Entities;
using UnityEngine;

public class BehaviorManager : MonoBehaviour, IConvertGameObjectToEntity
{
    public List<MonoBehaviour> behaviours;
    public IBehaviour activeBehaviour;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponent<AIAgent>(entity);
    }
}

public struct AIAgent : IComponentData
{
    
}

