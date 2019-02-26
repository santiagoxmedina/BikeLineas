using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeMoveForward : LineElement
{
    public float speed = 1f;
    public BikeDirection.Direction direction;
    private Vector3 vectorDirection;
    private void Update()
    {
        switch (direction)
        {
            case BikeDirection.Direction.up:
                vectorDirection = Vector3.up;
                break;
            case BikeDirection.Direction.down:
                vectorDirection = Vector3.down;
                break;
            case BikeDirection.Direction.left:
                vectorDirection = Vector3.left;
                break;
            case BikeDirection.Direction.right:
                vectorDirection = Vector3.right;
                break;
            default:
                vectorDirection = Vector3.zero;
                break;
        }   
        transform.position = transform.position + (vectorDirection * speed);
    }
}
