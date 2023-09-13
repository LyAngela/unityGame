using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    private int points = 0;
    void Start()
    {
        useGUILayout = true;
        Point[] pointsList = FindObjectsOfType<Point>();
        foreach (var point in pointsList)
        {
            point.PointEvent += (_, _) => points++;
        } 
           
    }
    
    private void OnGUI()
    {
    
        GUILayout.BeginArea(new Rect(0,50, 300,300));
        GUILayout.Label($"Points: {points}");
        GUILayout.EndArea();
    }
}
