using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh congratsText;
    public ParticleSystem sparksParticles;

    private List<string> textToDisplay = new List<string>();

    private float rotatingSpeed = 180f;
    private float timeToNextText;

    private int currentText;

    // Start is called before the first frame update
    void Start()
    {
        timeToNextText = 0.0f;
        currentText = 0;

        textToDisplay.Add("Congratulations");
        textToDisplay.Add("All Errors Fixed");

        congratsText.text = textToDisplay[0];

        sparksParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotatingSpeed * Time.deltaTime);
        timeToNextText += Time.deltaTime;


        if (timeToNextText > 1.5f)
        {
            currentText++;

            if (currentText >= textToDisplay.Count)
            {
                currentText = 0;
            }
            congratsText.text = textToDisplay[currentText];

            timeToNextText = 0.0f;
        }


    }
}