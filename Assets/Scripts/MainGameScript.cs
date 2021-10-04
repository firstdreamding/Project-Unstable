using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameScript : MonoBehaviour
{
    [SerializeField] public float MinTime;
    [SerializeField] public float MaxTime;
    [SerializeField] public float TimeBeforeSwitch;

    [SerializeField] public GameObject WarningText;
    [SerializeField] public ParticleSystem ps;
    [SerializeField] public GameObject[] dimensions;
    [SerializeField] public GameObject[] dimensionsBack;
    [SerializeField] public GameObject DeathPanel;

    [SerializeField] public GameObject ScoreObject;

    public static readonly int HELL = 0;
    public static readonly int SPACE = 1;
    public static int currentStage = HELL;

    public int upcomingStage = SPACE;
    public bool DangerTime = false;

    // Start is called before the first frame update
    void Start()
    {
        currentStage = HELL;
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
        upcomingStage = currentStage == 0 ? 1 : 0;
        Debug.Log(upcomingStage);

        yield return new WaitForSeconds(TimeBeforeSwitch);
        ps.Play();
        WarningText.SetActive(false);
        currentStage = upcomingStage;

        if (currentStage != SPACE)
        {
            GameObject.Find("Player").GetComponent<BaseMovement>().gravity = 1;
            dimensionsBack[0].SetActive(true);
            dimensionsBack[1].SetActive(false);
            upcomingStage = SPACE;
        } else
        {
            GameObject.Find("Player").GetComponent<BaseMovement>().gravity = 0.6f;
            dimensionsBack[0].SetActive(false);
            dimensionsBack[1].SetActive(true);
            upcomingStage = HELL;
        }

        StartCoroutine(UnstableDimension(Random.Range(MinTime, MaxTime)));
    }

    public void GameOver()
    {
        DeathPanel.SetActive(true);
        Destroy(ScoreObject.GetComponent<ScoreScript>());
        StartCoroutine(GameOverScene(2.25f));
    }

    public IEnumerator GameOverScene(float t)
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene(sceneName: "GameOverScene");
    }
}
