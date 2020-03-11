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

    private static bool active = true;

    void Start()
    {
        setActive(true);
    }

    void Update()
    {
        // get input from keyboard and highlight that button on the screen
        if (Input.GetKeyDown(KeyCode.C) && active)
        {
            Send(0);
            c.Select();
        }
        else if (Input.GetKeyDown(KeyCode.D) && active)
        {
            Send(1);
            d.Select();
        }
        else if (Input.GetKeyDown(KeyCode.E) && active)
        {
            Send(2);
            e.Select();
        }
        else if (Input.GetKeyDown(KeyCode.F) && active)
        {
            Send(3);
            f.Select();
        }
        else if (Input.GetKeyDown(KeyCode.G) && active)
        {
            Send(4);
            g.Select();
        }
        else if (Input.GetKeyDown(KeyCode.A) && active)
        {
            Send(5);
            a.Select();
        }
        else if (Input.GetKeyDown(KeyCode.B) && active)
        {
            Send(6);
            b.Select();
        }

        if (!active)
        {
            c.enabled = false;
            d.enabled = false;
            e.enabled = false;
            f.enabled = false;
            g.enabled = false;
            a.enabled = false;
            b.enabled = false;
        }
    }

    // function that is assigned to clicking the buttons on the UI during gameplay
    public void Send (int note)
    {
        if (note == 0)
        {
            GameController.RecieveInput('c');
        }
        else if (note == 1)
        {
            GameController.RecieveInput('d');
        }
        else if (note == 2)
        {
            GameController.RecieveInput('e');
        }
        else if (note == 3)
        {
            GameController.RecieveInput('f');
        }
        else if (note == 4)
        {
            GameController.RecieveInput('g');
        }
        else if (note == 5)
        {
            GameController.RecieveInput('a');
        }
        else if (note == 6)
        {
            GameController.RecieveInput('b');
        }
    }

    public static void setActive(bool tf)
    {
        active = tf;
    }
}
