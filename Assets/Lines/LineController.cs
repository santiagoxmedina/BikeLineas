using System.Collections;
using UnityEngine;

public class LineController : LineElement
{
    private void Start ()
    {
        app.Notify(LineNotification.GameStart, this);
    }

    public void OnNotification(string p_event_path, Object p_target, params object[] p_data)
    {
        switch (p_event_path)
        {
            case LineNotification.GameStart:
                app.view.m_MapView.DrawEvironment(app.model.width, app.model.height);
                app.view.m_LinePlayerView.m_BikeMoveForward.transform.position = Vector3.zero;
                app.view.m_LinePlayerView.m_BikeMoveForward.direction = BikeDirection.Direction.up;
                app.model.isRunning = true;
                StartCoroutine(MovePlayers());
                break;
            case LineNotification.PlayerDirectionChange:
                BikeDirection.Direction newDirection = (BikeDirection.Direction)p_data[0];
                BikeDirection.Direction currentDirection = app.view.m_LinePlayerView.m_BikeMoveForward.direction;
                if(currentDirection != newDirection)
                {
                    switch (currentDirection)
                    {
                        case BikeDirection.Direction.up:
                            if(newDirection!= BikeDirection.Direction.down)
                            {
                                app.view.m_LinePlayerView.m_BikeMoveForward.direction = newDirection;
                            }
                            break;
                        case BikeDirection.Direction.down:
                            if (newDirection != BikeDirection.Direction.up)
                            {
                                app.view.m_LinePlayerView.m_BikeMoveForward.direction = newDirection;
                            }
                            break;
                        case BikeDirection.Direction.left:
                            if (newDirection != BikeDirection.Direction.right)
                            {
                                app.view.m_LinePlayerView.m_BikeMoveForward.direction = newDirection;
                            }
                            break;
                        case BikeDirection.Direction.right:
                            if (newDirection != BikeDirection.Direction.left)
                            {
                                app.view.m_LinePlayerView.m_BikeMoveForward.direction = newDirection;
                            }
                            break;
                        default:
                            break;
                    }
                    
                }
                break;
            case LineNotification.PlayerPositionChange:
                LineElement player = (LineElement)p_target;
                Vector2 playerPosition = player.transform.position;
                app.view.m_MapView.m_quadOnEnviroment[(int)playerPosition.x, (int)playerPosition.y].OnOccupped(Color.red, "Player");
                break;
            default:
                break;
        }
    }

    public IEnumerator MovePlayers()
    {
        while (app.model.isRunning)
        {
            yield return new WaitForSeconds(app.model.PlayerMovementPeriod);
            app.view.m_LinePlayerView.m_BikeMoveForward.Move(app.model.PlayerMovementDistance);
        }
    }
}
