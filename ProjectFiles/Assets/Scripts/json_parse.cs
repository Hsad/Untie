using UnityEngine;
using System.Collections;
using System.IO;
using SimpleJSON;

public class json_parse : MonoBehaviour {
	//mission = parent classs

	public class mission{
		//clock time set
		public int time_complete = 0;
		//boolean to determine if complete
		public bool completed = false;
		public JSONNode prerequisite;
		public JSONNode success_parameters;
		public mission(){
			time_complete = 0;
		}
		public mission(JSONNode prereq, JSONNode complete){
			//default constructor
			time_complete = 0;
			prerequisite = prereq;
			success_parameters = complete;
			//set_parameters_materials();
		}
		//storing parameters/prereq
		public void set_parameters_materials(){
			int i = 0;
			while (prerequisite[i] != null){
				if (PlayerState.Instance.check_materials(prerequisite[i][0].Value,prerequisite[i][1].AsInt)){
					PlayerState.Instance.update_materials(prerequisite[i][0].Value,  prerequisite[i][1].AsInt);
				}else{
					//fail condition
				}
				i++;
			}
		}
		//requires optional arguments understanding current goals
		public bool success(){
			return false;
		}
		public void baseline(){
			//borderline passing
		}
		public void run(){
			//access player state and analyze the current data
			//and modify the rest of the program
		}
		public bool test_time(){
			//testing the time
			//matain clock
			if ( PlayerState.Instance.get_time()< time_complete){
				PlayerState.Instance.update_time();
			}else if (PlayerState.Instance.get_time() == time_complete){
				success();
				return true;
			}else{
				return false;
			} 
			return false;
		}
	}
	//child classess
	public class Assasinate:mission{
		public Assasinate(){
			time_complete = 0;
		}
		public Assasinate(JSONNode prereq, JSONNode complete):base (prereq, complete){
			//setting up materials required
			set_parameters_materials();
		}
		public void assasinate_run(int threshold, int time_complete){
			if ( test_time() == true){
				//checking parameters
				if ( assasinate_sucess() == true){
					//mission accompolish
				}

			}
		}
		public bool assasinate_sucess(){
			int temp = 0;
			while (success_parameters[temp] != null){
				//runn test to make sure everyone is wher
				//
			}
			return true;
		}
	}
	public class Bribe : mission{
		public Bribe(){
			time_complete = 0;
		}
		public Bribe(JSONNode prereq, JSONNode end) : base(prereq,end){
			set_parameters_materials();
		}
		public void bribe_run(int bribe_amount){
			if ( test_time() == true){
				//checking parameters
				//succeed/ checkk if there is enough money to bribe with
				if (PlayerState.Instance.check_materials("c4", (-1 * bribe_amount))){
					PlayerState.Instance.update_materials("c4",(-1 * bribe_amount));
				}
			}
		}
	}
	public class Track : mission{
		public Track(){
			time_complete  =0;
		}
		public Track(JSONNode prereq, JSONNode end):base (prereq,end){
			set_parameters_materials();
		}
		public void track_run(){
			if ( test_time() == true){
				//checking parameters

				//succeed
				PlayerState.Instance.update_notes("new information");
			}
		}
	}
	public class Threaten : mission{
		public Threaten(){
			time_complete =0;
		}
		public Threaten(JSONNode prereq, JSONNode end):base (prereq,end){
			set_parameters_materials();
		}
		public void threaten_run(){
			if ( test_time() == true){
				//checking parameters

				//succed
				//check player location, enemy location , correct character-> correct
			}
		}
	}
	public class Bombing : mission{
		public Bombing(){
			time_complete = 0;
		}
		public Bombing(JSONNode prereq, JSONNode end):base (prereq,end){
			set_parameters_materials();
		}
		public void bomb_run(){
			if ( test_time() == true){
				//checking parameters

				//do the math for objective
				if (PlayerState.Instance.check_materials("c4", -4)){
					PlayerState.Instance.update_materials("c4",-4);
				}

			}
		}
	}
	public class Robbery: mission{
		public Robbery(){
			time_complete = 0;
		}
		public Robbery(JSONNode prereq, JSONNode end):base (prereq,end){
			set_parameters_materials();
		}
		public void robbery_run(){
			if ( test_time() == true){
				//checking parameters
				
				//do the math for objective
				if (PlayerState.Instance.check_materials("c4", -4)){
					PlayerState.Instance.update_materials("c4",-4);
				}

			}
		}
	}
	public class Propaganda: mission{
		public Propaganda(){
			time_complete = 0;
		}
		public Propaganda(JSONNode prereq, JSONNode end):base (prereq,end){
			set_parameters_materials();
		}
		public void propaganda_run(){
			if ( test_time() == true){
				//checking parameters
				
				//succeed update public opinion
				PlayerState.Instance.update_public();
			}
		}
	}
	public class Acquire: mission{
		public Acquire(){
			time_complete = 0;
		}
		public Acquire(JSONNode prereq, JSONNode end):base (prereq,end){
			set_parameters_materials();
		}
		public void acquire_run(){
			//checking parameters
			
			//do the math for objective/ more materials
			if (PlayerState.Instance.check_materials("c4", 4)){
				PlayerState.Instance.update_materials("c4",4);
			}
		}
	}
	public class Destroy: mission{
		public Destroy(){
			time_complete = 0;
		}
		public Destroy(JSONNode prereq, JSONNode end):base (prereq,end){
			set_parameters_materials();
		}
		public void destroy_run(){
			if ( test_time() == true){
				//checking parameters

				//succeed
			}
		}
	}
	public class Sabotage: mission{
		public Sabotage(){
			time_complete = 0;
		}
		public Sabotage(JSONNode prereq, JSONNode end):base (prereq,end){
			set_parameters_materials();
		}
		public void sabotage_run(){
			if ( test_time() == true){
				//checking parameters

				//succeed
			}
		}
	}
	// Use this for initialization
	void Start () {
		//initiaize starting money
		PlayerState.Instance.update_materials("money", 500);
		//Open file and read in the data
		var sr = new StreamReader(Application.dataPath + "/scripts/test_json.json");
		var file_contents = sr.ReadToEnd();
		sr.Close();
		//Parse the JSON data
		var n = JSON.Parse(file_contents);
		//get prereq and success parameters
		var prereq = n["mission"]["data"][2];
		var end =  n["mission"]["data"][3];
		//make the approbiate class
		if ( n["mission"]["data"][0].Value == "Assasinate"){
			var type = new Assasinate(prereq,end);
		}
		else if ( n["mission"]["data"][0].Value == "Bribe"){
			var type = new Bribe(prereq,end);
		}
		else if ( n["mission"]["data"][0].Value == "Track"){
			var type = new Track(prereq,end);
		}
		else if ( n["mission"]["data"][0].Value == "Threaten"){
			var type = new Threaten(prereq,end);
		}
		else if ( n["mission"]["data"][0].Value == "Bombing"){
			var type = new Bombing(prereq,end);
		}
		else if ( n["mission"]["data"][0].Value == "Robbery"){
			var type = new Robbery(prereq,end);
		}
		else if  (n["mission"]["data"][0].Value == "Propaganda"){
			var type = new Propaganda(prereq,end);
		}
		else if ( n["mission"]["data"][0].Value == "Acquire"){
			var type = new Acquire(prereq,end);
		}
		else if ( n["mission"]["data"][0].Value == "Destroy"){
			var type = new Destroy(prereq,end);
		}
		else if ( n["mission"]["data"][0].Value == "Sabotage"){
			var type = new Sabotage(prereq,end);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
