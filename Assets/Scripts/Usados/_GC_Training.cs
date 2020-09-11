using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class _GC_Training : MonoBehaviour
{
    public Text perguntaValor1txt, perguntaValor2Txt, score;
    public GameObject perguntaPanel, asteroide, canvasPai;
    public Transform local1, local2, local3;
    public bool perguntando, morreuPlayer, tmpspawn;
    public int pontos, aux, notaF; //notaf = recorde
    private bool contar;
    private float time, delay;
    private int valor1, valor2, resposta, recorde;
    
    // Use this for initialization
    void Start()
    {
        perguntaPanel.SetActive(false);
        perguntando = false;
        morreuPlayer = false;
        contar = false;
        pontos = 0;
        time = 0;
        valor1 = PlayerPrefs.GetInt("TemaSelecionado");
        recorde = PlayerPrefs.GetInt("notaF" + PlayerPrefs.GetInt("TemaSelecionado").ToString()); // pego recorde
        notaF = 0;
        valor2 = 0;
        resposta = 0;
        aux = 0;
        tmpspawn = false;

        StartCoroutine("RandomQuests");
    }

    // Update is called once per frame
    void Update()
    {
        score.text = pontos.ToString();

        if(morreuPlayer || aux == 20)
        {
            delay += Time.deltaTime;

            if (delay >= 2f)
            {
                if (notaF > recorde)
                    PlayerPrefs.SetInt("notaF" + PlayerPrefs.GetInt("TemaSelecionado").ToString(), notaF);
                PlayerPrefs.SetInt("notaFTemp", notaF);
                SceneManager.LoadScene("FinalTrainingX");
            }
        }

        if(tmpspawn)
        {
            delay += Time.deltaTime;

            if(delay >= 2)
            {
                StartCoroutine("RandomQuests");
                delay = 0;
                tmpspawn = false;
            }
        }

        if (contar && aux <= 10)
        {
            time += Time.deltaTime;

            if(time <= 0.8f)
            {
                valor2 = Random.Range(0, 11);
                valor2 = aux;
                perguntaValor1txt.text = valor1.ToString() + " ";
                perguntaValor2Txt.text = " " + valor2.ToString();
            }

            if(time >= 3.5f && time <= 4)
            {
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
                    if (resposta == 0)
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
                aux++;
            }
        }
    }

    public IEnumerator RandomQuests()
    {
        perguntando = true;
        perguntaPanel.SetActive(true);
        contar = true;

        yield return new WaitForSeconds(1f);
    }
}