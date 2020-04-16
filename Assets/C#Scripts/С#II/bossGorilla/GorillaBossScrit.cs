using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorillaBossScrit : MonoBehaviour
{
    public bool isLeft;
    public float HP = 100;
    public float T = 10;
    int relax = 0;
    bool isWindCreated = false;
    public GameObject Pushka;
    public GameObject Wawe3L;
    public GameObject Wawe3R;
    public GameObject Wawe2;
    public GameObject OneWawe;
    public GameObject Warning;
    public GameObject Wind;
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sr;
    bool IsLeft;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(GoLeftR(2f));
    }

    void Update()
    {
        if (isWindCreated==false && HP < 40)
        {
            Instantiate(Wind, new Vector3(38, -11, 71), Quaternion.identity);
            isWindCreated = true;
        }
        T -= Time.deltaTime;
        if (T <= 0)
        { 
            switch (Random.Range(1,6))
            {
                case 1:
                    FirstTypeAtack();
                    break;
                case 2:
                    SecondTypeAtack();
                    break;
                case 3:
                    TrhirdTypeAtack();
                    break;
                case 4:
                    ForthTypeAtack();
                    break;
                case 5:
                    FifithTypeAtack();
                    break;
            }
            if (relax < 3)
            {
                relax += 1;
                T = 14;
            }
            else
            {
                if (Random.value < 0.5)
                {
                    CAmeOuntL();
                }
                else
                {
                    CAmeOuntR();
                }
                relax = 0;
                T = 19;
            }
        }
    }
    void CAmeOuntL()
    {
        LeftPosSet();
        StartCoroutine(GoRightL());
    }
    void LeftPosSet()
    {
        transform.eulerAngles = new Vector3(0, 180.0f, 0);
        transform.position = new Vector3(-108.5f, -19.94f, 0);
    }
    IEnumerator GoRightL()
    {
        while (transform.position.x  < -75.3f)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            transform.position = new Vector2(transform.position.x + (7  * Time.deltaTime),transform.position.y);
            anim.SetInteger("BS", 1);
        }
        anim.SetInteger("BS", 0);
        StartCoroutine(GoLeftL(5));
    }
    IEnumerator GoLeftL(float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.position = new Vector3(-75.3f, transform.position.y, 0);
        while (transform.position.x > -103)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            transform.position = new Vector2(transform.position.x - (7 * Time.deltaTime), transform.position.y);
            anim.SetInteger("BS", 2);
        }
        anim.SetInteger("BS", 0);
    }
    //---------------------------------------------------------------------------------------------------------------------------
    void CAmeOuntR()
    {
        RightPosSet();
        StartCoroutine(GoRightR());
    }
    void RightPosSet()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        transform.position = new Vector3(146.6f, -19.94f, 0);
    }
    IEnumerator GoRightR()
    {
        while (transform.position.x > 115.4)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            transform.position = new Vector2(transform.position.x - (7 * Time.deltaTime), transform.position.y);
            anim.SetInteger("BS", 1);
        }
        anim.SetInteger("BS", 0);
        StartCoroutine(GoLeftR(5f));
    }
    IEnumerator GoLeftR(float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.position = new Vector3(115.4f, transform.position.y, 0);
        while (transform.position.x < 146.6f)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            transform.position = new Vector2(transform.position.x + (7 * Time.deltaTime), transform.position.y);
            anim.SetInteger("BS", 2);
        }
        anim.SetInteger("BS", 0);
    }
    void FirstTypeAtack()
    {
        if (HP < 70)
        {
            StartCoroutine(WaweOnPlayerPosition(3f, 0));
        }
        StartCoroutine(Pushki3(0f));
        if (HP < 70)
        {
            StartCoroutine(WaweOnPlayerPosition(3f, 4));
        }
        StartCoroutine(Pushki3(4f));
        StartCoroutine(Pushki3(8f));
    }
    void SecondTypeAtack()
    {
            if (HP < 70)
            {
                StartCoroutine(WaweOnPlayerPosition(3f, 0));
            }
        StartCoroutine(Pushki4(0f));
                if (HP < 70)
                {
                    StartCoroutine(WaweOnPlayerPosition(3f, 4));
                }
        StartCoroutine(Pushki4(4f));
        StartCoroutine(Pushki4(8f));
    }
    void TrhirdTypeAtack()
    {
                    if (HP < 70)
                    {
                        StartCoroutine(WaweOnPlayerPosition(3f, 0));
                    }
        StartCoroutine(Pushki3(0f));
        StartCoroutine(Pushki4(0f));
        if (HP < 70)
                        {
            StartCoroutine(WaweOnPlayerPosition(3f, 8));
                        }
        StartCoroutine(Pushki3(8f));
        StartCoroutine(Pushki4(8f));
    }
    void ForthTypeAtack()
    {
                            if (HP < 70)
                            {
                                StartCoroutine(WaweOnPlayerPosition(3f, 0));
                            }
        StartCoroutine(Pushki1(0f));
                                if (HP < 70)
                                {
                                    StartCoroutine(WaweOnPlayerPosition(3f, 4));
                                }
        StartCoroutine(Pushki1(4f));
        StartCoroutine(Pushki1(8f));
    }
    void FifithTypeAtack()
    {
                                   if (HP < 70)
                                    {
                                        StartCoroutine(WaweOnPlayerPosition(3f, 0));
                                    }
        StartCoroutine(Pushki2(0f));
        if (HP < 70)
        {
            StartCoroutine(WaweOnPlayerPosition(3f, 4));
        }
        StartCoroutine(Pushki2(4f));
        StartCoroutine(Pushki2(8f));
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("HPPrefab"))
        {
            HP -= 1;
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * 1);
            sr.color = Color.red;
            Invoke("BecomeWhite", 0.2f);
            if (HP > 0)
            {
                rb.AddForce(transform.up * 300, ForceMode2D.Impulse);
            }
        }
    }
    void BecomeWhite()
    {
        sr.color = Color.white;
    }

    IEnumerator Pushki1(float delay)
    {
        yield return new WaitForSeconds(delay);
        float d = 0;
        while (d <= 90)
        {
            Instantiate(Pushka, new Vector3(18 + d, 28.4f, 1), Quaternion.identity);
            Instantiate(Pushka, new Vector3(18 - d, 28.4f, 1), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            d += 10;
        }
    }
    IEnumerator WaweOnPlayerPosition(float delay, float Delay2)
    {
        yield return new WaitForSeconds(Delay2);
        float PlP = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        Instantiate(Warning, new Vector3(PlP, -16f, 1), Quaternion.identity);
        yield return new WaitForSeconds(delay);
        float d = 5;
        while (d <= 30)
        {
            Instantiate(OneWawe, new Vector3(PlP + d, -13.1f, 1), Quaternion.identity);
            Instantiate(OneWawe, new Vector3(PlP - d, -13.1f, 1), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            d += 5;
        }
    }
    IEnumerator Pushki2(float delay)
    {
        yield return new WaitForSeconds(delay);
        float d = 90;
        while (d >= 0)
        {
            Instantiate(Pushka, new Vector3(18 + d, 28.4f, 1), Quaternion.identity);
            Instantiate(Pushka, new Vector3(18 - d, 28.4f, 1), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            d -= 10;
        }
    }
    IEnumerator Pushki3(float delay)
    {
        yield return new WaitForSeconds(delay);
        float d = 0;
        while (d <= 180)
        {
            Instantiate(Pushka, new Vector3(-71f + d, 28.4f, 1), Quaternion.identity);
            if (-91f + d>=-71f)
            {
                Instantiate(Pushka, new Vector3(-91f + d, 28.4f, 1), Quaternion.identity);
            }
            yield return new WaitForSeconds(0.4f);
            d += 10;
        }
    }
    IEnumerator Pushki4(float delay)
    {
        yield return new WaitForSeconds(delay);
        float d = 0;
        while (d <= 180)
        {
            Instantiate(Pushka, new Vector3(109.3f - d, 28.4f, 1), Quaternion.identity);
            if (109.3f - d <= 109.3f)
            {
                Instantiate(Pushka, new Vector3(129.3f - d, 28.4f, 1), Quaternion.identity);
            }
            yield return new WaitForSeconds(0.4f);
            d += 10;
        }
    }
    void WaweL()
    {
        Instantiate(Wawe3L, new Vector3(109.3f, -13.1f, 1), Quaternion.identity);
    }
    void WaweR()
    {
        Instantiate(Wawe3R, new Vector3(-71f, -13.1f, 1), Quaternion.identity);
    }
    void Wawe2L()
    {
        Instantiate(Wawe2, new Vector3(109.3f, -35.4f, 1), new Quaternion(0, 0, 0, 0));
    }
    void Wawe2R()
    {
        Instantiate(Wawe2, new Vector3(-71f, -35.4f, 1), new Quaternion(0, 180, 0, 0));
    }
}
