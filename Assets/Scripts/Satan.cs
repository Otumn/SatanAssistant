using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP04.SatanAssistant
{
    public class Satan : Entity
    {
        [SerializeField] private Animator anim;
        private Vector3 pos;

        protected override void Start()
        {
            base.Start();
            pos = transform.position;
        }

        protected override void Update()
        {
            base.Update();
            transform.position = pos;
        }

        public override void OnSoulJudgedRight()
        {
            base.OnSoulJudgedRight();
            anim.SetTrigger("dance");
        }
    }
}
