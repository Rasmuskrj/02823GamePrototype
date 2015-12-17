using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public SurvivalShooter shooter;
    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire = 0;
    

    void Update()
    {
    }

    public void MoveXRaw(float axisx)
    {
        if (Time.time > nextFire)
        {
            float rand = Random.Range(0.9f, 1.5f);
            SoundManager.Instance.shotSound.Play();
            SoundManager.Instance.shotSound.pitch = 1;
            SoundManager.Instance.shotSound.pitch *= rand;
            nextFire = Time.time + fireRate;
            GameObject newShot;
            Rigidbody rb;
            newShot = Instantiate(shot);
            rb = newShot.GetComponent<Rigidbody>();
            newShot.transform.parent = gameObject.transform;
            newShot.transform.localPosition = new Vector3(0f, 0f, 0f);
            newShot.GetComponent<Mover>().shooter = shooter;
            rb.velocity = new Vector3(axisx, 0, 0);
        }
        
    }

    public void MoveYRaw(float axisy)
    {
        if (Time.time > nextFire)
        {
            float rand = Random.Range(0.9f, 1.5f);
            SoundManager.Instance.shotSound.Play();
            SoundManager.Instance.shotSound.pitch = 1;
            SoundManager.Instance.shotSound.pitch *= rand;
            nextFire = Time.time + fireRate;
            GameObject newShot;
            Rigidbody rb;
            newShot = Instantiate(shot);
            rb = newShot.GetComponent<Rigidbody>();
            newShot.transform.parent = gameObject.transform;
            newShot.transform.localPosition = new Vector3(0f, 0f, 0f);
            newShot.GetComponent<Mover>().shooter = shooter;
            rb.velocity = new Vector3(0, axisy, 0);
        }
    }


}