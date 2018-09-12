using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class GoogleMobileAdsDemo : MonoBehaviour

{
    private BannerView bannerView;
    public InterstitialAd interstitial;
   
    public void RequestBanner()
    {
#if UNITY_ANDROID
        string appId = "ca-app-pub-3940256099942544~3347511713";
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
        string appId = "ca-app-pub-3940256099942544~1458002511";
        string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        string appId = "unexpected_platform";
        string adUnitId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);
  

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);


        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);

        bannerView.Show();
    }

    public void HideBanner()
    {
        bannerView.Hide();
    }


public void RequestInterstitial()
{
#if UNITY_ANDROID
        string appId = "ca-app-pub-3940256099942544~3347511713";
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string appId = "ca-app-pub-3940256099942544~1458002511";
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string appId = "unexpected_platform";
        string adUnitId = "unexpected_platform";
#endif

    // Initialize the Google Mobile Ads SDK.
    MobileAds.Initialize(appId);

    // Initialize an InterstitialAd.
    interstitial = new InterstitialAd(adUnitId);
    interstitial.OnAdClosed += HideQuit;
    // Create an empty ad request.
    AdRequest request = new AdRequest.Builder().Build();
    // Load the interstitial with the request.
    interstitial.LoadAd(request);   
}

    public void HideInterstitial()
    {
        interstitial.Destroy();
    }
    public void HideQuit(object sender, System.EventArgs args)
    {
        interstitial.Destroy();
        Application.Quit();
    }

}