using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GRP04.SatanAssistant
{
    public class UiManager : Entity
    {
        [SerializeField] private Animator rememberAnim;
        [Header("Needs")]
        [SerializeField] private Image[] needDisplays;
        [SerializeField] private Vector3 positionRef;
        [Header("Buttons")]
        [SerializeField] private ChoiceButton[] buttons;

        public override void OnSoulOrganised()
        {
            base.OnSoulOrganised();
            rememberAnim.SetTrigger("Remember");
        }

        public void UIShowNeeds(ObjectReferences refs, int needs, JudgedSoul soul)
        {
            for (int i = 0; i < needs; i++)
            {
                needDisplays[i].sprite = refs.Objects[soul.SelectedObjects[i]];
                needDisplays[i].gameObject.SetActive(true);
                needDisplays[i].rectTransform.localPosition = new Vector3(positionRef.x + (i * ((1f / needs) * 8)), positionRef.y, positionRef.z);
            }
        }

        public void UIHideNeeds()
        {
            for (int i = 0; i < needDisplays.Length; i++)
            {
                needDisplays[i].gameObject.SetActive(false);
            }
        }

        public void UpdateAndRandomizeButtons(ObjectReferences refs, int rightIndex)
        {
            int rB = Random.Range(0, buttons.Length);
            buttons[rB].CurrentAnswer = rightIndex;
            buttons[rB].UpdateImageSprite(refs.Objects[rightIndex]);
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i == rB) continue;
                else
                {
                    int randIndex = Random.Range(0, refs.Objects.Length);
                    while(randIndex == rightIndex)
                    {
                        randIndex = Random.Range(0, refs.Objects.Length);
                    }
                    buttons[i].UpdateImageSprite(refs.Objects[randIndex]);
                    buttons[i].CurrentAnswer = randIndex;
                }
            }
        }
    }
}
