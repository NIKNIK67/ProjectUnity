using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1 : MonoBehaviour
{
    GameObject _player;
    Vector3 Slash;
    public Vector3 difference;
    Rigidbody2D rb;
    public LineM1 R;
    float rotZ = 0;
    bool checker = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && checker)
        {
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + 15, -15);
            Slash.x = (transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
            Slash.y = -(transform.position.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            difference = Slash;
            R.ShowTR(transform.position, new Vector2(-difference.normalized.x, difference.normalized.y) * 40);
        }
        else if (Input.GetKeyUp(KeyCode.Q) || !checker)
        {
            if (checker)
            {
                Invoke("Ds", 4);
                rb.gravityScale = 3;
                rb.AddForce(new Vector2(-difference.normalized.x, difference.normalized.y) * 70, ForceMode2D.Impulse);
            }
            checker = false;
        }
    }
    private void Ds()
    {
        Destroy(gameObject);
    }
}
