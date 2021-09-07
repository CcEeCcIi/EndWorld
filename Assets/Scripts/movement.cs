using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 100f;
    Rigidbody rb;
    AudioSource audioSource;

    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Start");
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            //rb.AddRelativeForce(Vector3.up);
        }else{
            audioSource.Stop();
        }
    }
    
    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Debug.Log("Rotating Left");
            ApplyRotation(rotationThrust);

        }
        
        else if(Input.GetKey(KeyCode.D))
        {
            Debug.Log("Rotating Right");
            //transform.Rotate(0, 0, -1);
            ApplyRotation(-rotationThrust);
        }
            
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over

    }
    
}