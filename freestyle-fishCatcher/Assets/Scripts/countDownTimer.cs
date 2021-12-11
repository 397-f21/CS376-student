using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class countDownTimer : MonoBehaviour
{
    public float currentTimer = 60;
    public Text Timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public static void Restart()
    {
        ScoreKeeper.resetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(currentTimer> 0)
        {
            currentTimer = currentTimer - Time.deltaTime;
        }
        if(currentTimer <= 0)
        {
            Restart();
        }

        Timer.text = string.Format("{0:00}:{1:00}:{2:000}", Mathf.FloorToInt(currentTimer/60), Mathf.FloorToInt(currentTimer % 60), Mathf.FloorToInt(currentTimer %1 *1000));
        
    }
}
