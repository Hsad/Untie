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

		public mission(){
			//default constructor
			time_complete = 0;
		}
		//storing parameters/prereq
		public void parameters(){
		}
		//requires optional arguments understanding current goals
		public bool success(){
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
		public bool test_time(){
			//testing the time
			if ( PlayerState.Instance.get_time()< time_complete){
				PlayerState.Instance.update_time();
			}else if (PlayerState.Instance.get_time() == time_complete){
				success();
				return true;
			}else{
				failure();
				return false;
			} 
			return false;
		}
	}
	//child classess
	public class Assasinate:mission{
		public void assasinate_run(int threshold, int time_complete){
			if ( test_time() == true){
				//checking parameters

			}
		}
	}
	public class Bribe : mission{
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
		public void track_run(){
			if ( test_time() == true){
				//checking parameters

				//succeed
				PlayerState.Instance.update_notes("new information");
			}
		}
	}
	public class Threaten : mission{
		public void threaten_run(){
			if ( test_time() == true){
				//checking parameters

				//succed
			}
		}
	}
	public class Bombing : mission{
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
		public void propaganda_run(){
			if ( test_time() == true){
				//checking parameters
				
				//succeed update public opinion
				PlayerState.Instance.update_public();
			}
		}
	}
	public class Acquire: mission{
		public void acquire_run(){
			//checking parameters
			
			//do the math for objective/ more materials
			if (PlayerState.Instance.check_materials("c4", 4)){
				PlayerState.Instance.update_materials("c4",4);
			}
		}
	}
	public class Destroy: mission{
		public void destroy_run(){
			if ( test_time() == true){
				//checking parameters

				//succeed
			}
		}
	}
	public class Sabotage: mission{
		public void sabotage_run(){
			if ( test_time() == true){
				//checking parameters

				//succeed
			}
		}
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
