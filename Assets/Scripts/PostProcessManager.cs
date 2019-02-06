using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace GRP04.SatanAssistant
{
    public enum EntityCallback { None, OnSoulOrganised, OnSoulEnter, OnNeedsShown, OnNeedshidden, OnSoulJudgedRight, OnSoulJudgedWrong, OnMinigameWon }
    public class PostProcessManager : Entity
    {
        [SerializeField] private EntityCallback apparitionCallBack;
        [SerializeField] private PostProcessVolume volume;
        [SerializeField] private AnimationCurve apparitionCurve;
        [SerializeField] private AnimationCurve disparitionCurve;
        [SerializeField] private bool shouldStayAfterApparition = false;
        [SerializeField] private float speed = 10f;
        private float incrementer;
        private bool shouldAppear = false;
        private bool shouldDisappear = false;

        #region Monobehaviour callbacks

        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {
            base.Update();
            ApparitionManager();
            DisparitionManager();
        }

        #endregion

        #region Entity callbacks

        public override void OnSoulOrganised()
        {
            base.OnSoulOrganised();
            CheckforApparition(EntityCallback.OnSoulOrganised);
        }

        public override void OnSoulEnter()
        {
            base.OnSoulEnter();
            CheckforApparition(EntityCallback.OnSoulEnter);
        }

        public override void OnNeedsShown()
        {
            base.OnNeedsShown();
            CheckforApparition(EntityCallback.OnNeedsShown);
        }

        public override void OnNeedsHidden()
        {
            base.OnNeedsHidden();
            CheckforApparition(EntityCallback.OnNeedshidden);
        }

        public override void OnSoulJudgedRight()
        {
            base.OnSoulJudgedRight();
            CheckforApparition(EntityCallback.OnSoulJudgedRight);
        }

        public override void OnSoulJudgedWrong()
        {
            base.OnSoulJudgedWrong();
            CheckforApparition(EntityCallback.OnSoulJudgedWrong);
        }

        public override void OnMinigameWon()
        {
            base.OnMinigameWon();
            CheckforApparition(EntityCallback.OnMinigameWon);
        }

        #endregion

        private void ApparitionManager()
        {
            if(shouldAppear)
            {
                volume.weight = apparitionCurve.Evaluate(incrementer);
                incrementer += Time.deltaTime * speed;
                if(incrementer > 1)
                {
                    shouldAppear = false;
                    incrementer = 0;
                    volume.weight = 1;
                    if(shouldStayAfterApparition)
                    {
                        return;
                    }
                    else
                    {
                        shouldDisappear = true;
                    }
                }
            }
        }

        private void DisparitionManager()
        {
            if(shouldDisappear)
            {
                volume.weight = disparitionCurve.Evaluate(incrementer);
                incrementer += Time.deltaTime * speed;
                if(incrementer > 1)
                {
                    shouldDisappear = false;
                    incrementer = 0;
                }
            }
        }

        private void CheckforApparition(EntityCallback callback)
        {
            if(apparitionCallBack == callback)
            {
                shouldAppear = true;
            }
        }
    }
}
