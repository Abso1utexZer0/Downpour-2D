using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public Transform holdPoint;
    private GameObject heldItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (heldItem == null && collision.CompareTag("Item"))
        {
            PickUp(collision.gameObject);
            Debug.Log("Picked up weapon");
        }
    }

    void PickUp(GameObject weapon)
    {
        heldItem = weapon;

        if (heldItem.TryGetComponent(out Rigidbody2D _RigidBody2D))
        {
            _RigidBody2D.simulated = false;
        }

        if (heldItem.TryGetComponent(out Collider2D col))
        {
            col.enabled = false;
        }

        heldItem.transform.SetParent(holdPoint);
        heldItem.transform.localPosition = Vector3.zero;
    }
}
