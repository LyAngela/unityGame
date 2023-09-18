using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button howToPlayButtonButton;
        [SerializeField] private Button closeHowToPlayButton;
        [SerializeField] private GameObject howToPlayPanel;

        private void Start()
        {
            playButton.onClick.AddListener(Play);
            howToPlayButtonButton.onClick.AddListener(OpenHowToPlay);
            closeHowToPlayButton.onClick.AddListener(CloseHowToPlay);
        }

        private void OpenHowToPlay()
        {
            howToPlayPanel.SetActive(true);
        }

        private void CloseHowToPlay()
        {
            howToPlayPanel.SetActive(false);
        }

        private static void Play()
        {
            SceneManager.LoadScene("LevelOne");
        }
    }
}