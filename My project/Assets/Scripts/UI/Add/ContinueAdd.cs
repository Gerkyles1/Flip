using UnityEngine;
using GoogleMobileAds.Api;
using GameProces;

namespace AddScripts
{
    public class ContinueAdd : MonoBehaviour
    {

        [SerializeField] Player _player;
        private RewardedAd _rewardedAd;
        private const string AD_ID = "ca-app-pub-3940256099942544/5224354917";
        public static bool didAddWached = false;

        private void OnEnable()
        {
            _rewardedAd = new RewardedAd(AD_ID);
            AdRequest request = new AdRequest.Builder().Build();
            _rewardedAd.LoadAd(request);
            _rewardedAd.OnUserEarnedReward += Continue;
        }

        public void Continue(object sender, Reward args)
        {
            _player.Continue();

            Pause.pause = false;

            didAddWached = true;
            Score._instance.Continue();

            

        }

        public void Show()
        {
            if(_rewardedAd.IsLoaded())
                _rewardedAd.Show();
        }



    }
}