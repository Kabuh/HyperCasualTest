using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControlls : MonoBehaviour
{
    float savedMousePos;
    float mousePosDelta;

    [SerializeField]
    float AnglePerPixel;

    public static ParticleSystemForceField Player;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            savedMousePos = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0) && Input.mousePosition.x != savedMousePos) {
            
            mousePosDelta = savedMousePos - Input.mousePosition.x;
            savedMousePos = Input.mousePosition.x;
            this.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, mousePosDelta * AnglePerPixel, 0));
        }
    }
}
