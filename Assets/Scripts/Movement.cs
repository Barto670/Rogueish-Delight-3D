using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed;
    public Rigidbody rb;
    public bool jump = false;
    public int jumpCount = 0;
    public Vector3 jumpHeight;
    public float jumpForce = 2.0f;

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void Update()
    {
        PlayerJump();
    }


    void PlayerMovement()
    {
        //player run and walk movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftControl)){
            Vector3 playerMovement = new Vector3(horizontal, 0f, vertical) * Speed/3 * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 playerMovement = new Vector3(horizontal, 0f, vertical) * Speed *Time.deltaTime *3/2;
            transform.Translate(playerMovement, Space.Self);

        }
        else
        {
            Vector3 playerMovement = new Vector3(horizontal, 0f, vertical) * Speed * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);
        }
        
    }

    void PlayerJump()
    {
        //player jump by adding force
        if ((jump == false || jumpCount < 2) && Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            jumpCount++;
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(jumpHeight * jumpForce, ForceMode.Impulse);
        }
    }


}
