using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerkAbility : MonoBehaviour, IAbility
{
    private const float Distance = 0.1f;

    [SerializeField] private float _distance;
    [SerializeField] private float _speed;
    [SerializeField] private float _coolDown;

    private Vector3 _endPoint;
    private float _time;

    public void Execute()
    {
        if (_time > Time.time)
            return;
        _time = Time.time + _coolDown;
        _endPoint = transform.position + transform.forward * _distance;

        transform.position += transform.forward * _speed * Time.deltaTime;
        //StartCoroutine(nameof(Jerk));
    } 
}
