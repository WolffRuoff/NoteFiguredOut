using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void Send (int note)
    {
        GameController.RecieveInput(note);
    }
}
