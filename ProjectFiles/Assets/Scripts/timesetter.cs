using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timesetter : MonoBehaviour {

	public int hour = 12;
	public int minute = 0;

	public Text hourtext;
	public Text minutetext;

	public void set_hour(){
		if(++hour > 23) hour = 0;
		update_time();
	}

	public void set_minute(){
		if(++minute > 59) minute = 0;
		update_time();
	}

	void update_time(){
		hourtext.text = hour.ToString("00");
		minutetext.text = minute.ToString("00");
	}

}
