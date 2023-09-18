using TMPro;
using UnityEngine;

public class WonMenuController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private GameController _gameController;

    private void Start()
    {
        _gameController = FindAnyObjectByType<GameController>();
    }

    private void Update()
    {
        scoreText.text = $"Time Score: {(int)(GameController.AvailableTime - _gameController.CountDown)}";
    }
}
