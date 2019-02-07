using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GRP04.SatanAssistant
{
    public class UiManager : Entity
    {
        [Header("Animations")]
        [SerializeField] private Animator rememberAnim;
        [SerializeField] private Animator satanCanvasAnim;
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
                needDisplays[i].sprite = refs.TortureObjects[soul.SelectedObjects[i]].Texture;
                needDisplays[i].gameObject.SetActive(true);
                needDisplays[i].transform.rotation = Quaternion.Euler(0, 0, refs.TortureObjects[soul.SelectedObjects[i]].ZAngle);
                needDisplays[i].rectTransform.localPosition = new Vector3(positionRef.x + (i * ((1f / needs) * 8)), positionRef.y, positionRef.z);
            }
            satanCanvasAnim.SetTrigger("appear");
        }

        public void UIHideNeeds()
        {
            for (int i = 0; i < needDisplays.Length; i++)
            {
                needDisplays[i].gameObject.SetActive(false);
            }
            satanCanvasAnim.SetTrigger("disappear");
        }

        public void UpdateAndRandomizeButtons(ObjectReferences refs, int rightIndex)
        {
            int rB = Random.Range(0, buttons.Length);
            buttons[rB].CurrentAnswer = rightIndex;
            buttons[rB].UpdateImageSprite(refs.TortureObjects[rightIndex].Texture, refs.TortureObjects[rightIndex].ZAngle);
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i == rB) continue;
                else
                {
                    int randIndex = Random.Range(0, refs.TortureObjects.Length);
                    while(randIndex == rightIndex)
                    {
                        randIndex = Random.Range(0, refs.TortureObjects.Length);
                    }
                    buttons[i].UpdateImageSprite(refs.TortureObjects[randIndex].Texture, refs.TortureObjects[randIndex].ZAngle);
                    buttons[i].CurrentAnswer = randIndex;
                }
            }
        }
    }
}
