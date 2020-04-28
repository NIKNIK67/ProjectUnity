using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GromBirdScript : MonoBehaviour
{
    First Damage;
    public GameObject Bullet;
    public float HP = 12;
    public Vector2 p1;
    public Vector2 p2;
    public Vector2 p3;
    public Vector2 p4;
    SpriteRenderer sr;
    int Position;
    Vector2[] positions  =new Vector2[4];
    void Start()
    {
        Damage = GameObject.FindGameObjectWithTag("Player").GetComponent<First>();
        StartCoroutine(NewPositon());
        sr = GetComponent<SpriteRenderer>();
        positions[0] = p1;
        positions[1] = p2;
        positions[2] = p3;
        positions[3] = p4;
    }

    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, positions[Position], 0.05f);
    }
    IEnumerator NewPositon()
    {
        while (true)
        {
            yield return new WaitForSeconds(7);
            Position = Random.Range(0, 4);
            Invoke("CreateBullet", 1f);
        }
    }
    void CreateBullet()
    {
        Instantiate(Bullet, new Vector2(transform.position.x, transform.position.y + 15), Quaternion.identity);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("HPPrefab"))
        {
            sr.color = Color.red;
            HP -= Damage.Damage;
            Invoke("BecomeWhite", 0.2f);
            if (HP > 0)
            {
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    void BecomeWhite()
    {
        sr.color = Color.white;
    }
}
