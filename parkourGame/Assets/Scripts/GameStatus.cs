using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    private int _points = 0;
    private int _powerUps = 0;
    
    private int _missingPoints;
    private int _missingPowerUps;
    
    private GUIStyle _style = new GUIStyle();
    public float CountDown { get; set; }
    private bool _countDownStart = false;
    
   // Fly Over at beginning of Game
    private CameraFollow _cameraFollow;

    // TODO 
    public event EventHandler GameWonEvent;
    void Start()
    {
        CountDown = 200;
        
        useGUILayout = true;
        _style.fontSize = 20;
        
        Point[] pointsList = GetComponentsInChildren<Point>();
        PowerUp[] powerUps = FindObjectsOfType<PowerUp>();
        
        _missingPoints = pointsList.Length;
        _missingPowerUps = powerUps.Length;
        
        foreach (var point in pointsList)
        {
            point.PointEvent += (_, _) => _points++;
        }
        
        

        foreach (var power in powerUps)
        {
            power.PowerUpEvent += (_, _) =>
            {
                _powerUps++;
                CountDown += 30;
            };

        }
        
        

        _cameraFollow = FindObjectOfType<CameraFollow>();
        _cameraFollow.OnFlyOverAnimationStop += (_,_) => _countDownStart = true;
        
    }

    public void OnPuase()
    {
        // TODO
    }

    private void Update()
    {
        if (_countDownStart)
        {
            CountDown = CountDown > 0 ? CountDown - Time.deltaTime : 0; 
            // More fog depending how much time has passed
            RenderSettings.fogDensity = CountDown == 0 ? 0.03f : Mathf.Lerp(0f, 0.03f, 1 - (CountDown / 200)); 
        }
        
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0,20, 300,300));
        GUILayout.Label($"Points: {_points}/{_missingPoints} ", _style);
        GUILayout.Label($"Count Down: {(int)CountDown} seconds",_style);
        GUILayout.Label($"Collected Power Ups: {_powerUps}/{_missingPowerUps}",_style);
        GUILayout.EndArea();
    }
    
    
}
