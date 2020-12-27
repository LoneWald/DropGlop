using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Move_Platform : MonoBehaviour
{
    public float X = 1;
    public float Y = 0;
    public float Z = 0;
    public int speed = 5;
    public float delay = 0;
    private double range = 0;
    private double delay_time_up = 0, delay_time_down = 0;
    private int Max = 0;
    void Start()
    {
        range = Math.Sqrt(X * X + Y * Y + Z * Z);
        delay_time_up = 0;
        delay_time_down = Math.Abs(speed)- Time.deltaTime;
        Max = 0;
    }
    void FixedUpdate()
    {
        if (delay_time_up < delay)
            delay_time_up += Time.deltaTime;
        else
        {
            delay_time_down -= Time.deltaTime;
            transform.Translate(new Vector3(X / speed * Time.deltaTime, Y / speed * Time.deltaTime, Z / speed * Time.deltaTime));
            Max++;
            
            if (Max >=Math.Abs(speed)*50)
            {
                speed = -speed;
                Max = 0;
            }
            if (delay_time_down <= 0)
            {
                delay_time_up = 0;
                delay_time_down = Math.Abs(speed) - Time.deltaTime;
            }
            
        }
    }
}
