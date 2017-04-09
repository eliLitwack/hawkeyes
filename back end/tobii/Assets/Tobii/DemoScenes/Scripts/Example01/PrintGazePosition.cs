using UnityEngine;
using UnityEngine.UI;
using Tobii.EyeTracking;
using SocketIO;
using System.Collections.Generic;

/// <summary>
/// Writes the position of the eye gaze point into a UI Text view
/// </summary>
/// <remarks>
/// Referenced by the Data View in the Eye Tracking Data example scene.
/// </remarks>
public class PrintGazePosition : MonoBehaviour
{
    public Text xCoord;
    public Text yCoord;
    public SocketIOComponent socket;

    private void Start()
    {

        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
        //socket.On("beep", sendCoors);
        Debug.Log("asd");


    }

    void Update()
    {
        Vector2 gazePosition = EyeTracking.GetGazePoint().Screen;

        if (EyeTracking.GetGazePoint().IsValid)
        {
            Vector2 roundedSampleInput = new Vector2(Mathf.RoundToInt(gazePosition.x), Mathf.RoundToInt(gazePosition.y));
            xCoord.text = "x (in px): " + roundedSampleInput.x;
            yCoord.text = "y (in px): " + roundedSampleInput.y;

            Dictionary<string, string> data = new Dictionary<string, string>();
            data["x"] = roundedSampleInput.x.ToString();
            data["y"] = roundedSampleInput.y.ToString();

            socket.Emit("coors", new JSONObject(data));
            //Debug.Log(roundedSampleInput.x + ", " + roundedSampleInput.y);
        }
    }

    void sendCoors(SocketIOEvent ev)
    {
        Debug.Log(ev.ToString());
        //socket.Emit("connected");
    }
}
