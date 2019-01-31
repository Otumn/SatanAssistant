using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GRP04.SatanAssistant
{
    public class Timer :  Entity
    {
        [SerializeField] private float maximumTime = 20f;
        [SerializeField] private Text timer;
        private bool shouldDecount = false;
        private float decountTime;

        protected override void Start()
        {
            base.Start();
            decountTime = maximumTime;
        }

        protected override void Update()
        {
            base.Update();
            TimeManager();
        }

        private void TimeManager()
        {
            if (shouldDecount)
            {
                decountTime -= Time.deltaTime;
                if (decountTime < 0)
                {
                    decountTime = 0f;
                    shouldDecount = false;
                    GameManager.state.CallOnSoulJudgedWrong();
                    // game over
                }
            }
            timer.text = decountTime.ToString("F");
        }

        public override void OnNeedsHidden()
        {
            base.OnNeedsHidden();
            shouldDecount = true;
        }

        public override void OnSoulJudgedRight()
        {
            base.OnSoulJudgedRight();
            shouldDecount = false;
        }

        public override void OnSoulJudgedWrong()
        {
            base.OnSoulJudgedWrong();
            shouldDecount = false;
        }

        public override void OnMinigameWon()
        {
            base.OnMinigameWon();
            shouldDecount = false;
        }
    }

}
