using UnityEngine;
using Pathfinding.Serialization.JsonFx;
using System.Collections;

public class Sketch : MonoBehaviour {

    public GameObject myPrefab;
	string _WebsiteURL = "http://anthonyliu.azurewebsites.net/tables/product?zumo-api-version=2.0.0";

    void Start () {
        string jsonResponse = Request.GET(_WebsiteURL);

        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        Product[] products = JsonReader.Deserialize<Product[]>(jsonResponse);

        int totalCubes = products.Length;
        int totalDistance = 10;
        int i = 0;
        foreach (Product product in products)
        {
            float perc = i / (float)totalCubes;
            i++;
            float x = perc * totalDistance;
            float y = 10.0f;
            float z = 0.0f;
            Debug.log(product.ProductID);
            GameObject newCube = (GameObject)Instantiate(myPrefab, new Vector3( x, y, z), Quaternion.identity);
			newCube.GetComponent<MyCubeScript>().setSize((1.0f - perc) *2);
			newCube.GetComponent<MyCubeScript>().rotateSpeed = perc;
            newCube.GetComponentInChildren<TextMesh>().text = product.ProductID;
        }        
	}
	
	void Update () {
	
	}
}
