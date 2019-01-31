using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP04.SatanAssistant
{
    public class Entity : MonoBehaviour
    {

        #region Monobehaviour Callbacks

        protected virtual void Start()
        {

        }

        protected virtual void Update()
        {
            
        }

        protected virtual void OnEnable()
        {
            GameManager.state.RegisterEntity(this);
        }

        protected virtual void OnDisable()
        {
            GameManager.state.UnregisterEntity(this);
        }

        #endregion

        #region Entity CallBacks

        public virtual void OnSoulOrganised()
        {

        }

        public virtual void OnSoulEnter()
        {

        }

        public virtual void OnNeedsShown()
        {

        }

        public virtual void OnNeedsHidden()
        {

        }

        public virtual void OnAnswerSent()
        {

        }

        public virtual void OnSoulJudgedRight()
        {

        }

        public virtual void OnSoulJudgedWrong()
        {

        }

        public virtual void OnMinigameWon()
        {

        }



        #endregion
    }
}
