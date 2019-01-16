using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimb : MonoBehaviour
{
    public Transform Point1;
    public Transform Point2;

    public Vector3 Gravity1;
    public Vector3 Gravity2;

    public Vector3 Rotation;

    private bool Forward;
    private bool Play;

    private Transform Player;

    private Vector3 OrigionalRotaion;

    private void Update()
    {
        if (Play)
        { 
            if (Forward && Player)
            {
                float Percent = Vector3.Distance(Player.transform.position, Point2.position) / Vector3.Distance(Point1.position, Point2.position);
                Physics.gravity = Vector3.Lerp(Gravity1, Gravity2, Percent);
                Player.transform.rotation = Quaternion.Euler(Vector3.Lerp(OrigionalRotaion + Rotation, OrigionalRotaion + -Rotation, Percent));
                //Player.transform.rotation.SetEulerRotation(Vector3.Lerp(Rotation1, Rotation2, Percent));
                
            }
            else
            {
                float Percent = Vector3.Distance(Player.transform.position, Point1.position) / Vector3.Distance(Point2.position, Point1.position);
                Physics.gravity = Vector3.Lerp(Gravity2, Gravity1, Percent);
                Player.transform.rotation = Quaternion.Euler(Vector3.Lerp(OrigionalRotaion + - Rotation, OrigionalRotaion + Rotation, Percent));
            }
        }
    }


    Vector3 GetDistance(float Percent)
    {
        if (Point1 && Point2)
        {
            float Distance = Vector3.Distance(Point1.position, Point2.position);
            Distance *= Percent;

            Vector3 Difference = Point2.position - Point1.position;

            Difference = Difference.normalized * Distance;

            return (Point1.position + Difference);
        }
        return Vector3.zero;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player = other.transform;
            OrigionalRotaion = Player.transform.rotation.eulerAngles;

            float Dist1 = Vector3.Distance(other.transform.position, Point1.position);
            float Dist2 = Vector3.Distance(other.transform.position, Point2.position);

            // Get the closer node to know what direction the player is moving along the object.
            //Transform Node = (Dist1 > Dist2) ? Point1 : Point2;

            // lerp between points
            if (Dist1 > Dist2)
            {
                Forward = true;
                Play = true;
            }
            else
            {
                Forward = false;
                Play = true;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player = null;
            Play = false;
        }
    }
}
