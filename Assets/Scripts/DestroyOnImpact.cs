using UnityEngine;

public class DestroyOnImpact : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);
        if (collision.collider.tag != "Player" )
        {
            Destroy(gameObject);
        }
    }
}
