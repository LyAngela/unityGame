using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public EventHandler<GameStatus> GameStatusChanged;

    public const float AvailableTime = 220;

    private CameraFollow _camera;
    private GameStatus _status;

    public int CollectedPoints { private set; get; }
    public int CollectedPowerUps { private set; get; }
    public int TotalPoints { private set; get; }
    public int TotalPowerUps { private set; get; }
    public float CountDown { private set; get; }

    private void Start()
    {
        _camera = FindObjectOfType<CameraFollow>();
        _camera.OnFlyOverAnimationStop += (_, _) => UpdateStatus(GameStatus.Playing);
        
        Point[] pointsList = FindObjectsOfType<Point>();
        PowerUp[] powerUpsList = FindObjectsOfType<PowerUp>();
        
        TotalPoints = pointsList.Length;
        TotalPowerUps = powerUpsList.Length;
        
        CountDown = AvailableTime;

        UpdateStatus(GameStatus.CameraFlyingOver);
        
        
    }

    private void Update()
    {
        if (_status == GameStatus.Playing)
        {
            if (CountDown > 0)
            {
                CountDown -= Time.deltaTime;
                // Fog settings
                RenderSettings.fogDensity = Mathf.Lerp(0f, 0.04f, 1 - (CountDown / AvailableTime));
            }
            else
            {
                KillPlayer();
            }
        }
    }

    public void Pause()
    {
        UpdateStatus(GameStatus.Paused);
    }

    public void Resume()
    {
        UpdateStatus(GameStatus.Playing);
    }
    
    private void UpdateStatus(GameStatus status)
    {
        _status = status;
        Time.timeScale = _status is GameStatus.CameraFlyingOver or GameStatus.Playing ? 1 : 0;
        GameStatusChanged?.Invoke(this, _status);
    }

    public void KillPlayer()
    {
        UpdateStatus(GameStatus.EndedLost);
    }

    public void AddPoint()
    {
        CollectedPoints++;
        if (CollectedPoints == TotalPoints)
        {
            UpdateStatus(GameStatus.EndedWon);
        }
    }

    public void PowerUp()
    {
        CountDown += 30;
        CollectedPowerUps++;
    }
}
