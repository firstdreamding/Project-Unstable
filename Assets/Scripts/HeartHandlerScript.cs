using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartHandlerScript : MonoBehaviour
{
    public Sprite heartFull;
    public Sprite heartDead;

    public static HeartHandlerScript hs;

    // Start is called before the first frame update
    void Start()
    {
        if (hs == null)
        {
            hs = this;
        }
    }
    
    public void OnChange(int hp)
    {
        for (int i = 1; i <= 3; i++)
        {
            if (hp >= i)
            {
                transform.Find("HP" + i).GetComponent<Image>().sprite = heartFull;
            } else
            {
                transform.Find("HP" + i).GetComponent<Image>().sprite = heartDead;
            }
        }
    }
}
