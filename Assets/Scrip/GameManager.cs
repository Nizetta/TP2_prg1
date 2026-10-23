using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    
    [Header("Game Over")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button menuButton;

    private bool gameOverActivo=false;

    [Header("Pausa")]
    public GameObject menuPausa;

    public bool juegoPausado = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
  
    void Start()
    {
        menuPausa.SetActive(false);
       
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        if(restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }
        if(menuButton != null)
        {
            menuButton.onClick.AddListener(Menu);
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (juegoPausado)
            {
                Pausar();
            }
            else
            {
                Reanudar();
            }
        
        }
        
        if (gameOverActivo)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                Menu();
            }
        }
    }

    public void GameOver()
    {
        if(gameOverActivo) return;

        gameOverActivo = true;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        if (gameOverText != null)
        {
            gameOverText.text = "Game Over\n\nR-Restart\nM-Menu";
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
         Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Pausar()
    {
        Time.timeScale = 1f;
        juegoPausado = false;
        menuPausa.SetActive(false);
    }

    public void Reanudar()
    {
        Time.timeScale = 0f;
        juegoPausado = true;
        menuPausa.SetActive(true);
    }
}
