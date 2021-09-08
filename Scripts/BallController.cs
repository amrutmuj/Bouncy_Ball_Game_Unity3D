using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5;

    public Text txtscore;
    int score;

    public ParticleSystem psys;
    public ParticleSystem psysenemy;
    public GameObject gameover;


    bool isGameOver;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!isGameOver)
        {
            float moveH = Input.GetAxis("Horizontal");
            float moveV = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveH, 0.0f, moveV);
            rb.AddForce(movement * speed);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude < 2)
        {
            psys.Stop();
        }
        else
        {
            if (!psys.isPlaying)
            {
                psys.Play();
            } 
        }
       
    }

    // What happens if Ball collides with  the Rewards!
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            // Collection of Coins or Rewards
            Destroy(other.gameObject);
            score++;
            txtscore.text = "Score : " + score;
        }

        if (other.gameObject.tag == "enemy")
        {
            // Game Over
            isGameOver = true;
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;

            psysenemy.Play();
            Destroy(other.gameObject, 1.0f);
            gameover.SetActive(true);
        }
    }

    public void playagainpanel()
    {
        SceneManager.LoadScene("Scene");
    }
}
