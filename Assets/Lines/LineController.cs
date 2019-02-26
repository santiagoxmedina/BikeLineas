using UnityEngine;

public class LineController : LineElement
{
    
    public void OnNotification(string p_event_path, Object p_target, params object[] p_data)
    {
        switch (p_event_path)
        {
            case LineNotification.GameStart:
                break;
            case LineNotification.PlayerDirectionChange:
                app.view.m_LinePlayerView.m_BikeMoveForward.direction = (BikeDirection.Direction)p_data[0];
                break;
            default:
                break;
        }
    }
}
