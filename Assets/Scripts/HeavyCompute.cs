using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeavyCompute : MonoBehaviour
{
    [Obsolete]
    public void HeavyMethod()
    {
        var parallel = Observable.WhenAll(
            ObservableWWW.Get("https://www.google.com/"),
            ObservableWWW.Get("https://yu.ru/"),
            ObservableWWW.Get("https://console.cloud.google.com/"));

        parallel.Subscribe(xs =>
        {
            Debug.Log(xs[0].Substring(0,100));
            Debug.Log(xs[1].Substring(0,100));
            Debug.Log(xs[2].Substring(0,100));
        });
    }
}
