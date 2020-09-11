using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLvls : MonoBehaviour
{
    public GameObject bloco1, bloco2, bloco3, next, back;
    private int local;
    // Use this for initialization
    void Start ()
    {
        bloco1.SetActive(true);
        bloco2.SetActive(false);
        bloco3.SetActive(false);
        next.SetActive(true);
        back.SetActive(false);
        local = 0;
    }

    public void Next()
    {
        local++;

        if(local == 1)
        {
            bloco1.SetActive(false);
            bloco2.SetActive(true);
            bloco3.SetActive(false);
            back.SetActive(true);
        }
        else if(local == 2)
        {
            bloco1.SetActive(false);
            bloco2.SetActive(false);
            bloco3.SetActive(true);
            back.SetActive(true);
            next.SetActive(false);
        }
    }

    public void Back()
    {
        local--;

        if (local == 0)
        {
            bloco1.SetActive(true);
            bloco2.SetActive(false);
            bloco3.SetActive(false);
            back.SetActive(false);
        }
        else if (local == 1)
        {
            bloco1.SetActive(false);
            bloco2.SetActive(true);
            bloco3.SetActive(false);
            back.SetActive(true);
            next.SetActive(true);
        }
    }
}
