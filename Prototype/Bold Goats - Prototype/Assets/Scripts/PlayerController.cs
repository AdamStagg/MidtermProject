using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
public class PlayerController : MonoBehaviour
{
   
    private CharacterController Controller;
    public Transform PlayerTransform;
    public Transform EnemyTransform;
    private Vector3 PlayerVelocity;
    private bool GroundedPlayer;
    private bool Crouched = false;
    private float PlayerSpeed = 5.0f;
    private float DistanceToEnemy;
    private float GravityValue = -9.81f;
    public float ControllerHeight;
    

    public Rigidbody Kunai;
    public int AmountOfKunais = 3;


    private void Start()
    {
        Controller = gameObject.AddComponent<CharacterController>();
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
        DistanceToEnemy = Vector3.Distance(transform.position, EnemyTransform.position);
        if (DistanceToEnemy < .3f && Input.GetButtonDown("Execute")) 
        {
            ExecuteEnemy();
        }

        PlayerVelocity.y += GravityValue * Time.deltaTime;
        Controller.Move(PlayerVelocity * Time.deltaTime);

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
            PlayerTransform.localScale = new Vector3(1, .5f, 1);
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
           
            if (Physics.Raycast(PlayerTransform.position, ray.direction, out hit, 2.2f))
            {
                PlayerTransform.localScale = new Vector3(1, ControllerHeight, 1);
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

    void ExecuteEnemy() 
    {
        //Perform Execution animation
        EnemyState enemy = new EnemyState();
        enemy.Kill();
    
    }

}






