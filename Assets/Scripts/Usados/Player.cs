using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private _GC script_GC;

    private Rigidbody2D playerRb;
    private Animator playerAnimator;

    public float velocidade;
    private int direcao;

    public GameObject explosaoPrefab;
    private Transform left, right;

	// Use this for initialization
	void Start ()
    {
        script_GC = FindObjectOfType(typeof(_GC)) as _GC;
        left = GameObject.Find("Left").transform;
        right = GameObject.Find("Right").transform;

        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {   
        float horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.touchCount > 0)
        {
            float Pos_TouchA = Input.touches[0].position.x;

            if (Pos_TouchA < Screen.width / 2)
            {
                horizontal = -1;
                direcao = 1;                
            }
            else if (Pos_TouchA > Screen.width / 2)
            {
                horizontal = 1;
                direcao = -1;                
            }
            else
            {
                direcao = 0;
            }
        }
        else
        {
            if (horizontal < 0)
                direcao = 1;
            else if (horizontal == 0)
                direcao = 0;
            else if (horizontal > 0)
                direcao = -1;
        }

        playerRb.velocity = new Vector2(horizontal * velocidade, playerRb.velocity.y);
        playerAnimator.SetInteger("Direcao", direcao);

        if (transform.position.x < left.position.x)
        {
            transform.position = new Vector3(left.position.x, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > right.position.x)
        {
            transform.position = new Vector3(right.position.x, transform.position.y, transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag != "Correto" && col.gameObject.tag != "Meteoro")
        {
            PlayerPrefs.SetInt("notaFTemp", script_GC.pontos);
            explodir();
            script_GC.morreuPlayer = true;
        }            
    }

    void explodir()
    {
        GameObject tempPrefab = Instantiate(explosaoPrefab) as GameObject;
        tempPrefab.transform.position = transform.position;
        Destroy(this.gameObject);
    }
}
