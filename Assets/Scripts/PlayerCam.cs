using Paridot;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    /*
     * CURRENTLY does nothing
     * in the future it will hold the variables to manipulate the camera sensitivity and other camera related functions
     */
    [SerializeField]
    private InputReader input;

    [SerializeField]
    private float sensitivityX;

    [SerializeField]
    private float sensitivityY;

    private Vector2 lookDirection;
}
