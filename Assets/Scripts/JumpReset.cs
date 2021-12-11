using UnityEngine;

public class JumpReset : MonoBehaviour
{
    public Movement movement;

        void OnTriggerStay()
        {
            movement.jump = false;
            Debug.Log("On the ground");
        }

        void OnTriggerExit()
        {
            movement.jump = true;
            movement.jumpCount = 1;
            Debug.Log("Left ground");
    }
}
