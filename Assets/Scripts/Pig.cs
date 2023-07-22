using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour, IFlyingTarget
{
    float IFlyingTarget.Stamina => stamina;

    float IFlyingTarget.FlyingSpeed => flyingSpeed;

    [SerializeField] private float stamina;
    [SerializeField] private float flyingSpeed;

    void IFlyingTarget.OnHit(ILaunchable hitBy)
    {
        throw new System.NotImplementedException();
        // calculate damage
        // die if stamina depleted
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Die()
    {

    }
}
