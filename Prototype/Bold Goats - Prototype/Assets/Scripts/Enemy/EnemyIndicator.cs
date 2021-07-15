using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy
{

    [RequireComponent(typeof(EnemyState))]
    public class EnemyIndicator : MonoBehaviour
    {
        EnemyState enemyState;
        Renderer renderer;
        [SerializeField] Color[] colors;
        private void Awake()
        {
            renderer = GetComponent<Renderer>();
        }

        public void HandleOnStateChange(States _states)
        {
            switch (_states)
            {
                case States.Patrol:
                    renderer.material.color = colors[0];
                    break;
                case States.Investigate:
                    renderer.material.color = colors[1];
                    break;
                case States.Alert:
                    renderer.material.color = colors[2];
                    break;
                case States.Chase:
                    renderer.material.color = colors[3];
                    break;
                case States.Attack:
                    renderer.material.color = colors[4];
                    break;
                case States.Return:
                    renderer.material.color = colors[5];
                    break;
                case States.Death:
                    renderer.material.color = colors[6];
                    break;
                default:
                    break;
            }
        }
    }
}
