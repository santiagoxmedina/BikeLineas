using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineElement : MonoBehaviour
{
    private LineApplication _app;
    public LineApplication app { get { if (_app == null) { _app = FindObjectOfType<LineApplication>(); } return _app; } }
}
