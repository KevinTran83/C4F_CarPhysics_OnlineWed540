using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public float acceleration, turnAngle, brakeForce;
    public WheelCollider wheel_frontRight, wheel_rearRight,
                         wheel_frontLeft,  wheel_rearLeft;
    public Transform     wheel_frontRight_mesh, wheel_rearRight_mesh,
                         wheel_frontLeft_mesh, wheel_rearLeft_mesh;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called multiple times per frame
    void FixedUpdate()
    {
        // Accelerate
        wheel_frontRight.motorTorque = Input.GetAxis("Vertical") * acceleration * rb.mass;
        wheel_frontLeft .motorTorque = Input.GetAxis("Vertical") * acceleration * rb.mass;

        // Turning
        wheel_frontRight.steerAngle = Input.GetAxis("Horizontal") * turnAngle;
        wheel_frontLeft .steerAngle = Input.GetAxis("Horizontal") * turnAngle;

        // Brake
        float brake = Input.GetAxis("Jump") != 0 ? brakeForce * rb.mass : 0;
        wheel_frontRight.brakeTorque = brake;
        wheel_frontLeft .brakeTorque = brake;
        wheel_rearRight .brakeTorque = brake;
        wheel_rearLeft  .brakeTorque = brake;

        RotateWheel(wheel_frontRight, wheel_frontRight_mesh);
        RotateWheel(wheel_frontLeft , wheel_frontLeft_mesh );
        RotateWheel(wheel_rearRight , wheel_rearRight_mesh );
        RotateWheel(wheel_rearLeft  , wheel_rearLeft_mesh  );
    }

    void RotateWheel(WheelCollider w, Transform m)
    {
        Vector3 newPos;
        Quaternion newRot;
        w.GetWorldPose(out newPos, out newRot);

        m.rotation = newRot;
        //m.transform.Rotate(0, 0, 90);
    }
}
