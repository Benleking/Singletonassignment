using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectibleUiandObjectv2 : MonoBehaviour
{
    public PlayerCharacter ThePlayer;
    [Header("Sounds")]
    [SerializeField]private AudioClip[] audioClipArray;
    private AudioSource _audioSource;
    private bool _isHurt = false;
    [Header("Unused for this assignment")]
    private int _amountOfKeys;
    [SerializeField] private TextMeshProUGUI _leNombreDeCles;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }
   
    void Update()
    {
       // ManageKeys();
    }
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Bullet" && !_isHurt)
        {
            _isHurt = true;
            StartCoroutine(Aouch());
            TheManager.Instance.Health = TheManager.Instance.Health - 1;
            //Health = Health - 1;
            Debug.Log("Toucher au bullet");
            _audioSource.clip = audioClipArray[0];
            _audioSource.PlayOneShot(_audioSource.clip);
            _audioSource.Play();
        }
        if (other.gameObject.tag == "Health")
        {
            TheManager.Instance.Health = TheManager.Instance.Health + 1;
            //Health = Health + 1;
            Debug.Log("Toucher au firstaid");
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            _audioSource.clip = audioClipArray[2];
            _audioSource.PlayOneShot(_audioSource.clip);
            _audioSource.Play();
        }
        /*if (other.gameObject.tag == "Key")
        {
            _amountOfKeys++;
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            _audioSource.clip = audioClipArray[1];
            _audioSource.PlayOneShot(_audioSource.clip);
            _audioSource.Play();
        }*/
        if (other.gameObject.tag == "PowerUp")
        {
            ThePlayer.JumpForce = ThePlayer.JumpForce * 1.2f ;
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            _audioSource.clip = audioClipArray[3];
            _audioSource.PlayOneShot(_audioSource.clip);
            _audioSource.Play();
        }
        if (other.gameObject.tag == "Gem")
        {
            other.gameObject.SetActive(false);
            TheManager.Instance.TemporaryScore = TheManager.Instance.TemporaryScore + 200;
            _audioSource.clip = audioClipArray[1];
            _audioSource.PlayOneShot(_audioSource.clip);
            _audioSource.Play();
        }
        if (other.gameObject.tag == "Door")
        {
            _audioSource.clip = audioClipArray[4];
            _audioSource.PlayOneShot(_audioSource.clip);
            _audioSource.Play();
            StartCoroutine(OpeningDoor());
        }
    }
    IEnumerator Aouch()
    {
        yield return new WaitForSeconds(1f);
        _isHurt = false;
    }
    IEnumerator OpeningDoor()
    {
        TheManager.Instance.PermanentScore = TheManager.Instance.PermanentScore + TheManager.Instance.TemporaryScore;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }


    private void ManageKeys()
    {
        if (_amountOfKeys >= 5)
        {
            
        }
        //************Key Text
        _leNombreDeCles.text = (_amountOfKeys + "/5");
    }
    
}
