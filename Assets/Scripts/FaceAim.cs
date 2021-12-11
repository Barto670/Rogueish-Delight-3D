using UnityEngine;

public class FaceAim : MonoBehaviour
{
    public float projectileSpeed;
    public int gunDamage;
    public float fireRate = 0.25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    LayerMask mask;
    bool invertMask;
    public bool rayDebug = true;
    public Camera cam;
    public GameObject gunEnd;
    public AmmoCount ammo = new AmmoCount();


    void Update()
    {
        //makes the raycast ignore the 8th layer which is set as target currently
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        if (rayDebug == true)
        {
            Debug.DrawRay(cam.transform.position, cam.transform.forward * weaponRange, Color.green);
        }
        if (Input.GetMouseButtonDown(0) && ammo.ammoLeft > 0)
        {
            Shoot();
        }

        void Shoot()
        {

            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity, layerMask))
            {
                Debug.Log(hit.transform);
                //finding the direction in which the projectile will be fired in
                Vector3 direction = (hit.point - gunEnd.transform.position).normalized;

                //creating projectile
                GameObject projectile = Instantiate(Resources.Load("BouncyBall")) as GameObject;
                Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

                projectile.transform.rotation = rotation;
                projectile.transform.position = gunEnd.transform.position;
                Rigidbody rb = projectile.GetComponent<Rigidbody>(); // Get the rigidbody.
                rb.velocity = direction * projectileSpeed;       
    }
            else
            {
                //when no wall is detected behind the crosshair
                Ray r = new Ray(cam.transform.position, cam.transform.forward);
                Vector3 direction = (r.GetPoint(40)  - gunEnd.transform.position).normalized;

                //creating projectile
                GameObject projectile = Instantiate(Resources.Load("BouncyBall")) as GameObject;
                Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

                projectile.transform.rotation = rotation;
                projectile.transform.position = gunEnd.transform.position;
                Rigidbody rb = projectile.GetComponent<Rigidbody>(); // Get the rigidbody.
                rb.velocity = direction * projectileSpeed;
            }
        }
    }
}
