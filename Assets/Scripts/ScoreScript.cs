using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private float timestart;
    // Start is called before the first frame update
    void Start()
    {
        timestart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "" + ((int) ((Time.time - timestart) * 8));
    }
}
