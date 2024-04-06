using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    private WebCamTexture backCam;
    private Texture defaultBackground;

    public RawImage background;
    public Button cameraButton;

    // Start is called before the first frame update
    void Start()
    {
        OpenCamera();
        // cameraButton.onClick.AddListener(OpenCamera);
    }

    public void OpenCamera()
    {
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;
        Debug.Log(devices.Length + " cameras found");
        if (devices.Length == 0)
        {
            Debug.Log("No camera detected");
            //camAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            if (!devices[i].isFrontFacing)
            {
                backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }

        if (backCam == null)
        {
            Debug.Log("Unable to find back Camera");
            return;
        }

        backCam.Play();
        background.texture = backCam;
    }

}
