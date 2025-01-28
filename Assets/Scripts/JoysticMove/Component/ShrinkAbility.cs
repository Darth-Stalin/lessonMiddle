using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using lesson2M.Assets.Scripts.JoysticMove.Component.Interfaces;
using UnityEngine;

public class ShrinkAbility : MonoBehaviour, IAbility
{
    public int scaleFactor = (int)0.2f;
    private Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
    }

    public void Execute()
    {
        transform.DOScale(startScale * scaleFactor, 0.3f);
    }
}