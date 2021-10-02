using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] public GameObject Follow;

    // Update is called once per frame
    void Update()
    {
        if (Follow.transform.position.x > transform.position.x)
        {
            Vector3 newTransform = transform.position;
            newTransform.x = Follow.transform.position.x;
            transform.position = newTransform;
        }
    }
}
