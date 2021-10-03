using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject followObject;
    public float speed = 2f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = followObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 follow = followObject.transform.position;
        float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        Vector3 newPosition = transform.position;
        newPosition.x += 1000;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
    }
}