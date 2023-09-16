using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    private int _points = 0;
    private int _missingPoints;
    private GUIStyle _style = new GUIStyle();
    public float CountDown { get; set; }

    private bool countDownStart = false;
    private Camera _camera;
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
            };

            CountDown = 150;
        }

        _camera = FindObjectOfType<Camera>();
        _camera.OnFlyOverAnimationStop += (_,_) => countDownStart = true;
        
    }

    private void Update()
    {
        if (countDownStart)
        {
            CountDown = CountDown > 0 ? CountDown - Time.deltaTime : 0; 
            RenderSettings.fogDensity = CountDown == 0 ? 0.05f : Mathf.Lerp(0f, 0.05f, 1 - (CountDown / 150f)); 
        }
        
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0,20, 300,300));
        GUILayout.Label($"Points: {_points}/{_missingPoints} ", _style);
        GUILayout.Label($"Count Down: {(int)CountDown}",_style);
        GUILayout.EndArea();
    }
    
    
}
