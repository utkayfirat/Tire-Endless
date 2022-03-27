using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;
    


//0 ise SOL
//1 ise ORTA
//2 ise SAĞ
    private int desiredLane = 1;

    public float laneDistance = 4;

    public float jumpForce;
    public float Gravity = -20;

    public Animator animator;
   
    private bool isSliding = false;
    private bool isScoreCounterOnline = false;


    void Start()
    {
        controller = GetComponent<CharacterController>();

        

        Gravity = -20;
        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;
        animator.SetBool("isSliding", false);
        isSliding = false;

    }


    void Update()
    {

        

        if (!PlayerManager.isGameStarted)
            return;

        if (PlayerManager.isGameStarted)
            StartCoroutine(CoUpdate());

        
            
        



        controller.Move(direction * Time.deltaTime);
        

        if (forwardSpeed < maxSpeed)
        {
            forwardSpeed += 0.1f * Time.deltaTime;

        }


            

        animator.SetBool("isGameStarted", true);
        

        direction.z = forwardSpeed;


        animator.SetBool("isGrounded", controller.isGrounded);
        //Kontrol ayarları
        if (controller.isGrounded)
        {
            
            if (SwipeManager.swipeUp)
            {
                Jump();
            }
        }
        else
        {

            direction.y += Gravity * Time.deltaTime;
        }



        if (SwipeManager.swipeDown && !isSliding)
        {
           
            StartCoroutine(Slide());
        }


        if (SwipeManager.swipeRight)
        {
            
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }


        if (SwipeManager.swipeLeft)
        {
           
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        //Player nerede?
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }else if(desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        //transform.position = targetPosition;

        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 13 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.sqrMagnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);
        }
        

    }


    private void Jump()
    {
        
        if (Gravity == -47)
            Gravity = -20;

        direction.y = jumpForce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
        }
    }

    private IEnumerator Slide()
    {
        isSliding = true;
        Gravity = -47;
        animator.SetBool("isSliding", true);
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 0.5f;
        

        yield return new WaitForSeconds(1f);

        Gravity = -20;
        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;
        animator.SetBool("isSliding", false);
        isSliding = false;
    }

    IEnumerator CoUpdate()
    {
        if(isScoreCounterOnline == false)
        {
            isScoreCounterOnline = true;
            if(isScoreCounterOnline == true)
            {
                yield return new WaitForSeconds(1);
                PlayerManager.scoreNumber += 6;
                isScoreCounterOnline = false;
            }
        }
    }



}
