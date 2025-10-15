using UnityEngine;

public class rotator : MonoBehaviour
{

    public float rotSpeedx = 25f;
    public float rotSpeedy = 45f;
    public float rotSpeedz = 60f;
   

    // Update is called once per frame
    void Update()
    {
        RotateObject();
    }

    void RotateObject()
    {
        transform.Rotate(Vector3.right * rotSpeedx * Time.deltaTime);
        transform.Rotate(Vector3.up * rotSpeedy * Time.deltaTime);
        transform.Rotate(Vector3.forward * rotSpeedz * Time.deltaTime);
    }


}




