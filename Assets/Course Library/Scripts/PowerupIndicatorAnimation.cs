using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupIndicatorAnimation : MonoBehaviour
{
    private Material mat;
    private GameObject player;
    private float colorSpeed = 5.0f;
    private Color startColor = Color.cyan;
    private Color endColor = Color.yellow;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //make indicator follow player
        transform.position = player.transform.position - new Vector3(0, 0.5f, 0);

        //recolor indicator
        Color color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * colorSpeed, 1.0f));
        mat.SetColor("_Color", color);
    }
}
