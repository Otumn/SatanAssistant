using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GRP04.SatanAssistant
{
    public class StarFeedBackManager : Entity
    {
        [SerializeField] private EntityCallback callback;
        [SerializeField] private ParticleSystem starParticle;
        [SerializeField] private int particleCount = 8;
        [SerializeField] private bool shouldPlay = false;

        private void CheckAndAppear(EntityCallback cb, int number)
        {
            if (callback == cb)
            {
                if(shouldPlay)
                {
                    starParticle.Play();
                }
                else
                {
                    starParticle.Emit(number);
                }
            }
        }

        public override void OnSoulOrganised()
        {
            base.OnSoulOrganised();
            CheckAndAppear(EntityCallback.OnSoulOrganised, particleCount);
        }

        public override void OnSoulEnter()
        {
            base.OnSoulEnter();
            CheckAndAppear(EntityCallback.OnSoulEnter, particleCount);
        }

        public override void OnNeedsShown()
        {
            base.OnNeedsShown();
            CheckAndAppear(EntityCallback.OnNeedsShown, particleCount);
        }

        public override void OnNeedsHidden()
        {
            base.OnNeedsHidden();
            CheckAndAppear(EntityCallback.OnNeedshidden, particleCount);
        }

        public override void OnSoulJudgedRight()
        {
            base.OnSoulJudgedRight();
            CheckAndAppear(EntityCallback.OnSoulJudgedRight, particleCount);
        }

        public override void OnSoulJudgedWrong()
        {
            base.OnSoulJudgedWrong();
            CheckAndAppear(EntityCallback.OnSoulJudgedWrong, particleCount);
        }

        public override void OnMinigameWon()
        {
            base.OnMinigameWon();
            CheckAndAppear(EntityCallback.OnMinigameWon, particleCount);
        }
    }
}
