using TMPro;
using UnityEngine;

public class GameOverMenuController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private GameController _gameController;

    private void Start()
    {
        _gameController = FindAnyObjectByType<GameController>();
    }

    private void Update()
    {
        scoreText.text = $"Your Score: {_gameController.CollectedPoints}";
    }
}
