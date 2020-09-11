using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public GameObject explosaoPrefab;
    private _GC script_GC;

    void Start()
    {
        script_GC = FindObjectOfType(typeof(_GC)) as _GC;
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Player":
                if(this.gameObject.tag == "Correto")
                {  
                    Destroy(this.gameObject);
                    script_GC.pontos += 50;
                    script_GC.perguntando = false;
                    explosao();          
                }
                break;
        }
    }

    void explosao()
    {
        GameObject tempPrefab = Instantiate(explosaoPrefab) as GameObject;
        tempPrefab.transform.position = transform.position;
        Destroy(this.gameObject);
    }
}
