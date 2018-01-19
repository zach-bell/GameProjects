using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement movement;

    void OnCollisionEnter(Collision collision) {
        
        if (collision.collider.tag == "Obstacle") {
            movement.canMove = false;
            movement.upwardForce = 435;
            movement.forwardForce = -10;

            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
