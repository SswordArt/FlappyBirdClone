using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Ekrana Ait Objeler")]
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private GameObject GameStartScreen;
    [SerializeField] private GameObject ScoreImage;
    [SerializeField] private GameObject InGameHolder;

    [Header("Yazý (Text) Objeleri")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI bitisEkraniScoreText; 
    [SerializeField] private TextMeshProUGUI bitisEkraniBestText;
    int _point = 0;
    int _maxPoint = 0;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    void Start()
    {
        Time.timeScale = 0f;
        _maxPoint = PlayerPrefs.GetInt("MaxPointKaydi", 0);
        canvas.SetActive(true);
        UpdateUIState(false, true, true, false);
        bitisEkraniScoreText.text = "<color=white>" + _point + "</color>";
        bitisEkraniBestText.text = "<color=white>" + _maxPoint + "</color>";


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        Time.timeScale = 1f;
        UpdateUIState(false, false, false, true);
    }
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Cýkýs yapýldý");
    }
    public void EndGameScreen()
    {
        Debug.Log("Oyun bitti");
        Time.timeScale = 0f;
        canvas.SetActive(true);
        UpdateUIState(true, false, true, false);
        bitisEkraniScoreText.text = "<color=white>" + _point + "</color>";
        bitisEkraniBestText.text = "<color=white>" + _maxPoint + "</color>";
    }
    public void CollectPoint()
    {
        _point++;

        scoreText.text = "<color=#D9602C>Score: </color><color=white>" + _point + "</color>";
        bestScoreText.text = "<color=#D9602C>Best: </color><color=white>" + _maxPoint + "</color>";
        if ( _point >= _maxPoint ) {

            _maxPoint = _point;

            PlayerPrefs.SetInt("MaxPointKaydi", _maxPoint);
            PlayerPrefs.Save();
            Debug.Log("puan:" + _point);
            Debug.Log("Maxpuan:" + _maxPoint);

        }
        
    }

    private void UpdateUIState(bool isGameOver, bool isGameStart, bool isScoreVisible, bool isHolderActive)
    {
        GameOverScreen.SetActive(isGameOver);
        GameStartScreen.SetActive(isGameStart);
        ScoreImage.SetActive(isScoreVisible);
        InGameHolder.SetActive(isHolderActive);
    }
}
