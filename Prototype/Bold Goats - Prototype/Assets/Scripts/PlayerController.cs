using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    private CharacterController Controller;
    private Vector3 PlayerVelocity;
    private bool GroundedPlayer;
    private float PlayerSpeed = 2.0f;
    private float GravityValue = -9.81f;

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

        Vector3 Move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Controller.Move(Move * Time.deltaTime * PlayerSpeed);

        if (Move != Vector3.zero)
        {
            gameObject.transform.forward = Move;
        }

        // Changes the height position of the player..
       // if (Input.GetButtonDown("Crouch") && GroundedPlayer)
       // {
            //Play Crouch Animation
            //Reduce Enemy Sight Lines
       // }

        //Create Kunai
         if (Input.GetMouseButtonDown(0))
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
        


        if (Input.GetKey(KeyCode.R))
        {
            Reload();
        }


        PlayerVelocity.y += GravityValue * Time.deltaTime;
        Controller.Move(PlayerVelocity * Time.deltaTime);

    }


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

}






