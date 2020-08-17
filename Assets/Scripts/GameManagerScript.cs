using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject canvas;
    public GameObject player;
    public GameObject speedplayer, dragplayer, allplayer;
    public static GameManagerScript Instance;
    public float basePlayerSpeed;
    public float basePlayerDrag;
    public float otherPlayerMultiplier;
    public bool IsVelocityChange;

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ApplySpeedRate_Click()
    {
        Text myText = (Text)canvas.transform.GetChild(0).transform.GetChild(2).GetComponent(typeof(Text));
        Debug.Log(myText.gameObject.name);
        if (float.TryParse(myText.text, out float movResult))
        {
            PlayerScript.PlayerInstance.MovementSpeed = movResult;
            myText.text = "movement success";
        }

        myText = (Text)canvas.transform.GetChild(1).transform.GetChild(2).GetComponent(typeof(Text));
        if (float.TryParse(myText.text, out float rotResult))
        {
            PlayerScript.PlayerInstance.RotationSpeed = rotResult;
            myText.text = "rotation success";
        }

        canvas.SetActive(false);
    }

    public static void drawCross(Vector3 pos, Color col, float scale)
    {
        Debug.DrawRay(pos, Vector3.left * scale, col);
        Debug.DrawRay(pos, Vector3.right * scale, col);
        Debug.DrawRay(pos, Vector3.up * scale, col);
        Debug.DrawRay(pos, Vector3.down * scale, col);
        Debug.DrawRay(pos, Vector3.forward * scale, col);
        Debug.DrawRay(pos, Vector3.back * scale, col);
    }
}
