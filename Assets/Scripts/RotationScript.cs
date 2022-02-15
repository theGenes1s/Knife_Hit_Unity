using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
   [System.Serializable]
   private class RotationControl
    {
        public float Speed;
        public float Duration;
    }
    
    [SerializeField]                            
    private RotationControl[] rotationArray;

    private WheelJoint2D wheelJoint;
    private JointMotor2D motor;

    private void Awake()
    {
        wheelJoint = GetComponent<WheelJoint2D>();
        motor = new JointMotor2D();
        StartCoroutine("startRotationArray");
    }

    private IEnumerator startRotationArray()
    { 
        int rotationIndex = 0;
        while(true)
        {
            yield return new WaitForFixedUpdate();

            motor.motorSpeed = rotationArray[rotationIndex].Speed;
            motor.maxMotorTorque = 10000;
            wheelJoint.motor = motor;

            yield return new WaitForSecondsRealtime(rotationArray[rotationIndex].Duration);
            rotationIndex++;
            rotationIndex = rotationIndex < rotationArray.Length ? rotationIndex : 0;

        }
    }
}
   