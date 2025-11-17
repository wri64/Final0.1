using UnityEngine;
using System.Collections;        
using System.Collections.Generic;
using Unity.VisualScripting;

public class CastSpell : Player
{
    [Header("Spell Settings")]
    [SerializeField]  float manaSpellCost = 0.3f;
    [SerializeField]  float timeBetweenCast = 0.5f;
     float timeSinceCast;
    [SerializeField]  float spellDamage;
    [SerializeField]  float downSpellForce;

    [SerializeField] GameObject sideSpellFireball;
    [SerializeField] GameObject upSpellExplosion;
    [SerializeField] GameObject downSpellFireball;

    void Update()
    {
        CastingSpell();

    }

    void CastingSpell()
    {
        if (Input.GetButtonDown("CastSpell") && timeSinceCast >= timeBetweenCast && Mana >= manaSpellCost)
        {
            pState.casting = true;
            timeSinceCast = 0;
            StartCoroutine(CastCoroutine());
        }
        else
        {
            timeSinceCast += Time.deltaTime;
        }

        if (Grounded())
        {
            downSpellFireball.SetActive(false);
        }
        if (downSpellFireball.activeInHierarchy)
        {
            rb.linearVelocity += downSpellForce * Vector2.down;
        }
    }
    IEnumerator CastCoroutine()
    {
        anim.SetBool("Casting", true);
        yield return new WaitForSeconds(0.15f);

        //side cast
        if (yAxis == 0 || (yAxis < 0 && Grounded()))
        {
            GameObject _fireBall = Instantiate(sideSpellFireball, SideAttackTransform.position, Quaternion.identity);

            if (pState.lookingRight)
            {
                _fireBall.transform.eulerAngles = Vector3.zero;
            }
            else
            {
                _fireBall.transform.eulerAngles = new Vector2(_fireBall.transform.eulerAngles.x, 180);

            }
            pState.recoilingX = true;
        }

        //up cast
        else if (yAxis > 0)
        {
            Instantiate(upSpellExplosion, transform);
            rb.linearVelocity = Vector2.zero;
        }

        //down cast
        else if (yAxis < 0 && !Grounded())
        {
            downSpellFireball.SetActive(true);
        }

        Mana -= manaSpellCost;
        yield return new WaitForSeconds(0.35f);
        anim.SetBool("Casting", false);
        pState.casting = false;
    }

}
