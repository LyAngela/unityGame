using UnityEngine;

public class LevelUiController : MonoBehaviour
{
    [SerializeField] private GameObject playingPanel;
    [SerializeField] private GameObject pausedPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;

    private void Start()
    {
        GameController gameController = FindAnyObjectByType<GameController>();
        gameController.GameStatusChanged += OnGameStatusChanged;
    }

    private void OnGameStatusChanged(object _, GameStatus status)
    {
        playingPanel.SetActive(status == GameStatus.Playing);
        pausedPanel.SetActive(status == GameStatus.Paused);
        gameOverPanel.SetActive(status == GameStatus.EndedLost);
        winPanel.SetActive(status == GameStatus.EndedWon);
    }
}
