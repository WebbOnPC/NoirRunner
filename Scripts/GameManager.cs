using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Vector3 platformStartPoint;
    public Transform platformGenerator;

    public DeathMenu theDeathScreen;

    private PlatformDestroyer[] platformList;

    [SerializeField] private string loadLevel;
    // public LoadScreen loadScreen;

   // public StartPlatform startPlatform;

    AudioSource deathAudio;
    public AudioClip DeathAudio;
    AudioSource deathCrackAudio;
    public AudioClip DeathCrackAudio;

    public Text deathText;
    public string[] deathMessage = {
    "Your time has come",
    "You call that jumping",
    "Not even close",
    "Not quite",
    "Well Done!",
    "G A M E   O V E R",
    "Winner Winner Chicken Dinner!",
    "You nearly made it that time",
    "I think you forgot to jump",
    "You call that jumping?",
    "Are you serious? Try again",
    "Try to jump over that next time",
    "I could have done better with my eyes closed",
    "Jump higher next time",
    "You'll be left for the wolves",
    "Almost. Just kidding, not even close",
    "Almost made it, try again",
    "Game Over man, Game Over",
    "Your body was never found",
    "You'll make a lovely feast for the maggots",
    "What's that? Failer",
    "It was lag, I'm sure", };
    public Text coinCounter;
    public int coins = 0;
    public string key = "Death Count: ";

    private bool HasHit = false;
    //private bool Blood = true;

    public static int deathCounter;

    void Start()
    {
        platformStartPoint = platformGenerator.position;
        deathAudio = GetComponent<AudioSource>();
        deathCrackAudio = GetComponent<AudioSource>();
        GameObject g = GameObject.FindGameObjectWithTag("Player");
        coins = PlayerPrefs.GetInt(key);
        HasHit = false;
    }

    public void Update()
    { 
        if (coinCounter != null)
        {
            coinCounter.text = key + PlayerPrefs.GetInt(key);
        }
    }
    
    void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.CompareTag("Player"))
		{
			theDeathScreen.gameObject.SetActive(true);
		}	
	}

    public IEnumerator menuDelay()
    {
        yield return new WaitForSeconds(1.25f);
        theDeathScreen.gameObject.SetActive(true);
        if (deathCounter >= 3)
        {
            //AdController.instance.ShowVideoOrInterstitialAD();
            deathCounter = 0;
        }
        else
        {
            deathCounter++;
        }
    }

    public void RestartGame()
    {
        if (!HasHit)
        {
            HasHit = true;
            coins++;
            PlayerPrefs.SetInt(key, coins);
            deathAudio.PlayOneShot(DeathAudio, 1F);
            deathCrackAudio.PlayOneShot(DeathCrackAudio, 1F);
            string myString = deathMessage[Random.Range(0, deathMessage.Length)];
            deathText.text = myString;
            StartCoroutine(menuDelay());
        }
    }

    public void Reset()
	{
        // SceneManager.LoadScene("level1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
