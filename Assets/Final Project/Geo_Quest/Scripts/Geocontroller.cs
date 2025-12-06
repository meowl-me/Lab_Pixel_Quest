using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;



public class GeoController : MonoBehaviour
{
    /*
    //string Hello = ("Hello");
    */
    private int varOne = 3;
    public float speed = 5;
    private Rigidbody2D rb;
    public string nextLevel = "Geo_Quest_LevelTwo";
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        /*
        // Debug.Log("Hello World!");
        // string World = ("world");
        // Debug.Log(Hello + World);
        */
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(varOne++);
        /*
        //rb.velocity = new Vector2(-1, rb.velocity.x);
        */
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
        Debug.Log(xInput);

        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            sr.color = Color.blue;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            sr.color = Color.green;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            sr.color = Color.magenta;
        }

        Input.GetKeyDown(KeyCode.Alpha1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
       

        switch (collision.tag)
        {
            case "Death":
            {
                    string thisLevel = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thisLevel);
                    Debug.Log("Death");
                    break;   
            }

            case "Finish":
            {
                    SceneManager.LoadScene(nextLevel);
                    Debug.Log("Finish");
                    break;

            }

        }



    }

    
                
}
