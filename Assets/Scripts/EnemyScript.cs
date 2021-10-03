using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Properities")]
    [SerializeField] public int Damage;

    [Header("Points of Movement")]
    [SerializeField] public Vector3[] TargetPoints;
    [SerializeField] public float Speed;

    [Header("Pause Time")]
    [SerializeField] public float ScrunchTime;
    [SerializeField] public float PauseTime;

    private int CurrentIndex = 0;
    private float lastScrunch = 0;

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
    void FixedUpdate()
    {
        if (lastScrunch <= Time.time)
        {
            float step = Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, TargetPoints[CurrentIndex], step);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, TargetPoints[CurrentIndex]) < 0.001f)
            {
                CurrentIndex = (CurrentIndex + 1) % TargetPoints.Length;
                StartCoroutine(JumpSqueeze(1.25f, 0.8f, ScrunchTime, PauseTime));
                lastScrunch = Time.time + PauseTime;
            }
        }
    }

    IEnumerator JumpSqueeze(float xSqueeze, float ySqueeze, float seconds, float pausetime)
    {
        yield return new WaitForSeconds(pausetime - seconds);
        Vector3 originalSize = Vector3.one;
        Vector3 newSize = new Vector3(xSqueeze, ySqueeze, originalSize.z);
        float t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.localScale = Vector3.Lerp(originalSize, newSize, t);
            yield return null;
        }
        t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.localScale = Vector3.Lerp(newSize, originalSize, t);
            yield return null;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<MainPlayerScript>().PlayerHit(Damage);
        }
    }
}
