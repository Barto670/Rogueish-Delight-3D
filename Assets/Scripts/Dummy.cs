using UnityEngine;
using UnityEngine.UI;

public class Dummy : MonoBehaviour
{
    public int health;
    public FaceAim bulletInfo = new FaceAim();
    public Text damage;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "bullet")
        {
            health -= bulletInfo.gunDamage;
        }
    }

    private void LateUpdate()
    {    
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
