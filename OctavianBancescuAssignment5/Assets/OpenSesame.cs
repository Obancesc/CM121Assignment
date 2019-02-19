using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSesame : MonoBehaviour
{

    void dooranimation()
    {
        var exp = GetComponent<Animation>();
        exp.Play();
    }
}
