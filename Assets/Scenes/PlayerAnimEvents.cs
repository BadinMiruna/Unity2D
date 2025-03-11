using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEvents : MonoBehaviour
{
    private SPlayer player;
    void Start()
    {
        player= GetComponentInParent<SPlayer>();
    }

    
   private void  AnimationTriggered()
    {
        player.AttackOver();
    }
    void Update()
    {
        
    }
}
