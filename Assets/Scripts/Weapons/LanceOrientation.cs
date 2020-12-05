using UnityEngine;

public class LanceOrientation : MonoBehaviour
{
    float offset = 0.1f;
    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Orientation();
    }

    private void Orientation()
    {
        Vector2 cursorPosition = CursorPosition.Position();

        float angle = Vector2.Angle(new Vector2(1, 0), cursorPosition);
        if (cursorPosition.y < 0)
        {
            angle = -angle;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


        if(player.GetComponent<CharacterAnimation>().Animation().Equals("Walk Left"))
        {
            transform.position = new Vector2(player.position.x - offset, transform.position.y);
        }
        else if (player.GetComponent<CharacterAnimation>().Animation().Equals("Walk Right"))
        {
            transform.position = new Vector2(player.position.x + offset, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(player.position.x, transform.position.y);
        }
    }
}
