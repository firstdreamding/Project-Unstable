using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGenerator : MonoBehaviour
{
    public GameObject generator;
    public GameObject AetherPlatform;
    public GameObject Enemy;
    public float EnemyChance = 0.5f;

    private float screenWidth = 480 / 32;
    private float screenHeight = 270 / 32;


    public static bool initialized = false;
    private static Vector3 lastPlatform;
    // Start is called before the first frame update
    void Start()
    {
        if (!initialized)
        {
            initialized = true;
            lastPlatform = new Vector3(GameObject.Find("Player").transform.position.x, 0, 0);
            Instantiate(AetherPlatform, lastPlatform, Quaternion.identity);
            doGeneration(new Vector3(-screenWidth, 0, 0),false);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    private void doGeneration(Vector3 pos, bool doNextGenerator = true)
    {
        Vector3 newLocation = pos + new Vector3(screenWidth, 0, 0);
        if (doNextGenerator)
        {
            Instantiate(generator, newLocation, Quaternion.identity);
        }

        //In case infinite for loop
        int i = 0;
        while (i < 100 && lastPlatform.x < newLocation.x + 2 * screenWidth)
        {
            i++;
            float new_x = Random.Range(4f, 10f);
            float new_y_ceil = Mathf.Min((-0.12f * Mathf.Pow(new_x - 5, 2) + 3) + lastPlatform.y, screenHeight / 2f - 1);
            float new_y = Random.Range(screenHeight / -2f + 1, new_y_ceil);
            lastPlatform = new Vector3(new_x + lastPlatform.x, new_y, 0);
            Instantiate(AetherPlatform, lastPlatform, Quaternion.identity);

            if (Random.Range(0f, 1f) <= EnemyChance)
            {
                //Enemy Generation Casework
                int index = Random.Range(0, 2);
                GameObject creating;
                EnemyScript creatingScript;
                switch (index)
                {
                    case 0:
                        //On top of platform case
                        creating = Instantiate(Enemy, lastPlatform + new Vector3(0, 1), Quaternion.identity);
                        creatingScript = creating.GetComponent<EnemyScript>();
                        creatingScript.TargetPoints[0] = creating.transform.position;
                        if (lastPlatform.y < 0)
                        {
                            creatingScript.TargetPoints[1] = creating.transform.position +
                                new Vector3(0, Mathf.Min(creating.transform.position.y + 6, (screenHeight / 2f) - 0.5f));
                        } else
                        {
                            creatingScript.TargetPoints[1] = creating.transform.position +
                            new Vector3(0, Mathf.Max(creating.transform.position.y - 6, (screenHeight / -2f) + 0.5f));
                        }
                        break;
                    case 1:
                        creating = Instantiate(Enemy, lastPlatform + new Vector3(-4, 1), Quaternion.identity);
                        creatingScript = creating.GetComponent<EnemyScript>();
                        creatingScript.TargetPoints[0] = creating.transform.position;
                        creatingScript.TargetPoints[1] = lastPlatform + new Vector3(4, 1);
                        break;
                }
            }
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
