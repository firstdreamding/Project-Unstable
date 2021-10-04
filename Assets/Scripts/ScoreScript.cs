using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private float timestart;
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        timestart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        score = (int)((Time.time - timestart) * 8);
        GetComponent<Text>().text = "" + score;
    }
}
