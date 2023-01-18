using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{
    float full = 5f;
    float energy = 0f;
    bool isFull = false;

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-8.5f, 8.5f);
        float y = 30f;
        transform.position = new Vector3(x, y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (energy < full)
        {
            transform.position += new Vector3(0, -0.025f, 0);

            if (transform.position.y < -16f) {
                gameManager.I.gameOver();
            }
        }
        else {
            if (transform.position.x > 0)
            {
                transform.position += new Vector3(0.05f, 0, 0);
            }
            else {
                transform.position += new Vector3(-0.05f, 0, 0);
            }

            if (isFull == false) {
                gameManager.I.addCat();
                gameObject.transform.Find("hungry").gameObject.SetActive(false);
                gameObject.transform.Find("full").gameObject.SetActive(true);

                isFull = true;
            }

            Destroy(gameObject, 3f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "food") {
            if (energy < full)
            {
                energy += 1.0f;
                Destroy(collision.gameObject);
                gameObject.transform.Find("hungry/Canvas/front").transform.localScale = new Vector3(energy / full, 1.0f, 1.0f);
            }
        }
    }
}
