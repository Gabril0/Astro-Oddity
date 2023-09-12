using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D customCursor; // Reference to your custom cursor texture

    void Start()
    {
        // Set the custom cursor as the active cursor
        Cursor.SetCursor(customCursor, Vector2.zero, CursorMode.Auto);
    }
}