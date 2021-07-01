using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{

    public class EnemyState : MonoBehaviour
    {
        public States state = States.Patrol;

        public delegate void StateChange();
        public event StateChange Alert;
        public event StateChange Investigate;
        public event StateChange Return;

        public void InvokeAlert()
        {
            if (Alert != null)
            {
                Alert.Invoke();
            }
        }

        public void InvokeInvestigate()
        {
            if (Investigate != null)
            {
                Investigate.Invoke();
            }
        }

        public void InvokeReturn()
        {
            if (Return != null)
            {
                Return.Invoke();
            }
        }
    }

    public enum States
    {
        Patrol,
        Investigate,
        Alert,
        Chase,
        Attack,
        Return
    }


}