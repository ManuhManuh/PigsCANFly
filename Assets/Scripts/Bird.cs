using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour, ILaunchable
{
    float ILaunchable.Damage => damage;

    float ILaunchable.Mass => mass;

    [SerializeField] private float damage;
    [SerializeField] private float mass;
    [SerializeField] private float maxDistanceFromCamera;

    private LaunchManager launchManager;

    private void Start()
    {
        launchManager = FindObjectOfType<LaunchManager>();
    }
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
        // tell GameManager that am dead
        GameManager.instance.OnDied(gameObject);

        // die
        Destroy(gameObject);
    }

    private void Update()
    {
        // self destruct if too far from camera
        if(Vector3.Distance(gameObject.transform.position, Camera.main.transform.position) > maxDistanceFromCamera)
        {
            OnMissed();
        }
    }
}
