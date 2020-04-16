using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helicpterGun : MonoBehaviour
{
    public GameObject pl;
    public GameObject MH;
    public GameObject BulletPref;
    float rotZ;
    float rotationOffset=10;
    float speedRotate=4;
    public int Magazin;
    public int magazin=  4;
    public float ReloagM;
    public float ReloagS;
    public float t;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (t < 0)
        {
            if (MH.GetComponent<Helicopter>().MayShoot) {
                Instantiate(BulletPref, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
                magazin -= 1;
                if (magazin == 0)
                {
                    magazin = 4;
                    t = ReloagM;
                }
                else
                {
                    t = ReloagS;
                }
            }
        }
        else
        {
            t -= Time.deltaTime;
        }
        if (MH.transform.eulerAngles.y == 180)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }
        Vector3 difference = pl.transform.position - transform.position;
        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(rotZ + rotationOffset, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speedRotate);
    }
}
