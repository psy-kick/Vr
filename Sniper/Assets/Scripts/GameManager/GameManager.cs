using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float StartTime = 5.0f;
    private float CurrentTime;
    public Image TimerBg;  
    public List<GameObject> EnemiesContainer;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = StartTime;
        GameObject[] Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        EnemiesContainer = new List<GameObject>(Enemy);
        foreach (GameObject enemy in Enemy)
        {
            EnemiesContainer.Add(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = EnemiesContainer.Count-1; i >= 0; i--)
        {
            GameObject Enemies = EnemiesContainer[i];
            if(!Enemies.activeSelf)
            {
                EnemiesContainer.RemoveAt(i);

            }
        }
        if (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
            TimerBg.fillAmount = CurrentTime / StartTime;
        }
        if (EnemiesContainer.Count == 0)
        {
            SceneManager.LoadScene(0);
        }
        else if(CurrentTime < 0)
        {
            CurrentTime = 0;
        }
        else if(CurrentTime==0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
