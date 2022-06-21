using UnityEngine;
using System.Collections;

public class GemScript : MonoBehaviour
{
    public AudioClip GemCollect;
    AudioSource gemAudio;

    public Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        gemAudio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            rend.enabled = false;
            gemAudio.PlayOneShot(GemCollect, 1F);

            DestroyGem();
        }
    }

    public void ResetGemScript()
    {
        Destroy(this);
    }

    void DestroyGem()
    {
        StartCoroutine(audioDelay());
    }
    public IEnumerator audioDelay()
    {
        yield return new WaitForSeconds(.25f);
        gameObject.SetActive(false);
    }
}