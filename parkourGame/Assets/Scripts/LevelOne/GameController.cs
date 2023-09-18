using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public EventHandler<GameStatus> GameStatusChanged;

    public const float AvailableTime = 200;

    private CameraController _camera;
    private GameStatus _status;

    public int CollectedPoints { private set; get; }
    public int TotalPoints { private set; get; }
    public float CountDown { private set; get; }

    private void Start()
    {
        _camera = FindObjectOfType<CameraController>();
        _camera.OnFlyOverAnimationStop += (_, _) => UpdateStatus(GameStatus.Playing);

        TotalPoints = transform.childCount;
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
                RenderSettings.fogDensity = Mathf.Lerp(0f, 0.05f, 1 - (CountDown / 150f));
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

    public void RecordCollision(CollisionableObjectType objectType)
    {
        switch (objectType)
        {
            case CollisionableObjectType.Obstacle: KillPlayer(); break;
            case CollisionableObjectType.Point: AddPoint(); break;
            case CollisionableObjectType.PowerUp: PowerUp(); break;
        }
    }

    private void UpdateStatus(GameStatus status)
    {
        _status = status;
        Time.timeScale = _status is GameStatus.CameraFlyingOver or GameStatus.Playing ? 1 : 0;
        GameStatusChanged?.Invoke(this, _status);
    }

    private void KillPlayer()
    {
        UpdateStatus(GameStatus.EndedLost);
    }

    private void AddPoint()
    {
        CollectedPoints++;
        if (CollectedPoints == TotalPoints)
        {
            UpdateStatus(GameStatus.EndedWon);
        }
    }

    private void PowerUp()
    {
        CountDown += 20;
    }
}
