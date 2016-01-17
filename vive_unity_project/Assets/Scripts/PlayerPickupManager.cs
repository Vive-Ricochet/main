using UnityEngine;
using System.Collections;

public class PlayerPickupManager : MonoBehaviour {

    // check on collision with another collider
    /*** must be trigger enabled ***/
    void OnTriggerEnter(Collider other) {
        
        // if other object is a "Pickup":
        if (other.gameObject.CompareTag("Pickup")) {

            GameObject otherObject = other.gameObject;
            
            // append item to a node
            AppendItem(otherObject, "NodeHead");

            // obtain pickup's properties
            PickupProperties pickupProperties = otherObject.GetComponent<PickupProperties>();
            if(pickupProperties != null)
                pickupProperties.PrintProperties(); // print'em

        }

    }

    void AppendItem(GameObject otherObject, string nodeToAppendTo) {

        // disable pickup's rigid body to give it that ephemeral feel
        // also make it kinematic to disable effective forces
        otherObject.GetComponent<Rigidbody>().detectCollisions = false;
        otherObject.GetComponent<Rigidbody>().isKinematic = true;

        // append object to player node
        otherObject.transform.parent = this.transform.FindChild(nodeToAppendTo);
        otherObject.transform.position = this.transform.FindChild(nodeToAppendTo).position;

    }

}