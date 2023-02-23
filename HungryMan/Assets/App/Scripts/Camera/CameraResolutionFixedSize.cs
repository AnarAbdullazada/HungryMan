using UnityEngine;

namespace SOG.CameraScript 
{
  public class CameraResolutionFixedSize : MonoBehaviour
  {
    [SerializeField] private bool adjustWithWidth;

    private float width;
    private float height;

    Vector3 cameraPos;

    // Start is called before the first frame update
    void Start()
    {
      cameraPos = Camera.main.transform.position;
      height = Camera.main.orthographicSize; 
      width = Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
      if (adjustWithWidth)
      {
        Camera.main.orthographicSize = width / Camera.main.aspect;
        Camera.main.transform.position = new Vector3(cameraPos.x, -1*(height - Camera.main.orthographicSize), cameraPos.z);
      }
    }
  }
}

