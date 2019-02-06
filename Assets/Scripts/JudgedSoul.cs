using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP04.SatanAssistant
{
    public class JudgedSoul : Entity
    {
        [SerializeField] private int[] selectedObjects;
        [SerializeField] private Animator anim;


        [Header("Movement")]
        [SerializeField] private AnimationCurve forwardCurve;
        [SerializeField] private AnimationCurve ejectionCurve;
        [SerializeField] private float ejectionSpeed = 4f;
        [SerializeField] private float ejectionMaxDist = 5f;

        private bool judged = false;
        private bool isEjected = false;
        private float ejectionInc = 0;
        private Vector3 ejectionStart;
        private Vector3 initialPos;

        protected override void Update()
        {
            base.Update();
            anim.transform.localPosition = Vector3.zero;
            Ejection();
        }

        public override void OnSoulOrganised()
        {
            base.OnSoulOrganised();
            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x - 1.5f, pos.y, pos.z);
        }

        public void Randomize(ObjectReferences refs)
        {
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

        public void Eject()
        {
            isEjected = true;
            anim.SetTrigger("eject");
            ejectionStart = transform.position;
        }

        private void Ejection()
        {
            if(isEjected)
            {
                transform.position = ejectionStart + new Vector3(ejectionInc * ejectionMaxDist, ejectionCurve.Evaluate(ejectionInc), 0);
                Debug.Log("Height : " + ejectionCurve.Evaluate(ejectionInc));
                ejectionInc += Time.deltaTime * ejectionSpeed;
                if(ejectionInc > 1)
                {
                    transform.position = ejectionStart + new Vector3(ejectionInc * ejectionMaxDist, ejectionCurve.Evaluate(ejectionInc), 0);
                    isEjected = false;
                    ejectionInc = 0;
                    gameObject.SetActive(false);
                }
            }
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

        public Animator Anim
        {
            get
            {
                return anim;
            }

            set
            {
                anim = value;
            }
        }
    }
}
