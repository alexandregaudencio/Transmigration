using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player.Data.Score
{
    public interface IScore
    {
        public void IncreaseKillCount();
        public void addDamageAmount(float damage);
        public void IncreaseDeathCount();


    }
}

