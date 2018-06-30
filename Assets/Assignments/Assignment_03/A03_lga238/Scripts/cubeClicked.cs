using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace lga238{
public class cubeClicked : MonoBehaviour {

	// Use this for initialization
	public int count = 0;

	public GameObject canvas;

	void Start () {
		
	}
	
	// Update is called once per frame
	public void selected(){
		count++;

		if(count %2  == 0){
			canvas.SetActive(false);

		}

		else{
			canvas.SetActive(true);
		}
	}
}
}
