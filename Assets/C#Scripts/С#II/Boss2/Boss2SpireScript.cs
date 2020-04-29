using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2SpireScript : MonoBehaviour
{
    
    public bool Atack = false;
    public GameObject Direction;
    public float Times;
    public float speed = 1;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Atack == true)
        {
            Atack = false;
            StartCoroutine(StartAtack());
        }
    }

    IEnumerator StartAtack()
    {
        yield return new WaitForSeconds(Times);
        float timer = 1f;
        while (timer > 0)
        {
            tag = "Untagged";
            yield return new WaitForSeconds(Time.deltaTime);
            timer -= Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, Direction.transform.position, Time.deltaTime * timer * 5);
        }
        StartCoroutine(RotateToPlayer());
    }
    IEnumerator RotateToPlayer()
    {
        float timer = 2f;
        float RotZ;
        Vector2 difference;
        while (timer > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            timer -= Time.deltaTime;
            difference.x = -(transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x);
            difference.y = -(transform.position.y - GameObject.FindGameObjectWithTag("Player").transform.position.y);
            RotZ = (Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg) - 90f;
            Quaternion rotation = Quaternion.AngleAxis(RotZ, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
        }
        tag = "Bullet";
        StartCoroutine(MoveToDirection());
    }

    IEnumerator MoveToDirection()
    {
        float timer = 4; ;
        while (timer > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            timer -= Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, Direction.transform.position, Time.deltaTime * 30 * speed);
        }
        Destroy(gameObject);
    }

}

