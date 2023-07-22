using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFlyingTarget 
{
    float Stamina { get; }
    float FlyingSpeed { get;  }

    public void OnHit(ILaunchable hitBy);
    public void Die();

}
