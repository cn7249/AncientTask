using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorBehavior : MonoBehaviour
{
    private float _rotationAmount;

    private void Awake()
    {
        _rotationAmount = 0.03f;
    }

    private void Update()
    {
        KeepRotate();
    }

    private void KeepRotate() 
    {
        if (transform.eulerAngles.y < 100)
        {
            _rotationAmount *= -1;
        }
        else if (transform.eulerAngles.y > 140)
        {
            _rotationAmount *= -1;
        }
        transform.eulerAngles += new Vector3(0, _rotationAmount, 0);
    }
}
