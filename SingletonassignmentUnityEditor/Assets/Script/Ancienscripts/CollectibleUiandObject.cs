using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectibleUiandObject : MonoBehaviour
{
    private int _amountOfKeys;
    [SerializeField] private TextMeshProUGUI _leNombreDeCles;
    public PlayerCharacter ThePlayer;
    [Header("Sounds")]
    [SerializeField]private AudioClip[] audioClipArray;
    private AudioSource _audioSource;

    [Header("Health")]
    [SerializeField] private GameObject _heartOne;
    [SerializeField] private GameObject _heartTwo;
    [SerializeField] private GameObject _heartThree;
    private int Health = 3;
    private bool _isHurt = false;
    [Header("End")]
    [SerializeField] private GameObject _endThings;
    [SerializeField] private TextMeshProUGUI _endText;
    [SerializeField] private GameObject _lesLocks;



    // Start is called before the first frame update
    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
  
    }
    /*
    Checklist:
      (DONE)  0. 4 Tags: Bullet, Vie, Key et Powerup
      (DONE)  1. Perdre de la vie si on touche au bullet
      (DONE)  2. Gagne de la vie si on touche au first aid
      (DONE)  3. Collecter 5 clé pour gagner
      (DONE)  4. Avoir un power up pour sauter plus haut


    */
    // Update is called once per frame
    void Update()
    {
        //************Hearts in the UI
        if (Health >= 1)
        {
            _heartOne.SetActive(true);
            if (Health >= 2)
            {
                _heartTwo.SetActive(true);
                if (Health >= 3)
                {
                    _heartThree.SetActive(true);
                    if (Health > 3)
                    {
                        Health = 3;
                    }
                } else 
                {
                    _heartThree.SetActive(false); 
                }
            } else 
            {
                _heartTwo.SetActive(false); 
            }
        }
        else { _heartOne.SetActive(false); 
        }
        //************End Sequence
        if (Health < 1)
        {
            _endThings.SetActive(true);
            _endText.text = ("YOU DIED!\n Respawning...");
            StartCoroutine(Respawning());
        }
        if (_amountOfKeys >= 5)
        {
            _endThings.SetActive(true);
            _lesLocks.SetActive(true);
            _endText.text = ("YOU WON! \n Thanks for playing! \n Respawning... ");
            StartCoroutine(Respawning());
        }
        //************Key Text
        _leNombreDeCles.text = (_amountOfKeys + "/5");
    }
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Bullet" && !_isHurt)
        {
            _isHurt = true;
            StartCoroutine(Aouch());
            Health = Health - 1;
            Debug.Log("Toucher au bullet");
            _audioSource.clip = audioClipArray[0];
            _audioSource.PlayOneShot(_audioSource.clip);
            _audioSource.Play();
        }
        if (other.gameObject.tag == "Health")
        {
            Health = Health + 1;
            Debug.Log("Toucher au firstaid");
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            _audioSource.clip = audioClipArray[2];
            _audioSource.PlayOneShot(_audioSource.clip);
            _audioSource.Play();
        }
        if (other.gameObject.tag == "Key")
        {
            _amountOfKeys++;
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            _audioSource.clip = audioClipArray[1];
            _audioSource.PlayOneShot(_audioSource.clip);
            _audioSource.Play();
        }
        if (other.gameObject.tag == "PowerUp")
        {
            ThePlayer.JumpForce = ThePlayer.JumpForce * 1.2f ;
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            _audioSource.clip = audioClipArray[3];
            _audioSource.PlayOneShot(_audioSource.clip);
            _audioSource.Play();
        }
    }
    IEnumerator Aouch()
    {
        yield return new WaitForSeconds(1f);
        _isHurt = false;
    }

    IEnumerator Respawning()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
