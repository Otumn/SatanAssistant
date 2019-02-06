using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP04.SatanAssistant
{
    public class SoulsManager : Entity
    {
        [SerializeField] [Range(0, 2)] private int difficulty = 0;
        [SerializeField] private ObjectReferences objectReferences;
        [SerializeField] private UiManager uiManager;
        [SerializeField] private JudgedSoul[] judgedSouls;
        [SerializeField] private AnimationCurve difficultyCurve;
        [SerializeField] private AnimationCurve answersDependingOnIndex;
        [SerializeField] private AnimationCurve timeToMemorizeOnIndex;
        [SerializeField] private float soulsSpeed = 0.05f;

        private bool shouldMoveSoulsForward = false;
        private bool isWaitingForAnswer = false;
        private int soulsGoal = 0;
        private int soulsJudged = 0;
        private int answersGoal = 0;
        private int answerIndex = 0;
        private float incrementer = 0;

        protected override void Start()
        {
            base.Start();
            OrganizeSouls(difficulty);
        }

        protected override void Update()
        {
            base.Update();
            SoulsMovement();
        }

        private void OrganizeSouls(int difficulty)
        {
            for (int i = 0; i < judgedSouls.Length; i++)
            {
                judgedSouls[i].gameObject.SetActive(false);
            }
            soulsGoal = Mathf.RoundToInt(difficultyCurve.Evaluate(difficulty));
            for (int i = 0; i < soulsGoal; i++)
            {
                judgedSouls[i].gameObject.SetActive(true);
                judgedSouls[i].Randomize(objectReferences);
            }
            GameManager.state.GoalSoulNumber = Mathf.RoundToInt(difficultyCurve.Evaluate(difficulty));
            GameManager.state.CallOnSoulOrganized();
            MoveRemainingSoulsForward();
        }

        public void MoveRemainingSoulsForward()
        {
            if (shouldMoveSoulsForward) return;
            shouldMoveSoulsForward = true;
            for (int i = 0; i < judgedSouls.Length; i++)
            {
                if(judgedSouls[i].gameObject.activeSelf && !judgedSouls[i].Judged)
                {
                    judgedSouls[i].InitialPos = judgedSouls[i].transform.localPosition;
                    judgedSouls[i].Anim.SetBool("walk", true);
                }
            }
        }

        private void SoulsMovement()
        {
            if (shouldMoveSoulsForward)
            {
                for (int i = 0; i < judgedSouls.Length; i++)
                {
                    if(judgedSouls[i].gameObject.activeSelf && !judgedSouls[i].Judged)
                    {
                        judgedSouls[i].MoveForward(incrementer);
                    }
                }
                incrementer += soulsSpeed;
                if (incrementer > 1.5f)
                {
                    shouldMoveSoulsForward = false;
                    incrementer = 0;
                    for (int i = 0; i < judgedSouls.Length; i++)
                    {
                        if (judgedSouls[i].gameObject.activeSelf && !judgedSouls[i].Judged)
                        {
                            judgedSouls[i].transform.localPosition = judgedSouls[i].InitialPos + new Vector3(1.5f, 0, 0);
                            judgedSouls[i].Anim.SetBool("walk", false);
                        }
                    }
                    BringNewSoul();
                }
            }
        }

        private void BringNewSoul()
        {
            GameManager.state.CallOnSoulEnter();
            judgedSouls[GameManager.state.JudgedSoulIndex].Anim.SetBool("walk", false);
            judgedSouls[GameManager.state.JudgedSoulIndex].Anim.SetBool("judged", true);
            int answers = Mathf.RoundToInt(answersDependingOnIndex.Evaluate(GameManager.state.JudgedSoulIndex));
            uiManager.UIShowNeeds(objectReferences, answers, judgedSouls[GameManager.state.JudgedSoulIndex]);
            answersGoal = answers;
            StartCoroutine(DelayToMemorize());
        }

        IEnumerator DelayToMemorize()
        {
            yield return new WaitForSeconds(timeToMemorizeOnIndex.Evaluate(GameManager.state.JudgedSoulIndex));
            uiManager.UIHideNeeds();
            GameManager.state.CallOnNeedsHidden();
            uiManager.UpdateAndRandomizeButtons(objectReferences, judgedSouls[GameManager.state.JudgedSoulIndex].SelectedObjects[answerIndex]);
            isWaitingForAnswer = true;
        }

        public void SendAnswer(int answer)
        {
            if(isWaitingForAnswer)
            {
                if(answer == judgedSouls[GameManager.state.JudgedSoulIndex].SelectedObjects[answerIndex])
                {
                    answerIndex++;
                    if(answerIndex == answersGoal)
                    {
                        judgedSouls[GameManager.state.JudgedSoulIndex].Judged = true;
                        //judgedSouls[GameManager.state.JudgedSoulIndex].gameObject.SetActive(false);
                        judgedSouls[GameManager.state.JudgedSoulIndex].Eject();
                        soulsJudged++;
                        if(soulsJudged == soulsGoal)
                        {
                            Debug.Log("Won this minigame");
                            GameManager.state.CallOnMiniGameWon();
                            // win the minigame
                            return;
                        }
                        GameManager.state.JudgedSoulIndex++;
                        MoveRemainingSoulsForward();
                        answerIndex = 0;
                        Debug.Log("win");
                        GameManager.state.CallOnSoulJudgedRight();
                        return;
                    }
                    uiManager.UpdateAndRandomizeButtons(objectReferences, judgedSouls[GameManager.state.JudgedSoulIndex].SelectedObjects[answerIndex]);
                    // right
                }
                else
                {
                    GameManager.state.CallOnSoulJudgedWrong();
                    Debug.Log("Lose");
                    return;
                    // wrong
                }
            }
        }
    }
}
