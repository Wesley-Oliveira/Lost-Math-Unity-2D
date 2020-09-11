using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class NotaFinal : MonoBehaviour
{
    public Text nota;
    public GameObject star1, star2, star3;
    private int idModo;
    private int idTema;


    // Use this for initialization
    void Start()
    { 
        int notaF = PlayerPrefs.GetInt("notaFTemp");

        nota.text = notaF.ToString();

        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

        if (notaF == 11)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        else if (notaF >= 7)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        }
        else if (notaF >= 5)
        {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
        }
    }
}
