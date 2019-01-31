using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP04.SatanAssistant
{
    public class Satan : Entity
    {
        [SerializeField] private Animator anim;

        public override void OnSoulJudgedRight()
        {
            base.OnSoulJudgedRight();
            anim.SetTrigger("kick");
        }
    }
}
