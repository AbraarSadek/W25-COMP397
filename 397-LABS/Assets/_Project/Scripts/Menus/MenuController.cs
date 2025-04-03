using UnityEngine;
using UnityEngine.UI;

namespace Platformer397
{
    public class MenuControler : MonoBehaviour
    {

        [SerializeField] private Button playButton;
        [SerializeField] private Button loadButton;
        [SerializeField] private Button opionsButton;
        [SerializeField] private Button quitButton;

        private void Start() {

            playButton.onClick.AddListener(() => SceneController.Instance.ChangeScene("GameplayScene"));
            //playButton.onClick.AddListener(() => Debug.Log("Another Listener Added As Well!"));

        }

    }
}
