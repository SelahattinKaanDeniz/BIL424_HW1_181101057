using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public CharacterController charController;
    public static float timer = 0f;
    public static bool startTimer = false;
    public LayerMask yerLayer;
    float hiz;
    public Animator anim;
    public float yuruyorMu = 0;
    //public float isJumping = 0;
    public float yurumeHizi = 2.5f;
    public float yerCekimi = -9.81f;
    public float ziplamaYuksekligi = 1f;
    public Transform yerdeMiCheck; 
    public float yereMesafe = 0.05f; 
    public Vector3 lastPosition = new Vector3(0, 0, 0);
    Vector3 velocity;
    public bool yerdeMi; 
    private void Start()
    {
        

        
    }
    void FixedUpdate()
    {
        anim.SetFloat("vertic", yuruyorMu);
        //anim.SetFloat("horiz", isJumping);
        if (lastPosition != gameObject.transform.position)
        {
            anim.Play("Running");
            yuruyorMu = 1;
            anim.SetFloat("vertic", yuruyorMu);
        }
        else { 
        
            anim.Play("Idle");
            yuruyorMu = 0;
            anim.SetFloat("vertic", yuruyorMu);
        }
        lastPosition = gameObject.transform.position;
    }
    private void Update() 
    {
      

        if (transform.position.z < 0.5f)
        {
            startTimer = true;
        }
        if(transform.position.z< -8.5f)
        {
            startTimer = false;
            SceneManager.LoadScene(1);
        }
        if (startTimer)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);

        }
        yerdeMi = Physics.CheckSphere(yerdeMiCheck.position, yereMesafe, yerLayer); 
        if (yerdeMi && velocity.y < 0) {
            velocity.y = -2f; 
        }
        hiz = yurumeHizi;

        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical"); 

        Vector3 move = transform.right * x + transform.forward * z; 
        charController.Move(move * hiz * Time.deltaTime); 

        if (Input.GetButtonDown("Jump") && yerdeMi){
            //anim.Play("Jump");
            //isJumping = 1;
            //anim.SetFloat("horiz", isJumping);
            //isJumping = 0;
            velocity.y = Mathf.Sqrt(ziplamaYuksekligi * -2f * yerCekimi); 
        }

        velocity.y += yerCekimi * Time.deltaTime; 
        charController.Move(velocity * Time.deltaTime);
    }
}