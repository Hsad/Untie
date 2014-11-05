using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueQueue : MonoBehaviour {
	public Queue<string> dialogue = new Queue<string>();//queue for dialogue

	private string[] current;//the current list of words to draw
	private int words = 0;//the number of words
	private int curindex = 0;//the current word index

	public int chunk_size = 30;//max number of characters to display at a time
	private Text txt;

	void Start(){
		txt = GetComponentInChildren<Text>();
	}


	public void next_chunk(){//get the next chunk of dialogue
		if(curindex >= words){//if all words are rendered, get next thing from list
			txt.text = "";
			if(dialogue.Count > 0){
				current = dialogue.Peek().Split(' ');//get new current list of words
				dialogue.Dequeue();
				curindex = 0;
				words = current.Length-1;
			}
		}else{//else draw next chunk
			int cc = 0;
			string output = "";
			for(int i = curindex; i<words+1;i++){//for each word
				if(cc + current[i].Length <= chunk_size){
					cc += current[i].Length;
					output += current[i] + " ";	
					curindex = i;
				}else{
					break;
				}
			}
			txt.text = output;
		}
	}
}
