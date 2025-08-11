using UnityEngine;

public class LanternaMouse : MonoBehaviour

{

    public Camera cam;

    void Update()

    {

        Vector3 posMouse = cam.ScreenToWorldPoint(Input.mousePosition);

        posMouse.z = 0f;

        transform.position = posMouse;

    }

}

