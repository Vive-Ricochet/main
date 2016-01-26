using UnityEngine;
using System.Collections;

public class PlayerDash : MonoBehaviour
{

    [SerializeField]
    private int dashDuration = 30;

    private int dashRecovery = 0;
    private Vector3 dashDir;
    private bool dashing;

    private float speed;
    private float rotationSpeed;

    // Use this for initialization
    void Start()
    {
        PlayerMovement PM = GetComponent<PlayerMovement>();
        dashing = PM.dashing;
        speed = PM.getSpeed();
        rotationSpeed = PM.getRotationSpeed();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        //camera setting 
        Vector3 camDir = Camera.main.transform.forward;
        camDir.y = 0;
        camDir.Normalize();

        Vector3 newVel = Vector3.zero;
        if (dashing == false)
        {
            if (Input.GetButton("Dash"))
            {
                newVel = Vector3.zero;
                dashDir = camDir;
                dashing = true;

            }
        }
        if (dashing == true)
        {
            //transform.position = (newVel);
            dashRecovery++;
            newVel += dashDir * (speed * 2f);
            
            //transform.position += (newVel * Time.fixedDeltaTime);
            transform.position += (newVel * Time.fixedDeltaTime);
            
            //transform camera
            if (newVel != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    Quaternion.LookRotation(newVel),
                    Time.deltaTime * rotationSpeed
                    );
            }
            
            //check if dash is over
            if (dashRecovery >= dashDuration)
            {
                GetComponent<PlayerMovement>().setDashing(false);
                dashing = false;
                dashRecovery = 0;
            }
        }
    }
}
