using System;
using UnityEngine;

public class LineApplication : LineElement
{

    public LineModel model;
    public LineView view;

    public void Notify(string p_event_path, UnityEngine.Object target, params object[] p_data)
    {
        LineController[] lineControllers = GetAllControllers();
        foreach (var lineController in lineControllers)
        {
            lineController.OnNotification(p_event_path, target, p_data);
        }
    }

    private LineController[] GetAllControllers()
    {
        return FindObjectsOfType<LineController>();
    }
}

