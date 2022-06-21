using UnityEngine;
using System.Collections;

public class DirtScript : MonoBehaviour
{
    public int destroyObject;
    public bool inTrigger;

    AudioSource dirtAudio;

    public Renderer rend;

    public void Start()
    {

        rend = GetComponent<Renderer>();
        rend.enabled = true;
        dirtAudio = GetComponent<AudioSource>();
    }
    public void Update()
    {
        if (PlayerPrefs.GetInt("destroyObject") > 0 && inTrigger == true)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Explosion")
        {
            inTrigger = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Explosion")
        {
            inTrigger = true;
        }
        if (col.gameObject.tag == "Player")
        {
            dirtAudio.PlayOneShot(dirtAudio.clip, 0.6F);
            rend.enabled = false;
            DestroyDirt();
        }
    }
    public IEnumerator audioDelay()
    {
        yield return new WaitForSeconds(.4f);
        gameObject.SetActive(false);
    }

    void DestroyDirt()
    {
        StartCoroutine(audioDelay());
        //  Destroy(gameObject);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Explosion")
        {
            inTrigger = false;
        }
    }

}
