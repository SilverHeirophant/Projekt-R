using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletBehavior : MonoBehaviour
{
//Bulleto :)
    [SerializeField]
    float damage;
    [SerializeField]
    float lifetime;
    [SerializeField]
    float speed;
    [SerializeField]
    LayerMask collisionMask;
    [SerializeField]
    float width;

    Plane owner;
    new Rigidbody rigidbody;
    Vector3 lastPosition;
    float startTime;

    public void Fire(Plane owner) {
        this.owner = owner;
        rigidbody = GetComponent<Rigidbody>();
        startTime = Time.time;

        rigidbody.AddRelativeForce(new Vector3(0, 0, speed), ForceMode.VelocityChange);
        rigidbody.AddForce(owner.Rigidbody.velocity, ForceMode.VelocityChange);
        lastPosition = rigidbody.position;
    }

    void FixedUpdate() {
        if (Time.time > startTime + lifetime) {
            Destroy(gameObject);
            return;
        }

        var diff = rigidbody.position - lastPosition;
        lastPosition = rigidbody.position;

        Ray ray = new Ray(lastPosition, diff.normalized);
        RaycastHit hit;

        if (Physics.SphereCast(ray, width, out hit, diff.magnitude, collisionMask.value)) {
            Plane other = hit.collider.GetComponent<Plane>();

            if (other != null && other != owner) {
                other.ApplyDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
