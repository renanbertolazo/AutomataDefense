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

    public void EnviarImagemPorTextura(Texture2D textura) {
        /*
        //if(textura == null) print("Textura Nula");
        Texture2D texture2d = new Texture2D(8, 8);
        //texture2d = textura;
        texture2d.LoadImage(textura.GetRawTextureData());
        //Sprite sprite = Sprite.Create(textura, new Rect(0, 0, textura.width, textura.height), Vector2.zero);
        texture2d.Apply();
        Sprite sprite = Sprite.Create(texture2d, new Rect(0, 0, texture2d.width, texture2d.height), Vector2.zero);
        
        print(imageToUpdate.color);
        //imageToUpdate.sprite = null;*/
        StartCoroutine(downloadTextura(textura));
        
    }

    IEnumerator downloadTextura(Texture2D textura) {
        yield return null;

        Sprite sprite = Sprite.Create(textura, new Rect(0, 0, textura.width, textura.height), Vector2.zero);
        
        imageToUpdate.sprite = sprite;

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
