using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    public int maxAmmo;
    Text ammoLeftText;
    public int ammoLeft;
    public GameObject reload;

    void Start()
    {
        maxAmmo = 30;
        ammoLeftText = gameObject.GetComponent<Text>();
        ammoLeft = maxAmmo;
        ammoLeftText.text = ammoLeft + "/" + maxAmmo;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ammoLeft > 0)
            {
                reload.SetActive(false);
                GetComponent<Text>().color = Color.black;
                ammoLeft -= 1;
                ammoLeftText.text = ammoLeft + "/" + maxAmmo;
            }

        }
        if (Input.GetKey(KeyCode.R))
        {
            ammoLeft = maxAmmo;
            ammoLeftText.text = ammoLeft + "/" + maxAmmo;
            reload.SetActive(false);
            GetComponent<Text>().color = Color.black;
        }

        if (ammoLeft <= 0)
        {
            reload.SetActive(true);
            GetComponent<Text>().color = Color.red;
        }
    }
}
