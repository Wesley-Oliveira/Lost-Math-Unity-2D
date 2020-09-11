using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideTraining : MonoBehaviour
{
    public GameObject explosaoPrefab;
    private _GC_Training script_GC;

    void Start()
    {
        script_GC = FindObjectOfType(typeof(_GC_Training)) as _GC_Training;
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
                if (this.gameObject.tag == "Correto")
                {
                    Destroy(this.gameObject);
                    script_GC.pontos += 1;
                    script_GC.perguntando = false;
                    script_GC.tmpspawn = true;
                    script_GC.notaF++;
                    if (script_GC.aux >= 11)
                        script_GC.aux = 20;
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
