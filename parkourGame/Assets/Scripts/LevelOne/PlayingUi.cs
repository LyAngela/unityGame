using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayingUi : MonoBehaviour
{
    [SerializeField] private TMP_Text pointsText;
    [SerializeField] private TMP_Text countDownText;
    [SerializeField] private Button pauseButton;

    private GameController _gameController;

    private void Start()
    {
        _gameController = FindAnyObjectByType<GameController>();
        pauseButton.onClick.AddListener(_gameController.Pause);
    }

    private void Update()
    {
        pointsText.text = $"Points: {_gameController.CollectedPoints}/{_gameController.TotalPoints}";
        countDownText.text = $"Count Down: {(int)_gameController.CountDown}";
    }
}
