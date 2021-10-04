using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class MainPlayerScript : MonoBehaviour
{
    [Header("Player Properties")]
    public int MaxHP;
    private int CurrentHP;

    private GameObject mainCamera;
    private double halfScreenConst;
    private double lowerScreenConst;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = MaxHP;
        mainCamera = GameObject.Find("Main Camera");
        halfScreenConst = ((Screen.width % 480 + 480) / 32.0) / 2.0;
        lowerScreenConst = ((Screen.width % 270 + 270) / 32.0) / 2.0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= mainCamera.transform.position.x - 0.5 - halfScreenConst)
        {
            Debug.Log("DEAD");
        } else if (transform.position.y <= -1 * lowerScreenConst - 1)
        {
            Debug.Log("DEAD");
        }
    }

    public void PlayerHit(int damage)
    {
        CurrentHP -= damage;
        if (CurrentHP <= 0)
        {
            Debug.Log("ITS GAME OVER BOYSSS");
        }
    }
}
