using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour, ILaunchable
{
    float ILaunchable.Damage => damage;

    float ILaunchable.Mass => mass;

    [SerializeField] private float damage;
    [SerializeField] private float mass;

    public void OnLocked(IFlyingTarget target)
    {
        throw new System.NotImplementedException();
        // change the colour of the target to red
        
    }

    public void OnHit(IFlyingTarget target)
    {
        throw new System.NotImplementedException();
        // explode
        // update game status
    }

    public void OnLaunch()
    {
        throw new System.NotImplementedException();
        // apply force
        // start particle system
    }

    public void OnMissed()
    {
        // die
        // tell gameManager that am dead
    }
}
