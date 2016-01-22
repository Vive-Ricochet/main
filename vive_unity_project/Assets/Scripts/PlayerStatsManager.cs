using UnityEngine;
using System.Collections;

public class PlayerStatsManager : MonoBehaviour {

    // public fields
    public string leftArmPosition;
    public string rightArmPosition;

	// private fields
    private float health;
    private float stamina;

    // buttons
    private KeyCode toggleArmTriggerL = KeyCode.Q;
    private KeyCode toggleArmTriggerR = KeyCode.E;
    private KeyCode moveLeftArmN  = KeyCode.Alpha4;
    private KeyCode moveLeftArmE  = KeyCode.Alpha5;
    private KeyCode moveLeftArmS  = KeyCode.Alpha2;
    private KeyCode moveLeftArmW  = KeyCode.Alpha1;
    private KeyCode moveRightArmN = KeyCode.Slash;
    private KeyCode moveRightArmE = KeyCode.Asterisk;
    private KeyCode moveRightArmS = KeyCode.Alpha9;
    private KeyCode moveRightArmW = KeyCode.Alpha8;

    // node game objects
    Transform leftArmNode;
    Transform rightArmNode;

    void Start() {

        leftArmPosition  = "North Up";
        rightArmPosition = "North Up";

        leftArmNode  = transform.FindChild("Left Arm Node");
        rightArmNode = transform.FindChild("Right Arm Node");

    }

    void Update() {

        if(Input.anyKeyDown) {

            // toggle players arm "Up" or "Down" on toggle button press
            if (Input.GetKeyDown(toggleArmTriggerL))
               TogglePlayerLeftArm();
            if (Input.GetKeyDown(toggleArmTriggerR))
             TogglePlayerRightArm();

            // check for moving arms to positions
            if (Input.GetKeyDown(moveLeftArmN))
                moveLeftArmN();
            if (Input.GetKeyDown(moveLeftArmE))
                moveLeftArmE();
            if (Input.GetKeyDown(moveLeftArmS))
                moveLeftArmS();
            if (Input.GetKeyDown(moveLeftArmS))
                moveLeftArmS();

            if (Input.GetKeyDown(moveRightArmN))
                moveLeftRightN();
            if (Input.GetKeyDown(moveRightArmE))
                moveLeftRightE();
            if (Input.GetKeyDown(moveRightArmS))
                moveLeftRightS();
            if (Input.GetKeyDown(moveRightArmW))
                moveLeftRightW();
        }

    }

    // how to move a player's arms
    void TogglePlayerLeftArm() {
                
        float old_x = leftArmNode.position.x;
        float old_y = leftArmNode.position.y;
        float old_z = leftArmNode.position.z;

        // first, update the player state
        if (leftArmPosition.Contains("Up")) {
            leftArmPosition = leftArmPosition.Replace("Up", "Down");
            leftArmNode.position = new Vector3(old_x, old_y - 1.4f, old_z);
        } else {
            leftArmPosition = leftArmPosition.Replace("Down", "Up");
            leftArmNode.position = new Vector3(old_x, old_y + 1.4f, old_z);

        }

    }

    void TogglePlayerRightArm() {

        float old_x = rightArmNode.position.x;
        float old_y = rightArmNode.position.y;
        float old_z = rightArmNode.position.z;

        // first, update the player state
        if (rightArmPosition.Contains("Up")) {
            rightArmPosition = rightArmPosition.Replace("Up", "Down");
            rightArmNode.position = new Vector3(old_x, old_y - 1.4f, old_z);
        } else {
            rightArmPosition = rightArmPosition.Replace("Down", "Up");
            rightArmNode.position = new Vector3(old_x, old_y + 1.4f, old_z);

        }
    }
}
