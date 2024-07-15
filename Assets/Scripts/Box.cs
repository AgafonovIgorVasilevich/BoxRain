using UnityEngine;

[RequireComponent (typeof(Renderer))]

public class Box : MonoBehaviour
{
    private Destroyer _destroyer;
    private bool _isContact;

    public void Initialize(Destroyer destroyer)
    {
        GetComponent<Renderer>().material.color = Color.white;
        _destroyer = destroyer;
        _isContact = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isContact)
            return;

        if(collision.transform.GetComponent<Platform>())
        {
            GetComponent<Renderer>().material.color = Random.ColorHSV();
            _destroyer.Destroy(this);
            _isContact = true;
        }
    }
}