using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public static bool isGameStarted;
    public static bool isGameEnded;
    public bool isLevelFinished;
    public bool isFailed;

    public string levelName;
    public int diamondScore;

    public Text levelNumberText;
    public Text diamondScoreText;

    public Button restartButton;
    public Button nextButton;

    private void Awake()
    {


        if(Instance == null)
        {

            Instance = this;

        }


    }

    // Start is called before the first frame update
    void Start()
    {
        isGameEnded = false;

        levelName = SceneManager.GetActiveScene().name;

        levelNumberText.text = levelName;

        diamondScore = 0;



    }

    // Update is called once per frame
    void Update()
    {

        diamondScoreText.text = "" + diamondScore;

        if (isGameEnded)
        {

            restartButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(true);

        }else if (isFailed)
        {

            restartButton.gameObject.SetActive(true);

        }

    }

    public void OnLevelStarted()
    {



    }

    public void OnLevelEnded()
    {



    }

    public void OnLevelCompleted()
    {



    }

    public void OnLevelFailed()
    {



    }

    public void RestartLevel()
    {

        
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isFailed = false;
        isGameEnded = false;
        isGameStarted = false;
        isLevelFinished = false;



    }

    public void NextLevel()
    {

        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Next");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        isFailed = false;
        isGameEnded = false;
        isGameStarted = false;
        isLevelFinished = false;
    }

}
