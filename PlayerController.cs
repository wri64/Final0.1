using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Player player;
    public bool jumpPressed;
    public bool healPressed;
    public bool dashPressed;

    void Update()
    {
        GetInputs();
    }

    void GetInputs()
    {
        player.xAxis = Input.GetAxisRaw("Horizontal");
        player.yAxis = Input.GetAxisRaw("Vertical");
        player.attack = Input.GetButtonDown("Attack");
        jumpPressed = Input.GetButtonDown("Jump");
        healPressed = Input.GetButtonDown("Healing");
        dashPressed = Input.GetButtonDown("Dash");
        
    }
}
