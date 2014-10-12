using UnityEngine;
using System.Collections;

public class GenerateAttackers : MonoBehaviour
	
{
	
	public GameObject ship;
	public int planetType = 1;
	public static Color colortest;
	private float delay=10;
	


	//This is only for converting RGB to proper hexdecimal color, RGB colors can be used below by using hexColor(number, number, number, number)
	public static Vector4 hexColor(float r, float g, float b, float a){
		Vector4 color = new Vector4(r/255, g/255, b/255, a/255);
		colortest = color;
		return color;
	}
	
	
	void Start() {
		
		StartCoroutine(Loop());
		Debug.Log("SHIPS COROUTINE STARTED");
	}
	
	
	IEnumerator Loop() {

		while (true) {

			//this loop checks to find whether ships are enemies or friendly and instantiates them around the base in a random fashion
						if (gameObject.tag == "Home Base") {
							transform.renderer.material.color = hexColor(0, 222, 185, 255);
							Vector3 position = new Vector3(UnityEngine.Random.Range(-6.0F, 0.0F), UnityEngine.Random.Range(-4.0F, 1.0F), UnityEngine.Random.Range(0.0F, 1.0F));
							Instantiate(ship, position, Quaternion.identity);
							//gameObject.tag = "Home Ship";
							delay = 1f;
						}
				
						if (gameObject.tag == "Enemy Base") {
							transform.renderer.material.color = hexColor(255, 0, 13, 255);
							Vector3 position = new Vector3(UnityEngine.Random.Range(-6.0F, 0.0F), UnityEngine.Random.Range(-4.0F, 1.0F), UnityEngine.Random.Range(0.0F, 1.0F));
							Instantiate(ship, position, Quaternion.identity);
			//	transform.position = new Vector3(transform.position.x - range * Random.value, transform.position.y, transform.position.z);

							//gameObject.tag = "Enemy Ship";
							delay = 1f;
			}
			
			
			
			yield return new WaitForSeconds(delay);
					}
	}
	
}
