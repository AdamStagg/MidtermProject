using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;


public class PlayerController : MonoBehaviour
{
    ///////////Basic Player Movement///////////
    public Transform PlayerTransform;
    private CharacterController Controller;
    private Vector3 PlayerVelocity;
    private bool GroundedPlayer;
    private bool Crouched = false;
    private bool Running = false;
    public float PlayerSpeed = 1.5f;
    public static float Stamina = 10.0f;
    private float GravityValue = -9.81f;
    private float ControllerHeight = 1f;

    [Space]
    [Header("XRay Shader variables")]

    public float xrayTimeLimit = 5f;
    [HideInInspector] public static float xraytime = 5f;
    public float xRayTimeUntilRegen = 2f;
    private float timeSinceXray = 0;

    public Volume volume;
    Vignette vignette;
    ColorAdjustments colorAdj;
    FilmGrain filmGrain;

    [Space]

    ///////////Variables for Attacking///////////
    public Transform EnemyTransform;

    ///////////Variables for Kunai///////////
    public Rigidbody Kunai;
    public int AmountOfKunais = 3;

    ///////////Variables for Distractable///////////
    public GameObject Distractable;
    public static int AmountOfDistractables = 3;

    ///////////Variables for Audio///////////
    public AudioSource RunAudio;
    public AudioSource WalkAudio;


    ///////////Variables for KeyCard///////////
    public static int KeyCards = 0;





    private void Start()
    {
        Controller = GetComponent<CharacterController>();
        //keyCards = new List<KeyCard>();
        volume.profile.TryGet(out vignette);
        volume.profile.TryGet(out colorAdj);
        volume.profile.TryGet(out filmGrain);
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
        if (WalkAudio != null)
        {
            if (Controller.velocity.magnitude > 1f && WalkAudio.isPlaying == false)
            {
                WalkAudio.Play();
            }
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
        if (Input.GetButton("Run"))
        {
            Running = true;
            Run();
        }
        else if (Input.GetButtonUp("Run"))
        {
            Running = false;
            Run();
        }
        //Checks Remaining Stamina
        CheckStamina();


        //Check for XRay
        if (Input.GetButton("XRay"))
        {
            if (xraytime >= .1f)
            {
                Shader.SetGlobalFloat("_GlobalVisibility", 1f);
                Debug.Log(vignette);
                if (vignette != null)
                    vignette.intensity.value = 0.6f;
                if (colorAdj != null)
                    colorAdj.hueShift.value = -40;
                if (filmGrain != null)
                    filmGrain.intensity.value = 0.6f;
                xraytime -= Time.deltaTime;
            }
            else
            {
                Shader.SetGlobalFloat("_GlobalVisibility", 0f);
                if (vignette != null)
                    vignette.intensity.value = 0f;
                if (colorAdj != null)
                    colorAdj.hueShift.value = 0;
                if (filmGrain != null)
                    filmGrain.intensity.value = 0f;
            }
            timeSinceXray = Time.time + xRayTimeUntilRegen;
        }
        else
        {
            Shader.SetGlobalFloat("_GlobalVisibility", 0f);
            if (vignette != null)
                vignette.intensity.value = 0f;
            if (colorAdj != null)
                colorAdj.hueShift.value = 0;
            if (filmGrain != null)
                filmGrain.intensity.value = 0f;

            if (timeSinceXray <= Time.time)
            {
                xraytime += Time.deltaTime;

            }
        }

        //Shader.SetGlobalFloat("_GlobalVisibility", xraytime / xrayTimeLimit);
        xraytime = Mathf.Clamp(xraytime, 0, xrayTimeLimit);
        //Debug.Log(xraytime);




        ///////////Player Crouch///////////
        if (Input.GetButtonDown("Crouch"))
        {
            Crouched = !Crouched;
            ToggleCrouch();
            //Play Crouch Animation
            //Reduce Enemy Sight Lines
        }


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


        ///////////Reloads Distractables///////////
        ///Will Change after reload stations are included
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadDistractables();
        }


        ///////////Checking the amount of keycards the player has///////////
        if (Input.GetKeyDown(KeyCode.F))
        {
            CheckKeyCards();
        }

        PlayerVelocity.y += GravityValue * Time.deltaTime;
        Controller.Move(PlayerVelocity * Time.deltaTime);

    }


    ///////////Player Actions///////////


    ///Distractions
    void CreateDistractable()
    {
        Instantiate(Distractable, transform.position, transform.rotation);
        AmountOfDistractables -= 1;
        Debug.Log("Distractions left: " + AmountOfDistractables);
    }



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
            PlayerTransform.transform.localScale = new Vector3(1f, .5f, 1f);
            Controller.height = ControllerHeight;
            PlayerSpeed = 1f;
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
                PlayerTransform.transform.localScale = new Vector3(1f, ControllerHeight, 1f);
                Controller.height = .8f;
                PlayerSpeed = 1.5f;
                Debug.Log("Player is standing and the speed is " + PlayerSpeed);
            }
            else
            {
                Debug.Log("Not enough space to stand up!");
            }
        }
    }


    void Run()
    {
        if (Running && Crouched == false && Stamina > 0.1f && Controller.velocity.magnitude > 1f)
        {
            PlayerSpeed = 3f;
            if (RunAudio != null)
            {
                if (!RunAudio.isPlaying)
                {
                    //RunAudio.Play();
                    //WalkAudio.Stop();
                }
                //Debug.Log("Player is running");
            }

        }
        else if (Crouched == false || Controller.velocity.magnitude < 1f || Running == false)
        {
            //Debug.Log("Player is walking");
            Running = false;
            if (WalkAudio != null)
            {
                if (!WalkAudio.isPlaying)
                {
                    //RunAudio.Stop();
                    //WalkAudio.Play();
                }
            }
            PlayerSpeed = 1.5f;

        }


    }

    void CheckStamina()
    {
        if (Stamina > 0.1f && Running == true)
        {

            Stamina -= Time.deltaTime;
            // Debug.Log("Stamina left: " + Stamina);
        }
        else if (Stamina <= 10.0f)
        {
            Running = false;
            PlayerSpeed = 1.5f;
            //Debug.Log("Player is now walking");
            Stamina += Time.deltaTime;
            if (Stamina > 10.0f)
            {
                Stamina = 10.0f;
            }
            if (WalkAudio != null)
            {
                if (!WalkAudio.isPlaying && RunAudio.isPlaying)
                {
                    WalkAudio.Play();
                    RunAudio.Stop();
                }
            }
        }

    }

    void CheckKeyCards()
    {
        Debug.Log("Keycards = " + KeyCards);
    }
}
   

   /* public void CheckForClimb() 
    {

        //We are within the range of the enemy and running
        if (other.transform.parent != null && other.transform.parent.tag == "Enemy" && Running)
        {
            Vector3 Move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //player is moving
            if (Move.magnitude > .1f)
            {
                other.transform.parent.GetComponent<EnemyPathFind>().SetInvestigatePosition(transform);
                other.transform.parent.GetComponent<EnemyState>().InvokeInvestigate();
            }
        }
    }
}*/





