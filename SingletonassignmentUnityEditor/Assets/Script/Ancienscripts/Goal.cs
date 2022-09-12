using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision) //Make sure to put this out of Voids
    {
        {
            SceneManager.LoadScene(1);
        }
    }
}
