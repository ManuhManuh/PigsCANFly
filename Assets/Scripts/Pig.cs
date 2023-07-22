using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour, IFlyingTarget
{
    float IFlyingTarget.Stamina => stamina;
    float IFlyingTarget.FlyingSpeed => flyingSpeed;

    [SerializeField] private float stamina;
    [SerializeField] private float flyingSpeed;
    [SerializeField] private float startPositionBoxSize;
    [SerializeField] private ParticleSystem deathShow;

    private Vector3 target;
    public void OnHit(ILaunchable hitBy)
    {
        // calculate damage
        stamina = stamina - hitBy.Damage;
        if (stamina <= 0)
        {
            // die if stamina depleted
            Die();
            
        }
        
        
    }

    private void Awake()
    {
        target = RandomPosition();
    }

    void Update()
    {
        // check to see if the pig has (nearly) reached the target
        if (Vector3.Distance(gameObject.transform.position, target) < 0.1f)
        {
            // Target reached - change to next target in list
            target = RandomPosition();
        }

        else
        {
            // Target not reached - move closer to it
            FlyTowardTarget();
        }
    }

    private void FlyTowardTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, flyingSpeed * Time.deltaTime);
    }


    public void Die()
    {
        StartCoroutine(PerformTheDeath());
    }

    public IEnumerator PerformTheDeath()
    {
        // play the death particles and wait
        deathShow.Play();
        yield return new WaitForSeconds(1.0f);

        // tell GameManager that am dead
        GameManager.instance.OnDied(gameObject);

        // actually die
        Destroy(gameObject);
    }

    private Vector3 RandomPosition()
    {
        float x = Random.Range(startPositionBoxSize * -1, startPositionBoxSize);
        float y = Random.Range(startPositionBoxSize * -1, startPositionBoxSize);
        float z = Random.Range(startPositionBoxSize * -1, startPositionBoxSize);

        return new Vector3(x, y, z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bird"))
        {
            OnHit(collision.gameObject.GetComponent<ILaunchable>());
        }
    }
}
