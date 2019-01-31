using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP04.SatanAssistant
{
    public class CameraEntity : Entity
    {
        [SerializeField] private EZCameraShake.CameraShaker camShaker;

        public override void OnAnswerSent()
        {
            base.OnSoulJudgedRight();
            camShaker.ShakeOnce(10, 0.5f, 0.1f, 0.1f);
        }

        public override void OnSoulJudgedRight()
        {
            base.OnSoulJudgedRight();
            camShaker.ShakeOnce(10, 0.1f, 0.1f, 0.2f);
        }
    }
}
