using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENergyBullet : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject DirectionPoint;
    public GameObject ParticleSystem;
    Vector3 test;
    Vector3 Slash;
    Vector3 difference;
    Vector3 PlayerPosition;
    public float t2;
    float rotZ;
    bool IsCorutinAvaible;
    bool RunAway;
    bool Stay = true;
    void Start()
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
       rb = GetComponent<Rigidbody2D>();
        StartCoroutine(stay());

    }

    // Update is called once per frame
    void Update()
    {
        if (!Stay)
        {
            if (!RunAway)
            {
                Slash.x = -(transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x);
                Slash.y = -(transform.position.y - GameObject.FindGameObjectWithTag("Player").transform.position.y);
                difference = Slash;
                rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(rotZ, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 3f);
            }
            PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            t2 = (transform.position - PlayerPosition).magnitude;
            test = -(transform.position - DirectionPoint.transform.position);
            rb.velocity = (test * 10);
            if (Vector2.Distance(transform.position, PlayerPosition) < 40 && !IsCorutinAvaible)
            {
                IsCorutinAvaible = true;
                StartCoroutine(Distanse());
            }
        }
    }
    IEnumerator Distanse()
    {
        Invoke("DestroyWithPArticle", 8f);
        yield return new WaitForSeconds(2.5f);
        if (Vector2.Distance(transform.position , PlayerPosition) < 40)
        {
            RunAway = true;
        }
        IsCorutinAvaible = false;
        StartCoroutine(Run());
    }
    IEnumerator Run()
    {
        yield return new WaitForSeconds(0.5f);
        RunAway = false;
    }
    IEnumerator stay()
    {
        yield return new WaitForSeconds(1);
        tag = "Bullet";
        Stay = false;
    }
    public void DestroyWithPArticle()
    {
        Debug.Log("FuckOff");
        Instantiate(ParticleSystem, transform.position, new Quaternion(90,90,90,0));
        Destroy(gameObject);
    }

    
}
