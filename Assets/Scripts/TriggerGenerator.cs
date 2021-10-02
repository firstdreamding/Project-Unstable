using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGenerator : MonoBehaviour
{
    public GameObject generator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void doGeneration()
    {
        Instantiate(generator, gameObject.transform.position +  new Vector3(480/32,0,0),Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("NEW GENER");
            doGeneration();
            Destroy(gameObject);
        }
        
    }
}
