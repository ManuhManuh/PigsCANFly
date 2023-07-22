using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class LaunchManager : MonoBehaviour
{
    [SerializeField] ARRaycastManager raycastManager;
    [SerializeField] GameObject birdPrefab;
    public bool ObjectPlaced
    {
        get { return objectPlaced; }
        set { objectPlaced = value; }
    }

    private bool objectPlaced;
    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();
    private GameObject currentLaunchable;

    private void Start()
    {
        objectPlaced = false;
        //if(currentLaunchable.GetComponent<ILaunchable>() == null)
        //{
        //    Debug.Log("bird Prefab needs to be type ILaunchable");
        //}
    }
    private void Update()
    {
        // check for touch input
        if (Input.touchCount == 1 && !objectPlaced)
        {
            //place object on plane if not already done
            Vector2 touchPosition = Input.GetTouch(0).position;
            // plane hit?
            if (raycastManager.Raycast(touchPosition, raycastHits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
            {
                ARRaycastHit hit = raycastHits[0];   // closest plane
                PlaceLaunchable(hit);
            }
                
        }
        if (Input.touchCount > 1 && objectPlaced)
        {
            // multi-touch - launch object if placed
            Launch();
        }
    }

    void PlaceLaunchable(ARRaycastHit hit)
    {
        // instantiate the launchable object at the touch point
        if(currentLaunchable == null)
        {
            currentLaunchable = Instantiate(birdPrefab, hit.pose.position, hit.pose.rotation);
            objectPlaced = true;
        }
        //else
        //{
        //    currentLaunchable.transform.position = hit.pose.position;
        //    currentLaunchable.transform.rotation = hit.pose.rotation;
        //}

    }

    void Launch()
    {
        // turn gravity on

        // apply force to object

    }
}
