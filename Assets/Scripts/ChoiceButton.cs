using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GRP04.SatanAssistant
{
    public class ChoiceButton : Entity
    {
        [SerializeField] private SoulsManager soulsManager;
        [SerializeField] private Image image;
        [SerializeField] private Animator buttonAnim;
        private int currentAnswer = 0;

        public void SendAnswerToManager()
        {
            soulsManager.SendAnswer(currentAnswer);
            buttonAnim.SetTrigger("buzz");
            GameManager.state.CallOnAnswerSent();
        }

        public void UpdateImageSprite(Sprite sprite, float zAngle)
        {
            image.sprite = sprite;
            image.transform.rotation = Quaternion.Euler(0, 0, zAngle);
        }

        public override void OnSoulOrganised()
        {
            base.OnSoulOrganised();
            image.enabled = false;
        }

        public override void OnNeedsHidden()
        {
            base.OnSoulOrganised();
            image.enabled = true;
        }

        public override void OnSoulJudgedRight()
        {
            base.OnSoulJudgedRight();
            image.enabled = false;
        }

        public override void OnSoulJudgedWrong()
        {
            base.OnSoulJudgedWrong();
            image.enabled = false;
        }

        public override void OnMinigameWon()
        {
            base.OnMinigameWon();
            image.enabled = false;
        }

        public int CurrentAnswer
        {
            get
            {
                return currentAnswer;
            }

            set
            {
                currentAnswer = value;
            }
        }
    }
}
