using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private HealthPlayer _healthPlayer;

    private void OnEnable()
    {
        _healthPlayer.GameOver += GameOver;
    }

    private void OnDisable()
    {
        _healthPlayer.GameOver -= GameOver;
    }

    public void GameOver()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
