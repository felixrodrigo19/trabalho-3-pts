using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{
    //public Texture2D CursorTexture;
    public UnityEngine.UI.Image CursorImage;

    public Texture2D DefaultCursorTexture;
    public Texture2D CurrentCursorTexture;
    public Color CursorColor = Color.white;

    bool IsMoving;

    public void ResetCursor()
    {
        CursorColor = Color.white;
        CurrentCursorTexture = DefaultCursorTexture;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.SetCursor(CursorTexture, Vector2.zero, CursorMode.Auto);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

        ResetCursor();
    }

    private void OnGUI()
    {
        if (!IsMoving)
        {
            GUI.color = CursorColor;
            GUI.DrawTexture(
                new Rect(
                    Input.mousePosition.x,
                    Screen.height - Input.mousePosition.y,
                    32f,
                    32f
                ),
                CurrentCursorTexture
            );
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetMouseButton(0))
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        Cursor.visible = false;

        IsMoving = Input.GetButton("Horizontal") ||
                Input.GetAxis("Vertical") != 0||
                Input.GetButton("Turn");

        //CursorImage.rectTransform.position = new Vector3(
        //    Input.mousePosition.x + 12f,
        //    Input.mousePosition.y - 12f
        //);
    }

    //private void LateUpdate()
    //{

    //    Cursor.lockState = CursorLockMode.Locked;
    //    Cursor.visible = false;
    //}
}
