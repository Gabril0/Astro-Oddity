using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 10;
    //[SerializeField] bool isInfinite = false;
    [SerializeField] ScrollDirectionEnum scrollDirection = ScrollDirectionEnum.Left; //the right is just to assign an default value


    private void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        Vector2 directionVector = Vector2.zero;

        switch (scrollDirection)
        {
            case ScrollDirectionEnum.Up:
                directionVector = Vector2.up;
                break;
            case ScrollDirectionEnum.Right:
                directionVector = Vector2.right;
                break;
            case ScrollDirectionEnum.Left:
                directionVector = Vector2.left;
                break;
            case ScrollDirectionEnum.Down:
                directionVector = Vector2.down;
                break;
        }

        //if (isInfinite)
        //{
        //    WrapBackground();
        //}
        transform.Translate(directionVector * scrollSpeed * Time.deltaTime);
    }

    private void WrapBackground()
    {
        Vector3 position = transform.position;
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(position);

        if (viewportPosition.x > 1 || viewportPosition.x < 0 || viewportPosition.y > 1 || viewportPosition.y < 0)
        {
            Vector3 newPosition = position;

            if (scrollDirection == ScrollDirectionEnum.Up)
                newPosition.y = -newPosition.y;

            if (scrollDirection == ScrollDirectionEnum.Right)
                newPosition.x = -newPosition.x;

            transform.position = newPosition;
        }
    }
    public void setDirection(ScrollDirectionEnum scrollDirection) {
        this.scrollDirection = scrollDirection;
    }
}

public enum ScrollDirectionEnum
{
    Up,
    Right,
    Left,
    Down
}
