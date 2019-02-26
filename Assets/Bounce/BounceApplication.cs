using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceElement : MonoBehaviour {
    // Gives access to the application and all instances.
    public BounceApplication app { get { return GameObject.FindObjectOfType<BounceApplication>(); } }
}

public class BounceApplication : BounceElement {


    // Reference to the root instances of the MVC.
    public BounceModel model;
    public BounceView view;

    // Iterates all Controllers and delegates the notification data
    // This method can easily be found because every class is “BounceElement” and has an “app” 
    // instance.
    public void Notify (string p_event_path, Object p_target, params object[] p_data)
    {
        BounceController[] controller_list = GetAllControllers();
        foreach (BounceController c in controller_list)
        {
            c.OnNotification(p_event_path, p_target, p_data);
        }
    }

    // Fetches all scene Controllers.
    public BounceController[] GetAllControllers () { return FindObjectsOfType<BounceController>(); }
}
