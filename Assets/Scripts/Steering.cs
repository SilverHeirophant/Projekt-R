using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float dt = Time.fixedDeltaTime;

        CalculateState(dt);
        CalculateAngleOfAttack();
        CalculateGForce(dt);
    }

    void CalculateState(float dt)
    {
        var invRotation = Quaternion.Inverse(Rigidbody.rotation);
        Velocity = Rigidbody.velocity;
        LocalVelocity = invRotation * Velocity; //Transforms world velocity into local space
        LocalAngularVelocity = invRotation * Rigidbody.angularVelocity; //Transforms into local space
    }

    void CalculateAngleOfAttack()
    {
        if (LocalVelocity.sqrMagnitude < 0.1f)
        {
            AngleOfAttack = 0;
            AngleOfAttackYaw = 0;
            return;
        }
    
        AngleOfAttack = Mathf.Atan2(-LocalVelocity.y, LocalVelocity.z);
        AngleOfAttackYaw = Mathf.Atan2(LocalVelocity.x, LocalVelocity.z);
    }
    
    void CalculateGForce(float dt)
    {
        var invRotation = Quaternion.Inverse(Rigidbody.rotation);
        var acceleration = (Velocity - lastVelocity) / dt;
        LocalGForce = invRotation * acceleration;
        lastVelocity = Velocity;
    }

    float CalculateSteering(float dt, float angularVelocity, float targetVelocity, float acceleration)
    {
        var error = targetVelocity - angularVelocity;
        var accel = acceleration * dt;

        return Mathf.Clamp(error, -accel, accel);
    }
    void UpdateSteering(float dt)
    {
        var torque = Rigidbody.AddRelativeTorque(torque * Mathf.Deg2Rad);
    }


}
