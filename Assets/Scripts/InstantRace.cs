using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantRace : MonoBehaviour {
	public int Episode = 1;
	public string[] Contestants = new string[14];
	string[] Cast = new string[14];
	string[] ThisEpisode = new string[14];
	public string[] Winners = new string[12];
	public string[] Losers = new string[11];
	public string[] TopTwo = new string[11];
	public string[] BottomTwo = new string[11];
	public string[] RunnerUps = new string[] { " ", " " };

	void Start () {
		GenerateCast();
		RunSeason();
	}

	void RunSeason() {
		RunEpisode();
		RunEpisode();
		RunEpisode();
		RunEpisode();
		RunEpisode();
		RunEpisode();
		RunEpisode();
		RunEpisode();
		RunEpisode();
		RunEpisode();
		RunEpisode();
		RunFinale();
	}

	void GenerateCast () {
		string[] Names = System.IO.File.ReadAllLines(Application.dataPath+"/Loadable/Names/Queens/Names.txt");
		string[] Nicknames = System.IO.File.ReadAllLines(Application.dataPath+"/Loadable/Names/Queens/Nicknames.txt");
		string[] Surnames = System.IO.File.ReadAllLines(Application.dataPath+"/Loadable/Names/Queens/Surnames.txt");

		for (int Clock = 0; Clock <= Contestants.Length-1; Clock++) {
			string Name = Names[Random.Range(0, Names.Length)];
			string Surname = "";
			string Nickname = "";

			if(Random.Range(0, 6) == 0) {
				Nickname = Nicknames[Random.Range(0, Nicknames.Length)]+" ";
			}

			if(Random.Range(0, 6) != 0) {
				Surname = Surnames[Random.Range(0, Surnames.Length)]+" ";
			}

			Contestants[Clock] = Name+" "+Nickname+Surname;
			Cast[Clock] = Name+" "+Nickname+Surname;
		}
	}

	void RunEpisode () {
		string Winner = " ";
		string Loser = " ";
		string SecondToFirst = " ";
		string SecondToLast = " ";

		int WinnerDice = 0;
		int LoserDice = 0;
		int SecondToFirstDice = 0;
		int SecondToLastDice = 0;

		while(Loser == " ") {
			LoserDice = Random.Range(0, Cast.Length);
			Loser = Cast[LoserDice];
		}

		Losers[Episode-1] = Cast[LoserDice];
		Cast[LoserDice] = " ";

		ThisEpisode = Cast;

		while(Winner == " ") {
			WinnerDice = Random.Range(0, Cast.Length);
			Winner = ThisEpisode[WinnerDice];
		}

		Winners[Episode-1] = ThisEpisode[WinnerDice];

		while(SecondToFirst == " ") {
			SecondToFirstDice = Random.Range(0, Cast.Length);
			SecondToFirst = ThisEpisode[SecondToFirstDice];
		}

		TopTwo[Episode-1] = ThisEpisode[SecondToFirstDice];

		while(SecondToLast == " ") {
			SecondToLastDice = Random.Range(0, Cast.Length);
			SecondToLast = ThisEpisode[SecondToLastDice];
		}

		BottomTwo[Episode-1] = ThisEpisode[SecondToLastDice];

		Debug.Log("Winner: "+Winner+" / Second to First: "+SecondToFirst+" / Loser: "+Loser+" / Second to Last: "+SecondToLast);
		ThisEpisode = Cast;
		Episode++;
	}

	void RunFinale() {
		string Winner = " ";
		int WinnerDice = 0;
		int RunnerUpsDice;

		while(Winner == " ") {
			WinnerDice = Random.Range(0, Cast.Length);
			Winner = Cast[WinnerDice];
		}

		Winners[Episode-1] = Cast[WinnerDice];
		Cast[WinnerDice] = " ";

		for (int Clock = 0; Clock <= RunnerUps.Length-1; Clock++) {
			while(RunnerUps[Clock] == " ") {
				RunnerUpsDice = Random.Range(0, Cast.Length);
				RunnerUps[Clock] = Cast[RunnerUpsDice];
			}
		}

		Debug.Log("Season Winner: "+Winner+" / Runner-Ups: "+RunnerUps[0]+" and "+RunnerUps[1]);
	}
}