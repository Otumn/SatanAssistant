using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP04.SatanAssistant
{
    public class JudgedSoul : Entity
    {
        [SerializeField] private int[] selectedObjects;

        private bool judged = false;

        [Header("Movement")]
        [SerializeField] private AnimationCurve forwardCurve;
        private Vector3 initialPos;
        
        [Header("Prototype")]
        [SerializeField] private SpriteRenderer sprite;

        public override void OnSoulOrganised()
        {
            base.OnSoulOrganised();
            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x - 1.5f, pos.y, pos.z);
        }

        public void Randomize(ObjectReferences refs)
        {
            int typeC = Random.Range(0, 3);
            if(typeC == 0)
            {
                sprite.color = Color.red;
            }
            else if(typeC == 1)
            {
                sprite.color = Color.cyan;
            }
            else if(typeC == 2)
            {
                sprite.color = Color.yellow;
            }
            // animator to change the look depending on typeC
            // choose all the objects between the ones possible

            selectedObjects = new int[5];
            for (int i = 0; i < selectedObjects.Length; i++)
            {
                selectedObjects[i] = Random.Range(0, refs.Objects.Length);
            }

            // randomize look and items
        }

        public void MoveForward(float i)
        {
            transform.localPosition = initialPos + new Vector3(i, forwardCurve.Evaluate(i), 0);
        }

        public bool Judged
        {
            get
            {
                return judged;
            }

            set
            {
                judged = value;
            }
        }

        public Vector3 InitialPos
        {
            get
            {
                return initialPos;
            }

            set
            {
                initialPos = value;
            }
        }

        public int[] SelectedObjects
        {
            get
            {
                return selectedObjects;
            }
        }
    }
}
