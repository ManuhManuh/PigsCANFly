using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILaunchable 
{
    float Damage { get; }
    float Mass { get; }

    public void OnLocked(IFlyingTarget target);
    public void OnLaunch();
    public void OnHit(IFlyingTarget target);
    public void OnMissed();

}
