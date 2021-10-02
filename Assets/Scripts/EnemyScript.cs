using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] public Vector3[] TargetPoints;
    [SerializeField] public float speed;

    private int CurrentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (TargetPoints.Length <= 1)
        {
            Debug.LogError("Enemy Script missing TargetPoints");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, TargetPoints[CurrentIndex], step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, TargetPoints[CurrentIndex]) < 0.001f)
        {
            CurrentIndex = (CurrentIndex + 1) % TargetPoints.Length;
        }
    }
}
