using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGenerator : MonoBehaviour
{
    public GameObject generator;
    public GameObject AetherPlatform;
    private float screenWidth = 480 / 32;
    private float screenHeight = 270 / 32;


    public static bool initialized = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!initialized)
        {
            initialized = true;
            doGeneration(new Vector3(-screenWidth, 0, 0),false);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    private void doGeneration(Vector3 pos, bool doNextGenerator = true)
    {
        Vector3 newLocation =pos + new Vector3(screenWidth, 0, 0);
        if (doNextGenerator)
        {
            Instantiate(generator, newLocation, Quaternion.identity);
        }
        for (int i = 0; i < 10;++i)
        {
            Vector3 platformLoc = newLocation + new Vector3(screenWidth + screenWidth * Random.Range(-0.5f, 0.5f), screenHeight * Random.Range(-0.5f, 0.5f), 0);
            Instantiate(AetherPlatform, platformLoc, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("NEW GENER");
            doGeneration(gameObject.transform.position);
            Destroy(gameObject);
        }
        
    }
}
