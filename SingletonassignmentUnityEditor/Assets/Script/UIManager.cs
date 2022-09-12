using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
 
    private int _leTimer;
    [SerializeField]
    private TextMeshProUGUI _leTimerText;
    [SerializeField]
    private TextMeshProUGUI _leScoreText;
    [SerializeField]
    private GameObject[] _heartContainers;
    [SerializeField]
    private GameObject _deathSequence;
    



    // Start is called before the first frame update
    void Start()
    {
        _deathSequence.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        TimerOnScreen();
        HealthManager();
        ScoreManager();
    }

    private void TimerOnScreen()
    {
        _leTimerText.text = ("" + TheManager.Instance.LeTimer);
    }

    private void HealthManager()
    {
        for (int i = 0; i < _heartContainers.Length; i++)
        {
            if (i < TheManager.Instance.Health)
            {
                _heartContainers[i].SetActive(true);
                continue;
            }
            _heartContainers[i].SetActive(false);
        }
        if (TheManager.Instance.Health < 1)
        {
            StartCoroutine(Respawning());  
        }
    }
    private void ScoreManager()
    {
        _leScoreText.text = ("" + TheManager.Instance.Score);
    }
    IEnumerator Respawning()
    {
        //DONE set active un you died
        //DONE timer de 3sec avec mention you died
        //DONE reset le score du current level only
        //DONE met la vie à 3 pis reload la scene
        _deathSequence.SetActive(true);
        yield return new WaitForSeconds(3f);
        TheManager.Instance.Deathcount++;
        TheManager.Instance.Health = 3;
        TheManager.Instance.TemporaryScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
   
}
