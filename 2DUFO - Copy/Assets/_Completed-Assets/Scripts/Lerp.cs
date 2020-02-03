using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{

    public Vector2 Location1;
    public Vector2 Location2;
    public int speed = 1;

    private float startTime;
    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {
        Location1 = this.gameObject.transform.position;
        startTime = Time.time;
        journeyLength = Vector2.Distance(Location1, Location2);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("time " + startTime);
        // Distance moved = time * speed.
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed = current distance divided by total distance.
        float fracJourney = distCovered / journeyLength;

        transform.position = Vector2.Lerp(Location1, Location2, Mathf.PingPong(fracJourney, 1));
    }
}
