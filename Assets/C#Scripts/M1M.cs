using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1M : MonoBehaviour
{
    public GameObject praent;
    Vector3 Slash;
    Vector3 difference;
    float rotZ = 0;
    bool checker =  true;
    Rigidbody2D parentrb;
    Rigidbody2D rb;
    void Start()
    {
        parentrb = praent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && checker)
        {
            Slash.x = -(transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
            Slash.y = -(transform.position.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            difference = Slash;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(rotZ, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 50);
        }
        else if (Input.GetKeyUp(KeyCode.Q) || !checker)
        {
            rotZ = Mathf.Atan2(parentrb.velocity.x, -parentrb.velocity.y) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(rotZ-90, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 50);
            checker = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (rb.velocity.x < 0.5f)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = this.transform.position;
            Destroy(this);
        }
    }
}
