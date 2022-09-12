using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TheManager : MonoBehaviour
{
    public static TheManager Instance;
    [Header("Timer")]
    private float _leTimerEnFloat = 0f;
    public int LeTimer;
    [Header("Health")]
    public int Health = 3;
    [Header("Score & list of respawnable")]
    public int TemporaryScore;
    public int PermanentScore;
    public int Score;
    public int Deathcount;
    public bool mustreset;

    //(DONE) 1. Timer
    //(DONE) 2. Death Count
    //Score Count
    private void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (mustreset)
        {
            ResetLesChoses();
        }
        Score = TemporaryScore + PermanentScore;
        if (Health > 3)
        {
            Health = 3;
        }
    }




    void FixedUpdate()
    {
        TimerManager();
        LeTimer = (int)_leTimerEnFloat;
    }

    private void TimerManager()
    {
        _leTimerEnFloat = _leTimerEnFloat + Time.deltaTime;
    }
    private void ResetLesChoses()
    {
        PermanentScore = 0;
        TemporaryScore = 0;
        _leTimerEnFloat = 0f;
        Deathcount = 0;
        mustreset = false;
    }
 
}
