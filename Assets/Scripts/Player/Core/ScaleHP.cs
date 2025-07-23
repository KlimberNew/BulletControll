using NTC.MonoCache;
using System;
using UnityEngine;

public class ScaleHP : MonoCache
{    
    [SerializeField] private float criticalEdge;
    public Transform Playerbody => transform;
    public float CriticalEdge => criticalEdge;    
    public float HP => transform.localScale.x;
    public void Init()
    {
        /*
         * MaxHP = Playerbody.localScale.x;
        _hp = Playerbody.localScale.x;
         */
    }
}