using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameScript : MonoBehaviour
{
    [SerializeField] public float MinTime;
    [SerializeField] public float MaxTime;
    [SerializeField] public float TimeBeforeSwitch;

    [SerializeField] public GameObject WarningText;
    [SerializeField] public ParticleSystem ps;
    [SerializeField] public GameObject[] dimensions;

    public static readonly int HELL = 0;
    public static readonly int SPACE = 1;
    public static int currentStage = SPACE;

    public int upcomingStage = 0;
    public bool DangerTime = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UnstableDimension(Random.Range(MinTime, MaxTime)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator UnstableDimension(float t)
    {
        yield return new WaitForSeconds(t);
        DangerTime = true;
        WarningText.SetActive(true);
 
        while(upcomingStage == currentStage)
        {
            upcomingStage = Random.Range(0, dimensions.Length);
        }

        Debug.Log(upcomingStage);

        yield return new WaitForSeconds(TimeBeforeSwitch);
        ps.Play();
        WarningText.SetActive(false);
    }

    public void GameOver()
    {

    }
}
