using UnityEngine;
using System.Collections;

//SCRIPT PARA ROTACIONAR UMA TEXTURA E DAR IMPRESSÃO DE MOVIMENTO
public class MoveOffSet : MonoBehaviour
{
    private Material currentMaterial;
    public float speed;
    public bool centro, diagonal, contrario;
    private float x,y;
    

	// Use this for initialization
	void Start ()
    {
        currentMaterial = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        y += speed * 0.001f;
        x = y;

        if(centro)
            currentMaterial.SetTextureOffset("_MainTex", new Vector2(0, y));
        else if(diagonal)
            currentMaterial.SetTextureOffset("_MainTex", new Vector2(x, y));
        else
            currentMaterial.SetTextureOffset("_MainTex", new Vector2(x, 0));

    }
}
