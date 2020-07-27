using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manage : MonoBehaviour
{
    private List<Vector2> samples;

    public Vector2 zone= Vector2.one;
    public float radius = 1;
    public int k = 30;

    public float display_radius = 1;
    private void OnValidate()
    {
        samples = Poisson.GeneratePoint(radius, zone, k);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(zone / 2, zone);
        if(samples != null)
        {
            foreach(Vector2 sample in samples)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawSphere(sample, display_radius);
            }
        }
    }
}
