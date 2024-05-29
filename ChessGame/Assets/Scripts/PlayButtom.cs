using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayButtom : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
