using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour
{
    public float time = 3;
    public float HP = 50;
    public GameObject pl;
    SpriteRenderer sr;
    Rigidbody2D rb;
    public GameObject Coin;
    public GameObject LSpref;
    public GameObject RSpref;
    public GameObject EBpref;
    public GameObject GA;
    First Damage;


    void Start()
    {
        Damage = GameObject.FindGameObjectWithTag("Player").GetComponent<First>();
        pl = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Atacking());
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        print("adwdaw");
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
                RandomVar = Random.Range(70, 200);
                for (int i = 0; i < RandomVar; i += 1)
                {
                    Instantiate(Coin, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }
    }
    IEnumerator Atacking()
    {
        int r = 6;
        while (true)
        {
            yield return new WaitForSeconds(time);
            if (HP < 70)
            {
                r = 5;
            }
            switch (Random.Range(1, r))
            {
                case 1:
                    UseRight(true);
                    if (HP > 50)
                    {
                        time = 6;
                    }
                    else
                    {
                        time = 8;
                    }
                    break;
                case 2:
                    if (HP> 50) 
                    {
                        time = 6;
                    }
                    else
                    {
                        time = 8;
                    }
                    UseLeft(true);
                    break;
                case 3:
                    time = 8;
                    UseRight(false);
                    UseLeft(false);
                    break;
                case 4:
                    EB();
                    time = 9;
                    break;
                case 5:
                    GAs();
                    time = 3;
                    break;
            }
        }
    }
    void GAs()
    {
        Instantiate(GA, Vector2.zero, Quaternion.identity);
    }
    void UseRight(bool all)
    {
        float t = 0;
        if (!all && HP < 70)
        {
            t += 1;
        }
    
        Instantiate(RSpref, new Vector3(74.8f, -2.6f, 100), Quaternion.identity);
        if (HP < 50 && all)
        {
            Instantiate(RSpref, new Vector3(74.8f, -1.1F, 100),Quaternion.identity);
        }
        GameObject[] spires = GameObject.FindGameObjectsWithTag("Right");
        foreach (GameObject spire in spires)
        {
           spire.GetComponent<Boss2SpireScript>().Atack = true;
           spire.GetComponent<Boss2SpireScript>().Times = t;
            if (!all)
            {
                spire.GetComponent<Boss2SpireScript>().speed = 0.8f;
            }
            t += 0.1f;
            if (t == 1.2f && all)
            {
                t += 1;
            }
        }
    }
    void UseLeft(bool all)
    {
        float t = 0;
        if (!all && HP < 70)
        {
            t += 1;
            Instantiate(GA, Vector2.zero, Quaternion.identity);
        }
        print("Left");
        Instantiate(LSpref, new Vector3(-82.4f, -2.6f, 100), Quaternion.identity);
        if (HP < 50 && all)
        {

            Instantiate(LSpref, new Vector3(-82.4f, -1.1f, 100), Quaternion.identity);
        }
        GameObject[] spires = GameObject.FindGameObjectsWithTag("Left");
        foreach (GameObject spire in spires)
        {
            spire.GetComponent<Boss2SpireScript>().Atack = true;
            spire.GetComponent<Boss2SpireScript>().Times = t;
            if (!all)
            {
                spire.GetComponent<Boss2SpireScript>().speed = 0.8f;
            }
            t += 0.1f;
            if (t == 1.2f && all)
            {
                t += 1;
            }

        }
    }
    void EB()
    {
        Instantiate(EBpref, new Vector2(transform.position.x + 20, transform.position.y + 15), Quaternion.identity);
        Instantiate(EBpref, new Vector2(transform.position.x - 20, transform.position.y + 15), new Quaternion(0,0,180,0));
        if (HP < 60)
        {
            Instantiate(EBpref, new Vector2(transform.position.x, transform.position.y + 30), new Quaternion(0, 0,-90, 0));
        }
    }
    void BecomeWhite()
    {
        sr.color = Color.white;
    }
}

