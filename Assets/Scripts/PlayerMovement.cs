using UnityEngine;

[RequireComponent(typeof(CharacterAnimation))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    float xInput, yInput;
    new Rigidbody2D rigidbody;
    CharacterAnimation playerAnimation;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<CharacterAnimation>();
    }

    void FixedUpdate()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        Vector2 moveVector = new Vector2(xInput, yInput);

        // Update Position
        rigidbody.MovePosition(rigidbody.position + moveVector * speed * Time.deltaTime);

        // Update Animation
        playerAnimation.Move(moveVector);
    }
}
