using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private LifePlayer _lifePlayer;

    private void OnEnable()
    {
        _lifePlayer.GameOver += GameOver;
    }

    private void OnDisable()
    {
        _lifePlayer.GameOver -= GameOver;
    }

    public void GameOver()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
