using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    bool Active = false;
    bool used = false;
    Animator chest;
    public GameObject[] Materials;
    public GameObject MySes;
    void Start()
    {
        chest = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Active)
        {
            if (Input.GetKeyDown(KeyCode.R) && !used)
            {
                print("Awsome");
                chest.SetTrigger("Open");
                chest.SetBool("opened", true);
                used = true;
                StartCoroutine(InstateMaterials());
                Destroy(MySes);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Active = true;
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Active = false;
        }
    }
    IEnumerator InstateMaterials()
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < 12; i++)
        {
            Instantiate(Materials[Random.Range(0, 3)], new Vector3(transform.position.x, transform.position.y, transform.position.z+1), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);

        }
    }

}

