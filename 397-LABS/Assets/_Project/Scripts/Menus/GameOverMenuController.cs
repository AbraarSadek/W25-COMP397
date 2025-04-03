using UnityEngine;
using UnityEngine.UI;

namespace Platformer397
{
    public class GameOverMenuController : MonoBehaviour
    {
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button restartGameButton;
        [SerializeField] private Button quitButton;

        private void Start()
        {

            mainMenuButton.onClick.AddListener(() => SceneController.Instance.ChangeScene("MenuScene"));
            restartGameButton.onClick.AddListener(() => SceneController.Instance.ChangeScene("GameplayScene"));

        }
    }
}
