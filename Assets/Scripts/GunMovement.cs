using UnityEngine;

public class GunMovement : MonoBehaviour
{
    public Transform crosshairY;
    public Quaternion Qoffset;
    public void LateUpdate()
    {
        if (!Input.GetKey(KeyCode.LeftAlt))
        {
            transform.rotation = crosshairY.rotation * Qoffset;
        }
    }
}

