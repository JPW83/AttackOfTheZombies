using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIFunctions : MonoBehaviour
{
    public int Score;
    public Text ScoreText;
    public float Countdown = 3;
    public Text CountdownText;
    public ZombieSpawner ZombieSpawn;
    

    void Awake()
    {
        
        
        Score = 0;

        ScoreText.text = "Score: " + Score.ToString();

        


    }

    void Start()
    {
        ZombieSpawn = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<ZombieSpawner>();
        
    }

    void Update()
    {
        Countdown -= Time.deltaTime;
        CountdownText.text = Countdown.ToString("f0");
        if (Countdown <= 1)
        {
            Countdown = 1;
            CountdownText.gameObject.SetActive(false);
        }

        if (Score == -1)
        {
            SceneManager.LoadScene("GameOver");
        }

        startTheZombie();
       
        

    } 

    void FixedUpdate ()
    {
    }

    public void startCountdown()
    {
        SceneManager.LoadScene("Countdown");
    }

    IEnumerator CountdownTimer()
    {
        yield return new WaitForSeconds(3.0f);
        
    }

    public void RestartLevelOne()
    {
        SceneManager.LoadScene("Game");
    }

    public void ReturnMainMenu ()
    {
        SceneManager.LoadScene("MainMenu");  
    }

    public void OpenTutorial ()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void startLevelOne()
    {
        StartCoroutine("MainMenuTransition");
    }

    IEnumerator MainMenuTransition()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Game");

    }

    public void addOne()
    {
        Score = Score+1;
        ScoreText.text = "Score: " + Score.ToString();

    }

    public void minusOne()
    {
        Score = Score-1;
        ScoreText.text = "Score: " + Score.ToString();
    }
    
    public void startTheZombie()
    {
        ZombieSpawn.currentSpawnRate = 3 / Mathf.Sqrt(Score+1); 
    }
   
    


}


