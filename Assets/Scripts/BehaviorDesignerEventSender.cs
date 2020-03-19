using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner;
using BehaviorDesigner.Runtime;

public class BehaviorDesignerEventSender : MonoBehaviour
{
    public BehaviorTree BehaviorTree;


    public void SendBtEvent(string theEventToFire)
    {
        BehaviorTree.SendEvent(theEventToFire);
    }
	
}
