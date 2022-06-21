using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image uiImage;

    // Use this for initialization
    void Start()
    {
        uiImage.canvasRenderer.SetAlpha(1.0f);
        StartCoroutine(uiFade());
    }

    public IEnumerator uiFade()
    {
        yield return new WaitForSeconds(.8f);
        FadeOut();
    }

    void FadeOut()
    {
        uiImage.CrossFadeAlpha(0.0f, 1.5f, false);
    }
}
