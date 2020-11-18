﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteRainState : StateMachineBehaviour
{
    public GameObject MeteoriteRain_prefab;

    private GameObject rain;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform ectoplasma = GameObject.FindWithTag("Ectoplasma").transform;

        rain = Instantiate(MeteoriteRain_prefab, ectoplasma.transform);

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(rain);
    }
}