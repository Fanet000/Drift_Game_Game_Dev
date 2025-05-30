using UnityEngine;

public class DriveController : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed = 15.0f;

    private void Update()
    {
        
        //read from value
        Vector3 velocity = transform.position;
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        float turnAngle = transform.localEulerAngles.y;

        //print command
        //Debug.Log(vertical);

        if (vertical != 0)
        {
            //modifie holding contaner
            velocity = vertical * transform.forward * moveSpeed;
            turnAngle += horizontal * turnSpeed * Time.deltaTime;

            //write the value back
            transform.position += velocity * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0 , turnAngle , 0);
        }

        else
        {
            //turnAngle = 0;
            //drag
            velocity *= 0.98f;
        }

            //MaxSpeed Limite
            velocity = Vector3.ClampMagnitude(velocity, 10.0f);

    }
    
}
