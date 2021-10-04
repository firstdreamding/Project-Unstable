using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    private GameObject player;
    public readonly float orbitalRadius = 1;
    public bool freeze = false;

    private float theta = Mathf.PI / 2;
    private Vector3 relativePos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        relativePos.x = orbitalRadius * Mathf.Cos(theta);
        relativePos.y = orbitalRadius * Mathf.Sin(theta);
        gameObject.transform.SetPositionAndRotation(player.transform.position + relativePos, Quaternion.identity);
        if (!freeze)
        {
            theta += 0.01f;
        }
    }
}
