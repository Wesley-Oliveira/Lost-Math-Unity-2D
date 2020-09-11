using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicio : MonoBehaviour
{
	void Start ()
    {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("VerificaExiste") == false)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("TemaSelecionado", 0);
            PlayerPrefs.SetInt("notaF0", 0);
            PlayerPrefs.SetInt("notaF1", 0);
            PlayerPrefs.SetInt("notaF2", 0);
            PlayerPrefs.SetInt("notaF3", 0);
            PlayerPrefs.SetInt("notaF4", 0);
            PlayerPrefs.SetInt("notaF5", 0);
            PlayerPrefs.SetInt("notaF6", 0);
            PlayerPrefs.SetInt("notaF7", 0);
            PlayerPrefs.SetInt("notaF8", 0);
            PlayerPrefs.SetInt("notaF9", 0);
            PlayerPrefs.SetInt("notaF10", 0);
            PlayerPrefs.SetInt("notaFTemp", 0);
            PlayerPrefs.SetInt("VerificaExiste", 1); //adicionar essa linha pra versão oficial
        }
    }
}
