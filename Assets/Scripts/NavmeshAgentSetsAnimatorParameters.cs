using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshAgentSetsAnimatorParameters : MonoBehaviour
{
    public Animator Animator;
    public NavMeshAgent NavMeshAgent;
    public string BoolVariableName;
    public string FloatVariableName;
    public Vector2 FromFloatMinMax;
    public Vector2 ToFloatMinMax;
 


    private void Update()
    {
        if(BoolVariableName != "")
        {
            UpdateAnimatorBool();
        }

        if(FloatVariableName != "")
        {
            UpdateAnimatorFloat();
        }
               
    }


    void UpdateAnimatorBool()
    {
       if(NavMeshAgent.velocity.magnitude > 0 )
        {
            Animator.SetBool(BoolVariableName, true);
        }
       else
        {
            Animator.SetBool(BoolVariableName, false);
        }
    }

    void UpdateAnimatorFloat()
    {
        float adjustedVelocity = Remap(NavMeshAgent.velocity.magnitude, FromFloatMinMax.x, FromFloatMinMax.y, ToFloatMinMax.x, ToFloatMinMax.y);

        Animator.SetFloat(FloatVariableName, adjustedVelocity);
    }

    public float Remap(float from, float fromMin, float fromMax, float toMin, float toMax)
    {
        var fromAbs = from - fromMin;
        var fromMaxAbs = fromMax - fromMin;

        var normal = fromAbs / fromMaxAbs;

        var toMaxAbs = toMax - toMin;
        var toAbs = toMaxAbs * normal;

        var to = toAbs + toMin;

        return to;
    }


}
