using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    private int _points = 0;
    private int _missingPoints;
    private GUIStyle _style = new GUIStyle();
    private float _countDown = 10;
    void Start()
    {
        useGUILayout = true;
        _style.fontSize = 20;
        
        Point[] pointsList = GetComponentsInChildren<Point>();
        _missingPoints = pointsList.Length;
        
        foreach (var point in pointsList)
        {
            point.PointEvent += (_, _) =>
            {
                _points++;
                _missingPoints--;
            };
        }
        
        
    
    }

    private void Update()
    {
        _countDown = _countDown > 0 ? _countDown - Time.deltaTime : 0; 
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0,20, 300,300));
        GUILayout.Label($"Points: {_points}/{_missingPoints} ", _style);
        GUILayout.Label($"Count Down: {(int)_countDown}",_style);
        GUILayout.EndArea();
    }
    
    
}
