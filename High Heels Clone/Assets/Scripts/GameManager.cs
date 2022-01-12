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


    public string levelName;
    public int diamondScore;

    public Text levelNumberText;
    public Text diamondScoreText;
    

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


        levelName = SceneManager.GetActiveScene().name;

        levelNumberText.text = levelName;

        diamondScore = 0;



    }

    // Update is called once per frame
    void Update()
    {

        diamondScoreText.text = "" + diamondScore;


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
}
