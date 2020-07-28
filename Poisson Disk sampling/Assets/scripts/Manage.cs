using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manage : MonoBehaviour
{
    private List<Vector2> samples;
    
    public List<GameObject> trees;

    public Vector2 zone= Vector2.one;
    public float radius = 1;
    public int k = 30;

    public float display_radius ;


    private void Start()
    {
        samples = Poisson.GeneratePoint(radius, zone, k);
        if(samples != null)
        {
            foreach(Vector2 sample in samples)
            {
                
                int index = Random.Range(0, trees.Count);
                GameObject tree = Instantiate(trees[index], new Vector3(sample.x, 0, sample.y)+transform.position, Quaternion.identity)as GameObject;
                tree.transform.Rotate(0, Random.Range(0, 360), 0);
                tree.transform.localScale = Vector3.one * display_radius;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube((new Vector3(zone.x, 0, zone.y) / 2)+transform.position, new Vector3(zone.x, 0, zone.y));
        
    }

}
