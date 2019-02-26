﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Controls the app workflow.
public class BounceController : BounceElement {

    // Handles the ball hit event
    public void OnNotification (string p_event_path, Object p_target, params object[] p_data)
    {
        switch (p_event_path)
        {
            case BounceNotification.BallHitGround:
                app.model.bounces++;
                Debug.Log("Bounce "+app.model.bounces);
                if (app.model.bounces >= app.model.winCondition)
                {
                    app.view.ball.enabled = false;
                    app.view.ball.GetComponent<Rigidbody>().isKinematic = true; // stops the ball
                                                                                // Notify itself and other controllers possibly interested in the event
                    app.Notify(BounceNotification.GameComplete, this);
                }
                break;

            case BounceNotification.GameComplete:
                Debug.Log("Victory!!");
                break;
        }
    }

}
