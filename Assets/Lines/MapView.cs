using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapView : LineElement
{
    public QuadView m_quadViewPrefab;
    public QuadView[,] m_quadOnEnviroment;
    public Transform m_Environment;

    public void DrawEvironment(int with,int height)
    {
        m_quadOnEnviroment = new QuadView[with,height];
        for (int i = 0; i < with; i++)
        {
            for (int j = 0; j < height; j++)
            {
                m_quadOnEnviroment[i, j] = Instantiate(m_quadViewPrefab, m_Environment);
                m_quadOnEnviroment[i, j].transform.position = new Vector3(i, j, 0);
                m_quadOnEnviroment[i, j].Clear();
            }
        }
    }
  
}
