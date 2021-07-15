using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

public class PlayerController : MonoBehaviour
{
   
    private CharacterController Controller;
    private Vector3 PlayerVelocity;
    private bool GroundedPlayer;
    private bool Crouched = false;
    private float PlayerSpeed = 5.0f;
    private float GravityValue = -9.81f;
    public float ControllerHeight;

    public Collider attackCollider;
    private float timeAttacked;
    public float timeBetweenAttacks;

    public Rigidbody Kunai;
    public int AmountOfKunais = 3;


    private void Start()
    {
        Controller = gameObject.AddComponent<CharacterController>();
        attackCollider.enabled = false;        
    }

    void Update()
    {
        GroundedPlayer = Controller.isGrounded;

        if (GroundedPlayer && PlayerVelocity.y < 0)
        {
            PlayerVelocity.y = 0f;
        }

        ///////////Player movement (Left, Right, Forward, Bacward)///////////
        Vector3 Move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Controller.Move(Move * Time.deltaTime * PlayerSpeed);

        if (Move != Vector3.zero)
        {
            gameObject.transform.forward = Move;
        }

        ///////////Player Crouch///////////
        if (GroundedPlayer == true && Input.GetButtonDown("Crouch"))
        {
            Crouched = !Crouched;
            ToggleCrouch();
            //Play Crouch Animation
            //Reduce Enemy Sight Lines
        }
        



        ///////////Create Kunai///////////
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (AmountOfKunais > 0)
            {
                CreateKunai();
            }
            else
            {
                Debug.Log("Out of Kunais");
            }

        }


        ///////////Reloads Kunais///////////
        ///Will Change after reload stations are included
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }


        ///////////Executing Enemies///////////
        if (Input.GetButtonDown("Execute") && timeAttacked <= Time.time) 
        {

            Debug.Log("Attacking");
            attackCollider.enabled = true;
            timeAttacked = Time.time + timeBetweenAttacks;

            //while (timeAttacked > Time.time)
            //{
            //    Debug.Log(timeAttacked - Time.time);
            //}

            attackCollider.enabled = false;
        }

        

        

        PlayerVelocity.y += GravityValue * Time.deltaTime;
        Controller.Move(PlayerVelocity * Time.deltaTime);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && timeAttacked > timeBetweenAttacks)
        {
            //Enemy collided with the attack trigger, kill / remove the enemy
            other.GetComponent<EnemyState>().Kill();
        }
    }

    ///////////Player Actions///////////
    void CreateKunai()
    {

        Rigidbody clone = Instantiate(Kunai, transform.position, transform.rotation);
        AmountOfKunais -= 1;
        Debug.Log("Kunais left: " + AmountOfKunais);

    }

    void Reload()
    {
        AmountOfKunais = 3;
        Debug.Log("Refilled Kunais");
    }

    void ToggleCrouch() 
    {
        if (Crouched == true)
        {
            GameManager.Instance.Player.transform.localScale = new Vector3(1, .5f, 1);
            Controller.height = ControllerHeight;
            PlayerSpeed = 2.5f;
            Debug.Log("Player speed is now " + PlayerSpeed + " and the player is crouched");
        }
        else 
        {
            Ray ray = new Ray();
            RaycastHit hit;
            ray.origin = transform.position;
            ray.direction = Vector3.up;
           
            if (Physics.Raycast(GameManager.Instance.Player.transform.position, ray.direction, out hit, 2.2f))
            {
                GameManager.Instance.Player.transform.localScale = new Vector3(1, ControllerHeight, 1);
                Controller.height = 1.8f;
                PlayerSpeed = 5f;
                Debug.Log("Player is standing and the speed is " + PlayerSpeed); 
            }
            else
            {
                Debug.Log("Not enough space to stand up!");
            }
        }
    }

    

}






