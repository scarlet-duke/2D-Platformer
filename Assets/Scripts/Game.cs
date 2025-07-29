using UnityEngine;

public class Game : MonoBehaviour
{
    private void Start()
    {
        HealthPlayer healthPlayer = FindObjectOfType<HealthPlayer>();
        healthPlayer.gameOver += GameOver;
    }

    public void GameOver()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
