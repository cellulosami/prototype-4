using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private GameObject player;
    private float timeSinceInstantiation = 0.0f;
    private float movementDelay = 3.0f;
    private float bottomBound = -30.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceInstantiation += Time.deltaTime;

        //start moving toward player after movement delay
        if (timeSinceInstantiation >= movementDelay) {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            rb.AddForce(lookDirection * speed);
        }

        //destroy out of bounds
        if (transform.position.y <= bottomBound) {
            Destroy(gameObject);
        }
    }
}
