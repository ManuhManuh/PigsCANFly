using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class LaunchManager : MonoBehaviour
{
    [SerializeField] ARRaycastManager raycastManager;
    [SerializeField] GameObject birdPrefab;
    [SerializeField] float launchSpeed = 10.0f;
    [SerializeField] TMP_Text message;

    public bool ObjectPlaced
    {
        get { return objectPlaced; }
        set { objectPlaced = value; }
    }

    private bool objectPlaced;
    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();
    private GameObject currentLaunchable;
    private ParticleSystem trail;

    private void Start()
    {
        objectPlaced = false;
        trail = currentLaunchable.gameObject.GetComponent<ParticleSystem>();

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
            // multi-touch - launch object if placed (intended to vary with touch phase)
            message.text = "Launching...";
            Launch(launchSpeed);
        }
    }

    void PlaceLaunchable(ARRaycastHit hit)
    {
        // instantiate the launchable object at the touch point
        if(currentLaunchable == null)
        {
            currentLaunchable = Instantiate(birdPrefab, hit.pose.position, hit.pose.rotation);
            objectPlaced = true;
            message.text = "Bird placed - ready to launch!";
        }

    }

    void Launch(float launchSpeed)
    {
        // turn gravity on
        Rigidbody birdRB = currentLaunchable.GetComponent<Rigidbody>();
        if (birdPrefab != null)
        {
            birdRB.useGravity = true;
        }

        // start the particle system
        trail.Play();

        // apply force to object (intended to be toward locked object, i.e., pig)
        birdRB.AddForce(Vector3.up * launchSpeed, ForceMode.Impulse);

        message.text = "Bird has launched!";
    }
}
