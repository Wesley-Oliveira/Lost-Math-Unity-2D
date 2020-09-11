using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class _GC : MonoBehaviour
{
    public Text perguntaValor1txt, perguntaValor2Txt, score;
    public GameObject perguntaPanel, asteroide, meteoro, canvasPai, sirene;
    public Transform local1, local2, local3, spawn1, spawn2, spawn3, spawn4, spawn5;
    public bool perguntando, morreuPlayer;
    public int pontos;
    private bool contar;
    private float time, contadorIni, delay;
    private int valor1, valor2, resposta;
    

    // Use this for initialization
    void Start()
    {
        sirene.SetActive(false);
        perguntaPanel.SetActive(false);
        perguntando = false;
        morreuPlayer = false;
        contar = false;
        pontos = 0;
        time = 0;
        contadorIni = 0;
        valor1 = 0;
        valor2 = 0;
        resposta = 0;
        StartCoroutine("RandomSpawnMeteoros");
    }

    // Update is called once per frame
    void Update()
    {
        contadorIni += Time.deltaTime;
        score.text = pontos.ToString();

        if(morreuPlayer)
        {
            delay += Time.deltaTime;

            if(delay >= 2f)
                SceneManager.LoadScene("FinalChallenge");
        }

        if(contadorIni >= 25  && contadorIni <= 26)
        {
            contadorIni += 100;
            StartCoroutine("RandomQuests");
        }

        if (contar)
        {
            time += Time.deltaTime;

            if(time <= 0.8f)
            {
                valor1 = Random.Range(0, 11);
                valor2 = Random.Range(0, 11);
                perguntaValor1txt.text = valor1.ToString() + " ";
                perguntaValor2Txt.text = " " + valor2.ToString();
            }

            if(time >= 3.5f && time <= 4)
            {
                sirene.SetActive(false);
                perguntaPanel.SetActive(false);
                resposta = valor1 * valor2;
            }
            if (time >= 5)
            {
                contar = false;
                time = 0;
                
                GameObject tempPrefab1 = Instantiate(asteroide) as GameObject;
                tempPrefab1.transform.parent = canvasPai.transform;
                tempPrefab1.transform.localScale = new Vector3(158.505f, 158.505f, 158.505f);
                tempPrefab1.transform.position = local1.transform.position;
                GameObject tempPrefab1Child = tempPrefab1.transform.GetChild(0).gameObject;
                Text tempValor1 = tempPrefab1Child.GetComponent < Text >();
                
                GameObject tempPrefab2 = Instantiate(asteroide) as GameObject;
                tempPrefab2.transform.parent = canvasPai.transform;
                tempPrefab2.transform.position = local2.transform.position;
                tempPrefab2.transform.localScale = new Vector3(158.505f, 158.505f, 158.505f);
                GameObject tempPrefab2Child = tempPrefab2.transform.GetChild(0).gameObject;
                Text tempValor2 = tempPrefab2Child.GetComponent<Text>();

                GameObject tempPrefab3 = Instantiate(asteroide) as GameObject;
                tempPrefab3.transform.parent = canvasPai.transform;
                tempPrefab3.transform.position = local3.transform.position;
                tempPrefab3.transform.localScale = new Vector3(158.505f, 158.505f, 158.505f);
                GameObject tempPrefab3Child = tempPrefab3.transform.GetChild(0).gameObject;
                Text tempValor3 = tempPrefab3Child.GetComponent<Text>();

                int x = Random.Range(1, 4);

                if (x == 1)
                {
                    tempValor1.text = resposta.ToString();
                    if(resposta == 0)
                    {
                        int t = resposta + 1;
                        int tt = resposta + 2;
                        tempValor2.text = t.ToString();
                        tempValor3.text = tt.ToString();
                    }
                    else
                    {
                        tempValor2.text = (resposta - valor1).ToString();
                        tempValor3.text = (resposta + valor2).ToString();
                    }
                    tempPrefab1.tag = "Correto";
                }
                else if(x == 2)
                {
                    tempValor2.text = resposta.ToString();
                    if (resposta == 0)
                    {
                        int t = resposta + 1;
                        int tt = resposta + 2;
                        tempValor1.text = tt.ToString();
                        tempValor3.text = t.ToString();
                    }
                    else
                    {
                        tempValor1.text = (resposta + valor1).ToString();
                        tempValor3.text = (resposta - valor2).ToString();
                    }                    
                    tempPrefab2.tag = "Correto";
                }
                else
                {
                    tempValor3.text = resposta.ToString();
                    if (resposta == 0)
                    {
                        int t = resposta + 1;
                        int tt = resposta + 2;
                        tempValor1.text = t.ToString();
                        tempValor2.text = tt.ToString();
                    }
                    else
                    {
                        tempValor1.text = (resposta - valor2).ToString();
                        tempValor2.text = (resposta + valor1).ToString();
                    }       
                    tempPrefab3.tag = "Correto";
                }
            }
        }
    }

    IEnumerator RandomQuests()
    {
        sirene.SetActive(true);
        perguntando = true;
        perguntaPanel.SetActive(true);
        contar = true;

        yield return new WaitForSeconds(25f);
        StartCoroutine("RandomQuests");
    }

    IEnumerator RandomSpawnMeteoros()
    {
        if (perguntando == false)
        { 
            int randQuallugar = Random.Range(1, 6);

            if (randQuallugar == 1)
            {
                GameObject temp = Instantiate(meteoro, spawn1.transform.position, spawn1.transform.rotation) as GameObject;
                temp.transform.parent = canvasPai.transform;
                temp.transform.localScale = new Vector3(208.2191f, 208.2191f, 208.2191f);
                temp.transform.position = spawn1.transform.position;
            }
            else if (randQuallugar == 2)
            {
                GameObject temp = Instantiate(meteoro, spawn2.transform.position, spawn2.transform.rotation) as GameObject;
                temp.transform.parent = canvasPai.transform;
                temp.transform.localScale = new Vector3(208.2191f, 208.2191f, 208.2191f);
                temp.transform.position = spawn2.transform.position;
            }
            else if (randQuallugar == 3)
            {
                GameObject temp = Instantiate(meteoro, spawn3.transform.position, spawn3.transform.rotation) as GameObject;
                temp.transform.parent = canvasPai.transform;
                temp.transform.localScale = new Vector3(208.2191f, 208.2191f, 208.2191f);
                temp.transform.position = spawn3.transform.position;
            }
            else if (randQuallugar == 4)
            {
                GameObject temp = Instantiate(meteoro, spawn4.transform.position, spawn4.transform.rotation) as GameObject;
                temp.transform.parent = canvasPai.transform;
                temp.transform.localScale = new Vector3(208.2191f, 208.2191f, 208.2191f);
                temp.transform.position = spawn4.transform.position;
            }
            else if (randQuallugar == 5)
            {
                GameObject temp = Instantiate(meteoro, spawn5.transform.position, spawn5.transform.rotation) as GameObject;
                temp.transform.parent = canvasPai.transform;
                temp.transform.localScale = new Vector3(208.2191f, 208.2191f, 208.2191f);
                temp.transform.position = spawn4.transform.position;
            }
        }
        yield return new WaitForSeconds(5f);
        StartCoroutine("RandomSpawnMeteoros");
    }
}