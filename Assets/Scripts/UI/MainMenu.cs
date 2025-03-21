using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneLoader.Instance.LoadScene("Game");
    }
}
