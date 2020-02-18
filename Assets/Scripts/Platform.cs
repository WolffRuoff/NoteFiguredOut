using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject platform;
    public AudioSource note;
    public Sprite platformSprite;
    private System.Random rand = new System.Random();



    private AudioSource randomNote()
    {
        int letter = rand.Next(7);
        int octave = rand.Next(7) + 1;

        AudioSource randNote = GetComponent<AudioSource>();

        if (letter == 0)
        {
            randNote = Notes.A(octave);
        }

        if (letter == 1)
        {
            randNote = Notes.B(octave);
        }

        if (letter == 2)
        {
            randNote = Notes.C(octave);
        }

        if (letter == 3)
        {
            randNote = Notes.D(octave);
        }

        if (letter == 4)
        {
            randNote = Notes.E(octave);
        }

        if (letter == 5)
        {
            randNote = Notes.F(octave);
        }

        if (letter == 6)
        {
            randNote = Notes.G(octave);
        }

        return randNote;
    }




    // Start is called before the first frame update
    void Start()
    {
        //Instantiate a platform that plays a note
        platform = GameObject.FindGameObjectWithTag("platform");

        randomNote().Play();

    }

    // Update is called once per frame
    void Update()
    {
        randomNote().Play(); //Every time a new platform is made
    }
}
