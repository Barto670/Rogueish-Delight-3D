using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public float RotationSpeed = 1;
    public Transform Target, Player, Face;
    float mouseX, mouseY;

    public Transform Obstruction;
    float zoomSpeed = 0.5f;
    public bool FPSMode;
    public GameObject crosshair;

    [Range(70,90)]
    public int defaultFOV;


    void Start()
    {
        Obstruction = Target;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        CamControl();
        ViewObstructed();

    }

    //rotation of the camera
    void CamControl()
    {
        //input from mouse to mouseX and mouseY
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY += Input.GetAxis("Mouse Y") * -RotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -75, 50);

        if (FPSMode == false)
        {
            transform.LookAt(Target);
        }
        else
        {
            transform.position = Face.position;
        }

        //FOV change
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, defaultFOV + 2, Time.deltaTime*15);
        }
        else if(Input.GetKey(KeyCode.LeftControl))
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, defaultFOV-2, Time.deltaTime * 15);
        }
        else
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, defaultFOV, Time.deltaTime * 15);
        }

        //alt free look / normal camera
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            crosshair.SetActive(false);
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            crosshair.SetActive(true);
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }

        //E and Q setup to move camera left and right
        if (Input.GetKey(KeyCode.E))
        {
            mouseX += 2;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            mouseX += -2;
        }
    }

    //Raycast + hit collider allowing the player to see through walls and objects
    void ViewObstructed()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Target.position - transform.position, out hit, 4.5f))
        {
            if (hit.collider.gameObject.tag != "Player")
            {
                Obstruction = hit.transform;
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

                if (Vector3.Distance(Obstruction.position, transform.position) >= 3f && Vector3.Distance(transform.position, Target.position) >= 1.5f)
                {
                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
                }
            }
            else
            {
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                if (Vector3.Distance(transform.position, Target.position) < 4.5f)
                {
                    transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
                }
            }
        }
    }


}