using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    public Button c;
    public Button d;
    public Button e;
    public Button f;
    public Button g;
    public Button a;
    public Button b;

    void Update()
    {
        // get input from keyboard and highlight that button on the screen
        if (Input.GetKeyDown(KeyCode.C))
        {
            Send(0);
            c.Select();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Send(1);
            d.Select();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Send(2);
            e.Select();
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            Send(3);
            f.Select();
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            Send(4);
            g.Select();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Send(5);
            a.Select();
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            Send(6);
            b.Select();
        }
    }

    // function that is assigned to clicking the buttons on the UI during gameplay
    public void Send (int note)
    {
        GameController.RecieveInput(note);
    }
}
