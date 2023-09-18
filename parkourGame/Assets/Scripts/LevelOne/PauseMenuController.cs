using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private Button resumeButton;

    private void Start()
    {
        GameController gameController = FindAnyObjectByType<GameController>();
        resumeButton.onClick.AddListener(gameController.Resume);
    }
}
