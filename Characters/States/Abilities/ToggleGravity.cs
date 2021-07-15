﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New State", menuName = "MasterMarcus/AbilityData/ToggleGravity")]
public class ToggleGravity : StateData
{
    public bool On;
    public bool OnStart;
    public bool OnEnd;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        if (OnStart)
        {
            //CharacterControl control = characterState.GetCharacterControl(animator);
            ToggleGrav(characterState.characterControl);
        }
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        if (OnEnd)
        {
            //CharacterControl control = characterState.GetCharacterControl(animator);
            ToggleGrav(characterState.characterControl);
        }
    }

    private void ToggleGrav(CharacterControl control)
    {
        control.RIGID_BODY.velocity = Vector3.zero;
        control.RIGID_BODY.useGravity = On;
    }
}
