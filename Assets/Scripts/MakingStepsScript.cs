using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingStepsScript : StateMachineBehaviour
{
    private GameObject leftLeg;
    private GameObject rightLeg;
    public float legYOffset;
    Vector3 leftPosition, rightPosition;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        leftLeg = animator.gameObject.transform.GetChild(0).gameObject;
        rightLeg = animator.gameObject.transform.GetChild(1).gameObject;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float baseY = animator.gameObject.transform.position.y - 0.68f;
        
        leftPosition = new Vector3(leftLeg.transform.position.x, baseY + 0.1f * Mathf.Cos(6*Time.time), leftLeg.transform.position.z);
        leftLeg.transform.position = leftPosition;
        rightPosition = new Vector3(rightLeg.transform.position.x, baseY + 0.1f * Mathf.Cos(6*Time.time + 3), rightLeg.transform.position.z);
        rightLeg.transform.position = rightPosition;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
