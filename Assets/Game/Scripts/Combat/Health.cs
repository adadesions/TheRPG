using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TheRPG.Core;

namespace TheRPG.Combat
{    
    public class Health : MonoBehaviour
    {
        [SerializeField] float HP = 100f;
        [SerializeField] float maxHP = 100f;
        [SerializeField] Image globalHPBar;
        [SerializeField] GameObject localHPBar;

        private bool isDead = false;

        private void UpdateHPBar() {
            // Clamp(calValue, minRange, maxRange)
            float hpValue = Mathf.Clamp(HP / maxHP, 0f, 1f);
            if (globalHPBar) {
                globalHPBar.fillAmount = hpValue;
            }

            if (localHPBar) {
                Vector3 curBar = localHPBar.transform.localScale;
                localHPBar.transform.localScale = new Vector3(hpValue, curBar.y, curBar.z);
            }            
        }

        public void TakeDamage(float damage)
        {
            HP = Mathf.Max(HP - damage, 0);
            print(name + "'s Health: " + HP);
            UpdateHPBar();

            if (HP <= 0 && !isDead)
            {
                Die();
            }
        }

        public bool GetIsDead()
        {
            return isDead;
        }

        private void Die()
        {
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }
    }
}

