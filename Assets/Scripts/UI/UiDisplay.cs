using UnityEngine;

public class UiDisplay : MonoBehaviour
{
    public static UiDisplay Instance { get; private set; }

    [SerializeField] private LevelComplite levelComplite;
    [SerializeField] private GameOver gameOver;

    public LevelComplite LevelComplite => levelComplite;
    public GameOver GameOver => gameOver;

    public void Init()
    {
        InitSingleton();
        InitUI();
    }
    private void InitSingleton()
    {
        // Singleton инициализация
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("UIDisplay already exists! Destroying duplicate.");
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void InitUI()
    {
        LevelComplite.Init();
        GameOver.Init();
    }
}