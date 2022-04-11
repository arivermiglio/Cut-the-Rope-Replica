using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody2D hook;

    public GameObject linkPrefab;

    public int links = 7;

    void Start()
    {
        GenerateRope();
    }
    
    void GenerateRope()
    {
        // first link connects to the hook
        Rigidbody2D previousRB = hook;

        // generate links
        for (int i = 0; i < links; i++)
        {
            GameObject link = Instantiate(linkPrefab, transform);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRB;

            // next links should connect to current link
            previousRB = link.GetComponent<Rigidbody2D>();
        }
    }
}

