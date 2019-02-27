using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadView : LineElement
{
    public string id;
    public Color color;
    public MeshRenderer quad;

    public void OnOccupped(Color _color,string _id)
    {
        color = _color;
        id = _id;
        UpdateColor();
    }

    public void Clear ()
    {
        color = Color.black;
        id = string.Empty;
        UpdateColor();
    }

    private void UpdateColor ()
    {
        quad.material.color = color;
    }
}
