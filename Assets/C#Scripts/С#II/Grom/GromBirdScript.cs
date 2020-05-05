using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GromBirdScript : MonoBehaviour
{
    public GameObject Coin;
    public GameObject[] Materials;
    First Damage;
    public GameObject Bullet;
    public float HP = 12;
    public Vector2 p1;
    public Vector2 p2;
    public Vector2 p3;
    public Vector2 p4;
    SpriteRenderer sr;
    int Position;
    GameObject Player;
    Vector2[] positions  =new Vector2[4];
    void Start()
    {
        Damage = GameObject.FindGameObjectWithTag("Player").GetComponent<First>();
        Player = GameObject.FindGameObjectWithTag("Player");
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
            if (Vector2.Distance(transform.position, Player.transform.position) < 300)
            {
                Invoke("CreateBullet", 1f);
            }
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
                int RandomVar;
                RandomVar = Random.Range(30, 35);
                for (int i = 0; i < RandomVar; i += 1)
                {
                    Instantiate(Coin, transform.position, Quaternion.identity);
                }
                int RandomVar2;
                RandomVar2 = Random.Range(2,7);
                for (int i = 0; i < RandomVar2; i += 1)
                {
                    Instantiate(Materials[Random.Range(0, 3)], transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }
    }
    void BecomeWhite()
    {
        sr.color = Color.white;
    }
}
