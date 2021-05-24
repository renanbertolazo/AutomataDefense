using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class ImageLoader : MonoBehaviour {
    // Start is called before the first frame update
    public Image imageToUpdate;
    
    void Start() {
        imageToUpdate = this.GetComponent<Image>();
    }

    public void EnviarImagem(string url) {
        StartCoroutine(downloadImage(url));
    }

    IEnumerator downloadImage(string url) {

        UnityWebRequest www = UnityWebRequest.Get(url);

        DownloadHandler handle = www.downloadHandler;

        //Send Request and wait
        yield return www.SendWebRequest();

        if (www.isHttpError || www.isNetworkError) {
            UnityEngine.Debug.Log("Error while Receiving: " + www.error);
        }
        else {
            UnityEngine.Debug.Log("Success");

            //Load Image
            Texture2D texture2d = new Texture2D(8, 8);
            Sprite sprite = null;
            if (texture2d.LoadImage(handle.data)) {
                sprite = Sprite.Create(texture2d, new Rect(0, 0, texture2d.width, texture2d.height), Vector2.zero);
            }
            if (sprite != null) {
                imageToUpdate.sprite = sprite;
            }
        }
    }
}
