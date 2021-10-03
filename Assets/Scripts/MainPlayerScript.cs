using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerScript : MonoBehaviour
{
    [Header("Player Properties")]
    public int MaxHP;
    private int CurrentHP;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
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
