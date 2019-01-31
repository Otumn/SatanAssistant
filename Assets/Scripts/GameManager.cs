using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP04.SatanAssistant
{
    public class GameManager : MonoBehaviour
    {
        public static GameSate state = new GameSate();
    }

    public class GameSate
    {
        private int judgedSoulIndex = 0;
        private int goalSoulNumber = 0;
        private List<Entity> entities = new List<Entity>();

        public void RegisterEntity(Entity ent)
        {
            entities.Add(ent);
        }

        public void UnregisterEntity(Entity ent)
        {
            entities.Remove(ent);
        }

        #region Callbacks

        public void CallOnSoulOrganized()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].OnSoulOrganised();
            }
        }

        public void CallOnSoulEnter()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].OnSoulEnter();
            }
        }

        public void CallOnNeedsShown()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].OnNeedsShown();
            }
        }

        public void CallOnNeedsHidden()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].OnNeedsHidden();
            }
        }

        public void CallOnAnswerSent()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].OnAnswerSent();
            }
        }

        public void CallOnSoulJudgedRight()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].OnSoulJudgedRight();
            }
        }

        public void CallOnSoulJudgedWrong()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].OnSoulJudgedWrong();
            }
        }

        public void CallOnMiniGameWon()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].OnMinigameWon();
            }
        }

        #endregion

        public int JudgedSoulIndex
        {
            get
            {
                return judgedSoulIndex;
            }

            set
            {
                judgedSoulIndex = value;
            }
        }

        public int GoalSoulNumber
        {
            get
            {
                return goalSoulNumber;
            }

            set
            {
                goalSoulNumber = value;
            }
        }
    }
}
