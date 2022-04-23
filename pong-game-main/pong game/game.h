#pragma once
#include<SFML/Graphics.hpp>
#include<SFML/Audio.hpp>
#include<fstream>
#include<ctime>
#include"gamestate.h"
using namespace std;
class game
{
private:
	sf::Time time1, time3 = sf::seconds(90),stopper;
	sf::Text textscore1, textscore2;
	sf::Text Winner, pausing;
	sf::Text timeleft;
	float angles[16] = { 20,26,29,30,36,39,40,46,49,20,26,29,30,36,39,40 };
	int screenw, screenh, requirredSize;
	state gamestate = mainmenu, innerstate = mainmenu;
	string name1="", name2 = "computer";
public:
	sf::Texture paddletext,balltext;
	string paddles[7] = { "paddles/freeze.jpg" ,"paddles/lava.png" ,"paddles/space.jpg" ,"paddles/ground.png" ,"paddles/freeze.jpg" ,"paddles/freeze.jpg" ,"paddles/tile5.png" };
	string balls[7] = { "balls/freeze.jpg" ,"balls/lava.png" ,"balls/space.jpg" ,"balls/bush.png" ,"balls/freeze.jpg" ,"balls/freeze.jpg" ,"balls/tile5.png" };
	string date, hour;
	sf::RectangleShape border, border2, paddle1, paddle2;
	sf::Texture padd;
	sf::Sprite padde;
	sf::CircleShape ball;
	sf::Vector2f velocity;
	float ball_speed, ball_angle = 70.f, angle = 70.f;
	float padspeed;
	float accel = sqrt(pow(screenw, 2) + pow(screenh, 2)) * 125.f / 7071.f;
	float padaccel = sqrt(pow(screenw, 2) + pow(screenh, 2)) * 125.f / 7071.f;
	float reflectaccel = sqrt(pow(screenw, 2) + pow(screenh, 2)) * 25.f / 14142.f;
	int score1 = 0, score2 = 0;
	string sscore1 = to_string(score1), sscore2 = to_string(score2);
	sf::SoundBuffer collisionbuff, winbuff, goalbuff;
	sf::Sound collision, winsound, goalsound;
	sf::Clock  clock2, extraclock,stopclock;
	sf::Time  extratime = extraclock.restart(),stoptime;
	int seconds = ((time3 - time1).asSeconds());
	int extrasec = 0,stopsec=0;
	string sec = to_string(seconds);
	ofstream scores;
	ifstream scored;
	ofstream player;
	ifstream players;
	int numofmatches;
	sf::Text matchnum;
	sf::Text* playersscore;
	sf::Text* playerdata;
	string playerscore;
	string difficulty;
	sf::Text ScorePage;
	game(sf::Font &font ,int &screenw, int &screenh,int &requirredSize);
	void update_time();
	void deflectX();
	void deflectY();
	bool timeends();
	void update_data(sf::Font& font);
	void draw_game(sf::RenderWindow& window);
	void reset();
	void showWinner(sf::RenderWindow& window);
	void endMatch();
	void update_score2();
	void update_score1();
	void setHard();
	void setEasy();
	void unpause();
	void setpause();
	float randangle();
	void playsingle();
	void playmulti();
	void showscores();
	void showcredits();
	void showoptions();
	void setbackground(int& selected, sf::RectangleShape& background,sf::Texture phototext[]);
	state getgamestate();
	state getinnerstate();
	void setinnerstate(state state)
	{
		innerstate = state;
	}
	void unstop()
	{
		innerstate = play;
		stopsec += stoptime.asSeconds();
	}
	void setname(string text)
	{
		if (innerstate == namebox1)
		{
			name1 = text;
			textscore1.setString(name1 + ": " + sscore1);
			if (gamestate == single)
				innerstate = play;
			else
				innerstate = namebox2;
		}
		else if (innerstate == namebox2)
		{
			name2 = text;
			textscore2.setString(name2 + ": " + sscore2);
			innerstate = play;
		}

	}
	~game();
};

