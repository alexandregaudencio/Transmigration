using CharacterNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterNamespace
{
    public class StaminManager : MonoBehaviour
    {
        [Min(0)] private float dashStamin;
        [Min(0)] private float maxDashStamin;
        private CharacterProperty characterProperty;
        public event Action staminChangesAction;
        private float dashStaminRecoveryInseconds => characterProperty.DashStaminRecoveryPercentagemInSeconds;
        private void Awake()
        {
            characterProperty = GetComponent<PlayerController>().CharacterProperty;
        }
        private void Start()
        {
            dashStamin = characterProperty.DashStamin;
            maxDashStamin = characterProperty.MaxDashStamin;
        }
        public float DashStaminFraction => dashStamin / maxDashStamin;
        public float MaxDashStamin { get => maxDashStamin; }
        public float DashStamin { get => dashStamin; }
        public bool CanDash => (dashStamin >= characterProperty.DashStaminCost);
        
        public void spentStamin()
        {
            dashStamin -= characterProperty.DashStaminCost;
            staminChangesAction?.Invoke();
        }


        private void FixedUpdate()
        {
            DashStaminRecovery();
        }

        public void DashStaminRecovery()
        {
            if (DashStamin <= maxDashStamin)
            {
                float dashToIncrease = (dashStaminRecoveryInseconds/ 100);
                //float newStaminAmough = dashStamin + maxDashStamin * dashToIncrease;
                //dashStamin = Mathf.Lerp(dashStamin, newStaminAmough, Time.fixedDeltaTime);
                dashStamin += dashToIncrease;
                staminChangesAction?.Invoke();
            }

        }
    }
}

