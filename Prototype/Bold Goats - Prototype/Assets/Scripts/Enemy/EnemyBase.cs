using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{

    public class EnemyBase : MonoBehaviour
    {
        public EnemyState state = EnemyState.Patrol;

    }

    public enum EnemyState
    {
        Patrol,
        Investigate,
        Alert,
        Chase,
        Attack,
        Return
    }


}