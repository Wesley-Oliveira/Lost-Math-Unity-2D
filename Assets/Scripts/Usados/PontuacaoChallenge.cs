using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PontuacaoChallenge : MonoBehaviour
{
    public Text ponto;

	void Start ()
    {
        ponto.text = PlayerPrefs.GetInt("notaFTemp").ToString();	
	}
}
