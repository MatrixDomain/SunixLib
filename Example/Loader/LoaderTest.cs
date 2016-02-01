using UnityEngine;
using Sunix.Lib.Components;

public class LoaderTest : MonoBehaviour {

    public GameObject prfab;

	// Use this for initialization
	void Start () {
        Loader loader = LoaderManager.instance.createLoader();
        string url = "file://" + Application.dataPath + "/StreamingAssets/a.jpg";
        loader.onCompleteHandler = showTexture;
        loader.add(url);
        loader.start();
    }

    public void showTexture(string key) {
        Debug.Log("Show Texture");
    }

	// Update is called once per frame
	void Update () {
	
	}
}
