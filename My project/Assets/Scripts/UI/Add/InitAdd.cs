using GoogleMobileAds.Api;
using UnityEngine;

namespace AddScripts
{
    public class InitAdd : MonoBehaviour
    {
        private void Awake()
        {
            MobileAds.Initialize(initStatus => { });
        }
    }
}