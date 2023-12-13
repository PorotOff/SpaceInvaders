using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(0);

        Time.timeScale = 1;

        SpaceShipDie.playerHP = 5;
    }
}
