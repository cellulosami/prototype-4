using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAnimation : MonoBehaviour
{
    private float speed = 1.0f;
    private float timeSinceInstantiation = 0.0f;
    private float transitionDuration = 1.0f;
    private float pickupDuration = 10.0f;
    Renderer rend;
    Color color = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceInstantiation += Time.deltaTime;

        //rotate pickup
        transform.Rotate(0, 1 * speed, 0);

        //increase opacity until 100%
        if (timeSinceInstantiation <= transitionDuration + 0.1f) {
            float t = timeSinceInstantiation / transitionDuration;
            color.a = Mathf.SmoothStep(0.0f, 1.0f, t);
            rend.material.SetColor("_Color", color);
        }
        //despawn pickup
        else if (timeSinceInstantiation >= pickupDuration) {
            float t = (timeSinceInstantiation - pickupDuration) / transitionDuration;
            color.a = Mathf.SmoothStep(1.0f, 0.0f, t);
            rend.material.SetColor("_Color", color);
        }
        if (timeSinceInstantiation >= pickupDuration + transitionDuration + 0.1f) {
            Destroy(gameObject);
        }

        
    }
}
