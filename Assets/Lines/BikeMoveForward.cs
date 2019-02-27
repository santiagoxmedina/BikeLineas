using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeMoveForward : LineElement
{
    public BikeDirection.Direction direction;
    private Vector3 vectorDirection;
    public float angle;
    private void Update()
    {
        switch (direction)
        {
            case BikeDirection.Direction.up:
                vectorDirection = Vector3.up;
                angle = 0;
                break;
            case BikeDirection.Direction.down:
                vectorDirection = Vector3.down;
                angle=180;
                break;
            case BikeDirection.Direction.left:
                vectorDirection = Vector3.left;
                angle = 270;
                break;
            case BikeDirection.Direction.right:
                vectorDirection = Vector3.right;
                angle = 90;
                break;
            default:
                vectorDirection = Vector3.zero;
                break;
        }
    }

    internal void Move (float distance)
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.position = transform.position + (vectorDirection * distance);
        app.Notify(LineNotification.PlayerPositionChange, this);
    }
}
