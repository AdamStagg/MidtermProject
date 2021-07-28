using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

public class PlayerController : MonoBehaviour
{
    ///////////Basic Player Movement///////////
    public Transform PlayerTransform;
    private CharacterController Controller;
    private Vector3 PlayerVelocity;
    private bool GroundedPlayer;
    private bool Crouched = false;
    private bool Running = false;
    public float PlayerSpeed = 5.0f;
    private float GravityValue = -9.81f;
    private float ControllerHeight = .25f;


    ///////////Variables for Attacking///////////
    public Transform EnemyTransform;
    
   

    ///////////Variables for Kunai///////////
    public Rigidbody Kunai;
    public int AmountOfKunais = 3;

    ///////////Variables for Distractable///////////
    public GameObject Distractable;
    public int AmountOfDistractables = 3;

    ///////////Variables for Climbing///////////
    /* public bool Climbing;
     private bool InPosition;
     private bool IsLerping;
     private float PosT;
     private float Delta;
     public float PositionOffset;
     public float OffsetFromWall = .3f;
     public float SpeedMultiplier = .2f;
     public float ClimbSpeed = 3f;
     public float RotateSpeed = 5f;
     Vector3 StartingPosition;
     Vector3 TargetPosition;
     Quaternion StartRotation;
     Quaternion TargetRotation;
     Transform Helper;
     public Animator Anim;
    */

    ///////////Variables for Audio///////////
    public AudioSource RunAudio;
    public AudioSource WalkAudio;
    public AudioSource CrouchAudio;


    private void Start()
    {
        Controller = GetComponent<CharacterController>();
        
       /* Helper = new GameObject().transform;
        Helper.name = "Climb Helper";
        CheckForClimb();
       */
    }

    void Update()
    {

        GroundedPlayer = Controller.isGrounded;

        if (GroundedPlayer && PlayerVelocity.y < 0)
        {
            PlayerVelocity.y = 0f;
        }


        // Delta = Time.deltaTime;
        // Tick(Delta);

        ///////////Player movement (Left, Right, Forward, Bacward)///////////
        Vector3 Move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


        ///////////Camera Movement///////////
        Controller.Move(Camera.main.transform.right * Move.x * Time.deltaTime * PlayerSpeed);
        Controller.Move(Camera.main.transform.forward * Move.z * Time.deltaTime * PlayerSpeed);
       
        transform.forward = Camera.main.transform.forward;

        Vector3 angles = transform.rotation.eulerAngles;
        angles.x = 0;
        angles.z = 0;

        transform.rotation = Quaternion.Euler(angles);

        ///////////Player Run///////////
        if (Input.GetButtonDown("Run")) 
        {
            Running = !Running;
            Run();
        }

        ///////////Player Crouch///////////
        if (Input.GetButtonDown("Crouch"))
        {
            Crouched = !Crouched;
            ToggleCrouch();
            //Play Crouch Animation
            //Reduce Enemy Sight Lines
        }
        



        ///////////Create Kunai///////////
     /*   if (Input.GetKeyDown(KeyCode.Space))
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
     */

        ///////////Create Distractable///////////
        if (Input.GetKeyDown(KeyCode.Q))
        {

            if (AmountOfDistractables > 0)
            {
                CreateDistractable();
            }
            else
            {
                Debug.Log("Out of Distractions");
            }

        }


        ///////////Reloads Kunais///////////
        ///Will Change after reload stations are included
       /* if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadKunais();
        }
       */

        ///////////Reloads Distractables///////////
        ///Will Change after reload stations are included
        if (Input.GetKeyDown(KeyCode.T))
        {
            ReloadDistractables();
        }


        ///////////Executing Enemies///////////
      /*  DistanceToEnemy = Vector3.Distance(transform.position, EnemyTransform.position);
        if (DistanceToEnemy < .3f && Input.GetButtonDown("Execute")) 
        {
            ExecuteEnemy();
            Debug.Log("Attacking");
            attackCollider.enabled = true;


            StartCoroutine(WaitSomeTime(0.2f));

        }
      */
        

        PlayerVelocity.y += GravityValue * Time.deltaTime;
        Controller.Move(PlayerVelocity * Time.deltaTime);

    }


    ///////////Support Methods///////////
    ///Wait time for attack
 /*   IEnumerator WaitSomeTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
       attackCollider.enabled = false;
    }
  */

    ///Kill enemy when colliding with them
  /*  public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Collide");
            //Enemy collided with the attack trigger, kill / remove the enemy
            other.GetComponent<EnemyState>().Kill();
        }
    }

    ///Checking if out of collider
    private void OnTriggerExit(Collider other)
    {

        Debug.Log("Trigger exit with " + other.name);
    }
  */

    ///Tick method for climbing
  /*  public void Tick(float delta) 
    {
        if (!InPosition) 
        {
            GetInPosition(delta);
            return;
        }

        if (!IsLerping)
        {
            float Hor = Input.GetAxis("Horizontal");
            float Vert = Input.GetAxis("Vertical");
            float M = Mathf.Abs(Hor) + Mathf.Abs(Vert);

            Vector3 H = Helper.right * Hor;
            Vector3 V = Helper.up * Vert;
            Vector3 Move = (H + V).normalized;

            bool canMove = CanMove(Move);
            if (!canMove || Move == Vector3.zero) 
            {
                return;
            }

            PosT = 0;
            IsLerping = true;
            StartingPosition = transform.position;
            //Vector3 TP = Helper.position - transform.position;
            TargetPosition = Helper.position;

        }
        else 
        {
            PosT += delta * ClimbSpeed;
            if (PosT > 1) 
            {
                PosT = 1;
                IsLerping = false;

            }

            Vector3 ClimbPosition = Vector3.Lerp(StartingPosition, TargetPosition, PosT);
            transform.position = ClimbPosition;
            transform.rotation = Quaternion.Slerp(transform.rotation, Helper.rotation, delta * RotateSpeed);
        }


    }
    ///Checking if the Player can move on the wall
    bool CanMove(Vector3 moveDir) 
    {
        Vector3 Origin = transform.position;
        float Distance = PositionOffset;
        Vector3 Direction = moveDir;
        Debug.DrawRay(Origin, Direction * Distance, Color.red);
        RaycastHit hit;

        if (Physics.Raycast(Origin, Direction, out hit, Distance)) 
        {
            return false;
        }

        Origin += moveDir * Distance;
        Direction = Helper.forward;
        float Distance2 = .5f;

        Debug.DrawRay(Origin, Direction * Distance2, Color.blue);

        if (Physics.Raycast(Origin, Direction, out hit, Distance)) 
        {
            Helper.position = PosWithOffset(Origin, hit.point);
            Helper.rotation = Quaternion.LookRotation(-hit.normal);
            return true;
        }

        Origin += Direction * Distance2;
        Direction = -Vector3.up;

        Debug.DrawRay(Origin, Direction, Color.yellow);
        if (Physics.Raycast(Origin, Direction, out hit, Distance2)) 
        {
            float angle = Vector3.Angle(Helper.up, hit.normal);
            if (angle < 40) 
            {
                Helper.position = PosWithOffset(Origin, hit.point);
                Helper.rotation = Quaternion.LookRotation(-hit.normal);
                return true;
            }
        }

        return false;
    }

    ///Putting the player in position to climb
    void GetInPosition(float delta) 
    {
        PosT += delta;

        if (PosT > 1) 
        {
            PosT = 1;
            InPosition = true;

            //enable the ik (idk something from the tutorial for climbing)
        }

        Vector3 TP = Vector3.Lerp(StartingPosition, TargetPosition, PosT);
        transform.position = TP;
        transform.rotation = Quaternion.Slerp(transform.rotation, Helper.rotation, delta * RotateSpeed);

    }

    ///Climbing slanted and crooked surfaces
    Vector3 PosWithOffset(Vector3 origin, Vector3 target) 
    {
        Vector3 dir = origin - target;
        dir.Normalize();
        Vector3 offset = dir * OffsetFromWall;
        return target + offset;
    }
  */

    ///////////Player Actions///////////

    ///Throwing Kunais
  /*  void CreateKunai()
    {

        Instantiate(Kunai, transform.position, transform.rotation);
        AmountOfKunais -= 1;
        Debug.Log("Kunais left: " + AmountOfKunais);

    }
*/

    ///Distractions
    void CreateDistractable() 
    {
        Instantiate(Distractable, transform.position, transform.rotation);
        AmountOfDistractables -= 1;
        Debug.Log("Distractions left: " + AmountOfDistractables);
    }

    ///Reloading Kunais
 /*   void ReloadKunais()
    {
        AmountOfKunais = 3;
        Debug.Log("Refilled Kunais");
    }
 */

    ///Reloading Distractables
    void ReloadDistractables()
    {
        AmountOfDistractables = 3;
        Debug.Log("Refilled Distractables");
    }


    ///Crouching
    void ToggleCrouch() 
    {
        if (Crouched == true)
        {
            PlayerTransform.transform.localScale = new Vector3(.25f, .1f, .25f);
            Controller.height = ControllerHeight;
            PlayerSpeed = 2.5f;
            //CrouchAudio.Play()
            Debug.Log("Player speed is now " + PlayerSpeed + " and the player is crouched");
        }
        else 
        {
            Ray ray = new Ray();
            RaycastHit hit;
            ray.origin = transform.position;
            ray.direction = Vector3.up;
           
            if (Physics.Raycast(PlayerTransform.transform.position, ray.direction, out hit, 1.5f))
            {
                PlayerTransform.transform.localScale = new Vector3(.25f, ControllerHeight, .25f);
                Controller.height = .8f;
                PlayerSpeed = 5f;
                Debug.Log("Player is standing and the speed is " + PlayerSpeed); 
            }
            else
            {
                Debug.Log("Not enough space to stand up!");
            }
        }
    }

    ///Attacking
  /*  void ExecuteEnemy() 
    {
        //Perform Execution animation
        EnemyState enemy = new EnemyState();
        enemy.Kill();
    
    }
  */
    void Run() 
    {
        if (Running && Crouched == false)
        {
            PlayerSpeed = 8.0f;
            //RunAudio.Play();
            Debug.Log("Player is running");
            
        }
        else 
        {

            Debug.Log("Player is walking");
            PlayerSpeed = 5.0f;
            
        }
        

    }
    

   /* public void CheckForClimb() 
    {
        Vector3 origin = transform.position;
        origin.y += 1.4f;
        Vector3 direction = transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(origin, direction, out hit, 1)) 
        {
            Helper.position = PosWithOffset(origin, hit.point);
            ClimbOnWall(hit);
        }
    }

    void ClimbOnWall(RaycastHit hit) 
    {
        GroundedPlayer = false;
        Climbing = true;
        Helper.transform.rotation = Quaternion.LookRotation(-hit.normal);
        StartingPosition = transform.position;
        TargetPosition = hit.point + (hit.normal * OffsetFromWall);
        PosT = 0;
        InPosition = false;
        Anim.CrossFade("climb_idle", 2);
    }
   */
}






