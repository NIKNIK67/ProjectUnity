using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1Bottle : MonoBehaviour
{
    public GameObject praent;
    Vector3 Slash;
    Vector3 difference;
    float rotZ = 0;
    bool checker = true;
    Rigidbody2D parentrb;
    Rigidbody2D rb;
    void Start()
    {
        parentrb = praent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) || !checker)
        {
            checker = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("ItsAlive");
        if ((praent.GetComponent<Rigidbody2D>().velocity.y < 0f && (collision.CompareTag("Ground"))) || (collision.CompareTag("Wall")))
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(this.transform.position.x, this.transform.position.y+5, -50);
            Destroy(praent);
        }
        else
        {
            print(praent.GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}
