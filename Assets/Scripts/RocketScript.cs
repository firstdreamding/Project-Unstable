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
        Vector3 lookPos = player.transform.position - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + -90, Vector3.forward);
        if (!freeze)
        {
            theta += 4f * Time.deltaTime;
        }
    }
}
