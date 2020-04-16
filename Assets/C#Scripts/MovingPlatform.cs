using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public bool BetweenTwoDots;
    public bool CurcleMoving;
    public Vector2 StartMove;
    public Vector2 EndPoint;
    public float Radius;
    public float speed;
    Vector2 WereToMove;
    Vector2 P;
    void Start()
    {
        WereToMove = EndPoint;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, WereToMove, speed * Time.deltaTime);
        if (transform.position.x == WereToMove.x && transform.position.y == WereToMove.y)
        {
            if (WereToMove == EndPoint)
            {
                WereToMove = StartMove;
            }
            else
            {
                WereToMove = EndPoint;
            }
        }

    }
}
