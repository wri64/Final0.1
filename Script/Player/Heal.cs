using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Heal : Player
{
    [Header("Healing Spell")]
    float healTimer;
    [SerializeField] float timeToHeal;

    void Update()
    {
        Heall();

    }

    void Heall()
    {
        if (Input.GetButton("Healing") && Health < maxHealth && Mana > 0 && Grounded() && !pState.dashing)
        {
            pState.healing = true;
            anim.SetBool("Healing", true);

            //healing
            healTimer += Time.deltaTime;
            if (healTimer >= timeToHeal)
            {
                Health++;
                healTimer = 0;
            }

            //drain mana
            Mana -= Time.deltaTime * manaDrainSpeed;
        }
        else
        {
            pState.healing = false;
            anim.SetBool("Healing", false);
            healTimer = 0;
        }
    }

}
