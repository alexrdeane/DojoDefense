using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Character Set Up 
//Character Movement
//This script requires the component Character controller
namespace ninja
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour
    {
        #region Variables
        //vector3 called moveDirection
        public Vector3 moveDirection;

        private CharacterController _characterController;
        [Header("Character Variables:")]
        //public float variables jumpSpeed, speed, gravity
        public float jumpSpeed = 100;
        public float speed;
        public float baseSpeed = 25f;
        public float runSpeed = 50f;
        public float gravity = 200;

        public int jump = 0;

        private float dashMax = 1.5f;
        private float dashTimer;

        float mass = 1.0f; // defines the character mass
        Vector3 impact = Vector3.zero;
        #endregion
        #region Start
        void Start()
        {
            speed = baseSpeed;
            Cursor.visible = false;
            //charc is on this game object we need to get the character controller that is attached to it
            _characterController = this.GetComponent<CharacterController>();
            dashTimer = 0f;
        }
        #endregion
        #region Update
        void Update()
        {
            #region Player's movement
            if (jump == 1 && Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
                jump += 1;
            }

            //if our character is grounded
            //we are able to move in game scene meaning
            if (_characterController.isGrounded)
            {
                jump = 0;
                //Input Manager(https://docs.unity3d.com/Manual/class-InputManager.html)
                //Input(https://docs.unity3d.com/ScriptReference/Input.html)
                //moveDir is equal to a new vector3 that is affected by Input.Get Axis.. Horizontal, 0, Vertical
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                //moveDir is transformed in the direction of our moveDir
                moveDirection = transform.TransformDirection(moveDirection);
                //our moveDir is then multiplied by our speed
                moveDirection *= speed;
                //we can also jump if we are grounded so
                //in the input button for jump is pressed then
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (jump <= 0)
                    {
                        moveDirection.y = jumpSpeed;
                        jump += 1;
                    }
                }
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    speed = runSpeed;
                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    speed = baseSpeed;
                }
            }

            if (Input.GetKey(KeyCode.F))
            {
                dashTimer += Time.deltaTime;
                dashTimer = Mathf.Clamp(dashTimer, 0f, dashMax);
                if (dashTimer >= dashMax)
                {

                }
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                AddImpact(Camera.main.transform.forward, 200 * dashTimer);
                dashTimer = 0f;
            }
            //regardless of if we are grounded or not the players moveDir.y is always affected by gravity timesed by time.deltaTime to normalize it
            moveDirection.y -= gravity * Time.deltaTime;
            //we then tell the character Controller that it is moving in a direction timesed Time.deltaTime
            _characterController.Move(moveDirection * Time.deltaTime);

            // apply the impact force:
            if (impact.magnitude > 0.2) _characterController.Move(impact * Time.deltaTime);
            // consumes the impact energy each cycle:
            impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);


            #endregion
        }
        #endregion
        #region AddImpact
        void AddImpact(Vector3 dir, float force)
        {
            dir.Normalize();
            if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
            impact += Camera.main.transform.forward * force / mass;
        }
        #endregion
    }
}

