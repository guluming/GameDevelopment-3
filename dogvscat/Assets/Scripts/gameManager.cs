using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public GameObject dog;
    public GameObject food;
    public GameObject nomalCat;
    public GameObject fatCat;
    public GameObject pirateCat;
    public GameObject retryBtn;
    public GameObject levelFront;
    public Text levelText;
    public static gameManager I;

    int level = 0;
    int cat = 0;

    void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
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

        if (level == 1) {
            float p = Random.Range(0, 10);
            if (p < 2) {
                Instantiate(nomalCat);
            }
        } else if (level == 2) {
            float p = Random.Range(0, 10);
            if (p < 5)
            {
                Instantiate(nomalCat);
            }
        } else if (level == 3) {
            float p = Random.Range(0, 10);
            if (p < 6)
            {
                Instantiate(nomalCat);
            }
            Instantiate(fatCat);
        } else if (level >=4) {
            float p = Random.Range(0, 10);
            if (p < 5)
            {
                Instantiate(nomalCat);
            }
            Instantiate(fatCat);
            Instantiate(pirateCat);
        }
    }

    public void gameOver() 
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0f;
    }

    public void addCat() 
    {
        cat += 1;
        level = cat / 5;

        levelText.text = level.ToString();
        levelFront.transform.localScale = new Vector3((cat - level * 5) / 5.0f, 1.0f, 1.0f);
    }
}
