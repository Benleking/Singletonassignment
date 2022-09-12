using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _sectionReadMe;
    [SerializeField]
    private bool _isEndScreen;
    private int _completionTime;

    private void Start()
    {
        if (_isEndScreen)
        {
            _completionTime = TheManager.Instance.LeTimer;
        }
        
    }
    public void ClickStart()
    {
        SceneManager.LoadScene(1);
        if (_isEndScreen)
        {
            TheManager.Instance.mustreset = true;
        }
    }
    public void ClickQuit()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (_isEndScreen)
        {
            _sectionReadMe.text = ("Congratulations! \nYour Score is "+ TheManager.Instance.Score + "\nit took " + _completionTime + " seconds to beat. \nYou died "+ TheManager.Instance.Deathcount + " times.");
        }
    }

}
