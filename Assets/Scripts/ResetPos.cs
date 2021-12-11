
using UnityEngine;

public class ResetPos : MonoBehaviour
{
    public Movement movement;
    public Vector3 resPos;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.transform.position = resPos;
        }

        if (collision.collider.tag != "Player")
        {
            Vector3 ResVector = new Vector3(Random.Range(-10.0f, 10.0f), 1.0f, Random.Range(-10.0f, 10.0f));
            collision.collider.transform.position = ResVector;
        }
    }
}