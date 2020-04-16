using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineM1 : MonoBehaviour
{
    LineRenderer LR;
    void Start()
    {
        LR = GetComponent<LineRenderer>();    
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            Destroy(gameObject);
        }
    }
    public void ShowTR(Vector3 origin, Vector3 speed)
    {
        LR.positionCount = 10;
        Vector3[] points = new Vector3[10];
        for (int i = 0; i<10f; i++)
        {
            float time = i * 0.5f;
            points[i] = origin + speed * time + Physics.gravity * time * time / 2f;
            points[i].z = -10;
        }
        LR.SetPositions(points);
    }
}
