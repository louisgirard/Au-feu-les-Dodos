using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

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
        xInput = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        yInput = CrossPlatformInputManager.GetAxisRaw("Vertical");
        Vector2 moveVector = new Vector2(xInput, yInput).normalized;

        // Update Position
        rigidbody.MovePosition(rigidbody.position + moveVector * speed * Time.deltaTime);

        // Update Animation
        playerAnimation.Move(moveVector);
    }

    public void OnDisable()
    {
        if(gameObject.activeSelf)
            playerAnimation.Move(Vector2.zero);
    }
}
