using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float HP = 50;
    public GameObject pl;
    SpriteRenderer sr;
    Rigidbody2D rb;
    public GameObject LSpref;
    public GameObject RSpref;

    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Atacking());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Atacking()
    {
        while (true)
        {
            yield return new WaitForSeconds(8);
            switch (Random.Range(1, 4))
            {
                case 1:
                    UseRight(true);
                    break;
                case 2:
                    UseLeft(true);
                    break;
                case 3:
                    UseRight(false);
                    UseLeft(false);
                    break;
            }
        }
    }
    void UseRight(bool all)
    {
        print("Right");
        float t = 0;
        Instantiate(RSpref, new Vector3(74.8f, -2.6f, 100), Quaternion.identity);
        if (HP < 35 && all)
        {
            Instantiate(RSpref, new Vector3(74.8f, -10.2F, 100), new Quaternion(180, 0,0,0));
        }
        GameObject[] spires = GameObject.FindGameObjectsWithTag("Right");
        foreach (GameObject spire in spires)
        {
           spire.GetComponent<Boss2SpireScript>().Atack = true;
           spire.GetComponent<Boss2SpireScript>().Times = t;
            t += 0.1f;
            if (t == 1.2f)
            {
                t += 1;
            }
        }
    }
    void UseLeft(bool all)
    {
        float t = 0;
        print("Left");
        Instantiate(LSpref, new Vector3(-82.4f, -2.6f, 100), Quaternion.identity);
        if (HP < 35 && all)
        {
            Instantiate(LSpref, new Vector3(-82.4f, -10.2F, 100), new Quaternion(180, 0, 0, 0));
        }
        GameObject[] spires = GameObject.FindGameObjectsWithTag("Left");
        foreach (GameObject spire in spires)
        {
            spire.GetComponent<Boss2SpireScript>().Atack = true;
            spire.GetComponent<Boss2SpireScript>().Times = t;
            t += 0.1f;
            if (t == 1.2f)
            {
                t += 1;
            }

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.CompareTag("HPPrefab"))
            {
                sr.color = Color.red;
                HP -= 1;
                Invoke("BecomeWhite", 0.2f);
                if (HP > 0)
                {
                    rb.AddForce(transform.up * 300, ForceMode2D.Impulse);
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
