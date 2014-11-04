using UnityEngine;
using System.Collections;
using System.IO;
using SimpleJSON;

public class json_parse : MonoBehaviour {
	//mission = parent classs
	public class mission{
		public bool completed = false;
		public mission(){
			//default constructor
		}
		public void parameters(){
		}
		//requires optional arguments understanding current goals
		public bool success(){
			print ("false");
			return false;
		}
		public void failure(){
			//pass in condition to be false to fail
		}
		public void baseline(){
			//borderline passing
		}
		public void run(){
			//access player state and analyze the current data
			//and modify the rest of the program
		}

	}
	//child classess
	public class Assasinate:mission{
		public void assasinate_run(int threshold){
			//testing the time

		}
		public bool success(){

			print ("maybe");
			return true;
		}
	}
	public class Bribe : mission{
	}
	public class Track : mission{
	}
	public class Threaten : mission{
	}
	public class Bombing : mission{
	}
	public class Robbery: mission{
	}
	public class Propaganda: mission{
	}
	public class Acquire: mission{
	}
	public class Destroy: mission{
	}
	public class Sabotage: mission{
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
