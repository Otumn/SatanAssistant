using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP04.SatanAssistant
{
    public class WalkingSoul : Entity
    {
        [Header("Movement")]
        [SerializeField] private float speed = 4f;
        [SerializeField] private float minWaitTime = 1f;
        [SerializeField] private float maxWaitTime = 5f;
        [SerializeField] private float distRange = 0.5f;
        [SerializeField] private Transform pointA;
        [SerializeField] private Transform pointB;
        [Header("Animations")]
        [SerializeField] private Animator anim;

        private Vector3 pointAPos;
        private Vector3 pointBPos;
        private Vector3 movementDir;
        private Vector3 movementStart;
        private Vector3 posRef;
        private bool isMoving = false;
        private bool isOnPointA = true;

        protected override void Start()
        {
            base.Start();
            pointAPos = pointA.position;
            pointBPos = pointB.position;
            transform.position = pointAPos;
            movementDir = pointBPos - transform.position;
            movementStart = pointAPos;
            StartCoroutine(WaitForNewCourse());
        }

        protected override void Update()
        {
            base.Update();
            Movement();
        }

        private void Movement()
        {
            Debug.Log("Dir : " + movementDir);
            anim.SetBool("walk", isMoving);
            anim.transform.localPosition = Vector3.zero;
            anim.transform.localRotation = Quaternion.identity;
            transform.rotation = Quaternion.LookRotation(movementDir, Vector3.up);
            if(isMoving)
            {
                float dist = Vector3.Distance(transform.position, movementStart + movementDir);
                transform.position = Vector3.SmoothDamp(transform.position, movementStart + movementDir, ref posRef, speed);
                if (dist < distRange)
                {
                    isMoving = false;
                    StartCoroutine(WaitForNewCourse());
                    transform.position = movementStart + movementDir;
                }
            }
        }

        IEnumerator WaitForNewCourse()
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            SetCourse();
        }

        private void SetCourse()
        {
            if(isOnPointA) // go point b
            {
                movementDir = (pointBPos - transform.position);
                movementStart = pointAPos;
                isOnPointA = false;
            }
            else // go point a
            {
                movementDir = (pointAPos - transform.position);
                movementStart = pointBPos;
                isOnPointA = true;
            }
            isMoving = true;
            Debug.Log("dir from set course : " + movementDir);
        }

        public override void OnMinigameWon()
        {
            base.OnMinigameWon();
            StopAllCoroutines();
        }

        public override void OnSoulJudgedWrong()
        {
            base.OnSoulJudgedWrong();
            StopAllCoroutines();
        }

    }
}
