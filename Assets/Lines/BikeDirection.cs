using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeDirection : LineElement
{
    public enum Direction { up,down,left,right}
    public Direction m_direction;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            m_direction = Direction.up;
            app.Notify(LineNotification.PlayerDirectionChange, this, m_direction);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            m_direction = Direction.down;
            app.Notify(LineNotification.PlayerDirectionChange, this, m_direction);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            m_direction = Direction.left;
            app.Notify(LineNotification.PlayerDirectionChange, this, m_direction);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            m_direction = Direction.right;
            app.Notify(LineNotification.PlayerDirectionChange, this, m_direction);
        }
    }
}
