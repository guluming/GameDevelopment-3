using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject dog;
    public GameObject food;
    public GameObject nomalCat;
    public GameObject retryBtn;
    public static gameManager I;

    void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeFood", 0.0f, 0.1f);
        InvokeRepeating("makeCat", 0.0f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void makeFood() 
    {
        float x = dog.transform.position.x;
        float y = dog.transform.position.y + 2;
        Instantiate(food, new Vector3(x,y,0), Quaternion.identity);
    }

    void makeCat()
    {
        Instantiate(nomalCat);
    }

    public void gameOver() 
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0f;
    }
}
