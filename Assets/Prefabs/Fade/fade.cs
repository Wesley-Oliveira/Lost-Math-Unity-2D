using UnityEngine;
using System.Collections;

public class fade : MonoBehaviour {

	private		SpriteRenderer fadeTexture;
	public		float fadeSpeed;


	// Use this for initialization
	void Start () {
		fadeTexture = GetComponent<SpriteRenderer> ();

		StartCoroutine ("fadeOut");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	IEnumerator fadeOut()
	{
		Color cor = new Color (0, 0, 0, 1); // criou a cor preta
		fadeTexture.material.color = cor;

		for (float f = 1; f > 0; f -= fadeSpeed) 
		{
			cor.a = f;
			fadeTexture.material.color = cor;
			yield return new WaitForEndOfFrame ();
		}
	}

	IEnumerator fadeIn()
	{
		Color cor = new Color (0, 0, 0, 0); // criou a cor preta
		fadeTexture.material.color = cor;

		for (float f = 0; f > 1; f -= fadeSpeed) 
		{
			cor.a = f;
			fadeTexture.material.color = cor;
			yield return new WaitForEndOfFrame ();
		}
	}
}

