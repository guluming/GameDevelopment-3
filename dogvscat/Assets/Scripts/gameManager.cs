using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject dog;
    public GameObject food;
    public GameObject nomalCat;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeFood", 0.0f, 0.2f);
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
}
