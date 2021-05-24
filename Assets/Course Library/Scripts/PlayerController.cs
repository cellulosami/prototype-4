using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private GameObject focalPoint;
    public GameObject powerupIndicator;

    //powerup variables
    public bool hasPowerup = false;
    public float knockbackStrength;
    public float powerupDuration;
    public float powerupMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("Focal Point");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //move player
        if (rb.velocity.magnitude < 7.0f) {
            float verticalInput = Input.GetAxis("Vertical");
            rb.AddForce(focalPoint.transform.forward * speed * verticalInput);
        } 
    }

    private void OnTriggerEnter(Collider other) {
        //give player powerup upon pickup
        if (other.gameObject.CompareTag("Powerup")) {
            knockbackStrength *= powerupMultiplier;
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine() {
        //track powerup duration
        yield return new WaitForSeconds(powerupDuration);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
        knockbackStrength /= powerupMultiplier;
    }

    private void OnCollisionEnter(Collision other) {
        //knock away enemies
        if (other.gameObject.CompareTag("Enemy")) {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * knockbackStrength, ForceMode.Impulse);
        }
    }
}
