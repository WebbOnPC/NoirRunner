using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.Advertisements;

public class AdController : MonoBehaviour
{
    public static AdController instance;

    private string gameId = "3643058";
    //private string videoId = "video";
    private string rewarded_video_ad = "rewardedVideo";
    //private string bannerId = "Banner";

    int doshAmount;

    public bool testMode = true;

    public bool turnOffAds;

    private void Awake()
    {
        doshAmount = PlayerPrefs.GetInt("doshTotal");

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else if(turnOffAds == true)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            //StartCoroutine(ShowBannerWhenReady());
        }
    }

    void Update()
    {
        if (turnOffAds == true)
        {
            Destroy(gameObject);
            Destroy(this);
        }
        else
        {
            turnOffAds = false;
            Monetization.Initialize(gameId, false);
            Advertisement.Initialize(gameId, false);
            //Monetization.Initialize(gameId, testMode);
            //Advertisement.Initialize(gameId, testMode);
        }
    }
    /*
    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(bannerId))
        {
            yield return new WaitForSeconds(0.1f);
        }
        Advertisement.Banner.Show(bannerId);
    }
    /*
    public IEnumerator ShowAdWhenReady()
    {
        while (!Monetization.IsReady(videoId))
        {
            yield return new WaitForSeconds(0.25f);
        }
        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent(videoId) as ShowAdPlacementContent;
        if (ad != null)
        {
            ad.Show();
        }
    }
    */
    /*
    public void ShowVideoOrInterstitialAD()
    {
        if (Monetization.IsReady(videoId))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(videoId) as ShowAdPlacementContent;

            if (ad != null)
            {
                ad.Show();
            }
        }
    }   
    */
    public void PlayRewardedVideo()
    {
        if (Monetization.IsReady(rewarded_video_ad))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(rewarded_video_ad) as ShowAdPlacementContent;

            if (ad != null)
            {
                ad.Show();
                doshAmount += 2500;
                PlayerPrefs.SetInt("doshTotal", doshAmount);
            }
        }
    }
}