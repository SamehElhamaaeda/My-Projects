#include "game.h"
using namespace std;

	game::game(sf::Font& font, int &screenw, int &screenh,int &requirredSize)
	{
		
		gamestate = mainmenu;
		innerstate = mainmenu;
		this->screenw = screenw;
		this->screenh = screenh;
		this->requirredSize = requirredSize;
		collisionbuff.loadFromFile("music/Collision.wav");
		winbuff.loadFromFile("music/cheer.wav");
		goalbuff.loadFromFile("music/scoreUpdate.wav");
		collision.setBuffer(collisionbuff);
		winsound.setBuffer(winbuff);
		goalsound.setBuffer(goalbuff);
		scores.open("score.txt", ios::app);
		scored.open("score.txt"); scored.seekg(0);
		players.open("players.txt");
		scored >> numofmatches;
		playersscore = new sf::Text[numofmatches];
		playerdata = new sf::Text[numofmatches];
		matchnum.setString("Number of Matches: " + to_string(numofmatches));
		matchnum.setFont(font);
		matchnum.setFillColor(sf::Color::White);
		matchnum.setCharacterSize(requirredSize);
		matchnum.setPosition(sf::Vector2f(screenw * 11 / 32, 0.f));
		update_data(font);
		time1 = clock2.getElapsedTime();
		ball.setPointCount(10);
		ball.setRadius(sqrt(pow(screenw, 2) + pow(screenh, 2)) * 100 / 11313);
		ball.setPosition(screenw / 2 - ball.getRadius(), screenh / 2 - ball.getRadius());
		paddle1.setSize(sf::Vector2f(screenw * 3 / 320, screenh * 13 / 80));
		paddle2.setSize(sf::Vector2f(screenw * 3 / 320, screenh * 13 / 80));
		paddle2.setPosition(screenw - paddle2.getSize().x, 0.f);
		border.setSize(sf::Vector2f(screenw + 20, 5));
		border2.setSize(sf::Vector2f(screenw + 20, -5));
		border.setPosition(0, 0);
		border2.setPosition(0, screenh - border2.getSize().y);
		border.setFillColor(sf::Color::Transparent);
		border2.setFillColor(sf::Color::Transparent);
		textscore1.setString(name1+": " + sscore1);
		textscore1.setFont(font);
		textscore1.setFillColor(sf::Color::White);
		textscore1.setCharacterSize(requirredSize);
		textscore1.setPosition(sf::Vector2f(screenw / 26, 0.f));
		textscore2.setString(name2+": " + sscore2);
		textscore2.setFont(font);
		textscore2.setFillColor(sf::Color::White);
		textscore2.setCharacterSize(requirredSize);
		textscore2.setPosition(sf::Vector2f(screenw * 13 / 20, 0.f));
		Winner.setFont(font);
		Winner.setFillColor(sf::Color::White);
		Winner.setCharacterSize(requirredSize * 4.18f);
		Winner.setOrigin(Winner.getGlobalBounds().width / 2.f, Winner.getGlobalBounds().height / 2.f);
		Winner.setPosition(screenw * 3 / 16, screenh * 3 / 8);
		pausing.setString("Pause");
		pausing.setFont(font);
		pausing.setFillColor(sf::Color::White);
		pausing.setCharacterSize(requirredSize * 4.18f);
		pausing.setPosition(sf::Vector2f(screenw / 2.f, screenh / 2.f));
		pausing.setOrigin(sf::Vector2f(pausing.getGlobalBounds().width / 2, pausing.getGlobalBounds().height / 2));
		timeleft.setString(sec);
		timeleft.setFont(font);
		timeleft.setFillColor(sf::Color::White);
		timeleft.setCharacterSize(requirredSize);
		timeleft.setPosition(sf::Vector2f(screenw / 2.f, 0.f));
		ScorePage.setFont(font);
		ScorePage.setString("Winner\t\t  Difficulty\t    Date\t\t\t\tTime");
		ScorePage.setCharacterSize(requirredSize);
		ScorePage.setFillColor(sf::Color::Red);
		ScorePage.setPosition(sf::Vector2f(screenw * 3 / 32, screenh / 8));	
	}
	void game::update_time()
	{
		time1 = clock2.getElapsedTime();
		seconds = ((time3 - time1).asSeconds() + extrasec+stopsec);
		sec = to_string(seconds);
		timeleft.setString(sec);
	}
	void game::deflectX()
	{
		/*if (ball_speed > 0)
			ball_speed += reflectaccel;
		else
			ball_speed -= reflectaccel;*/
		ball.move(-velocity.x*2, -velocity.y*2);
		velocity.x = -velocity.x;
		ball_speed = -ball_speed;
		angle = -angle;
		ball_angle = -ball_angle;
		if (ball_angle > 0)
			ball_angle = randangle();
		else
			ball_angle = -randangle();
		collision.play();
	}
	void game::deflectY()
	{
		ball.move(-velocity.x, -velocity.y);
		velocity.y = -velocity.y;
		angle = -angle;
		ball_angle = -ball_angle;
		collision.play();
	}
	void game::setpause()
	{
		innerstate = pause; extraclock.restart();
	}
	void game::unpause()
	{
		innerstate = play;
		extrasec += extratime.asSeconds();
	}
	void game::setEasy()
	{
		difficulty = difficulty + "easy";
		innerstate = namebox1; ball_speed = sqrt(pow(screenw, 2) + pow(screenh, 2)) * 500.f / 707.f; padspeed = sqrt(pow(screenw, 2) + pow(screenh, 2)) * 1000.f / 3389.f;
		clock2.restart(); extraclock.restart();
	}
	void game::setHard()
	{
		difficulty = difficulty + "hard";
		innerstate = namebox1; ball_speed = sqrt(pow(screenw, 2) + pow(screenh, 2)) * 1000 / 1131; padspeed = sqrt(pow(screenw, 2) + pow(screenh, 2)) * 250.f / 377.f;
		clock2.restart(); extraclock.restart();
	}
	void game::update_score1()
	{
		score1++;
		sscore1 = to_string(score1);
		textscore1.setString(name1+": " + sscore1);
		ball.setPosition(sf::Vector2f(screenw / 2, screenh / 2));
		/*if (ball_speed > 0)
			ball_speed += accel;
		else
			ball_speed -= accel;*/
			//padspeed += padaccel;
		deflectX();
		if (ball_angle > 0)
		{
			ball_angle = 70.f;
		}
		else
			ball_angle = -70.f;
		innerstate = stop;
		stopclock.restart();
		goalsound.play();
	}
	void game::update_score2()
	{
		score2++;
		sscore2 = to_string(score2);
		textscore2.setString(name2+": " + sscore2);
		ball.setPosition(sf::Vector2f(screenw / 2, screenh / 2));
		/*if (ball_speed > 0)
			ball_speed += accel;
		else
			ball_speed -= accel;*/
			//padspeed += accel;
		deflectX();
		if (ball_angle > 0)
		{
			ball_angle = 70.f;
		}
		else
			ball_angle = -70.f;
		innerstate = stop;
		stopclock.restart();
		goalsound.play();
	}
	void game::endMatch()
	{
		numofmatches++;
		scores.close(); scores.open("score.txt"); scores << numofmatches;
		matchnum.setString("Number of Matches: " + to_string(numofmatches));
		delete[] playersscore; playersscore = NULL;
		delete[] playerdata; playerdata = NULL;
		playersscore = new sf::Text[numofmatches];
		playerdata = new sf::Text[numofmatches];
		time_t dateANDtime = time(NULL);
		tm* ymdhm = localtime(&dateANDtime);
		date = to_string(ymdhm->tm_year + 1900) + "/" + ((ymdhm->tm_mon+1>10)?to_string(ymdhm->tm_mon + 1):"0"+ to_string(ymdhm->tm_mon + 1)) + "/" + ((ymdhm->tm_mday>10)?to_string(ymdhm->tm_mday):"0"+ to_string(ymdhm->tm_mday));
		hour = ((ymdhm->tm_hour>10)?to_string(ymdhm->tm_hour):"0"+to_string(ymdhm->tm_hour)) + ":" + ((ymdhm->tm_min>10)?to_string(ymdhm->tm_min):"0"+to_string(ymdhm->tm_min));
		innerstate = matchend;
		if (score1 > score2)
		{
			winsound.play();
			Winner.setString(name1+" Wins");
			player << name1<<endl;
			player << difficulty << endl;
			player << date << endl;
			player << hour << endl;
		}
		else if (score2 > score1)
		{
			winsound.play();
			Winner.setString(name2+" Wins");
			player << name2 << endl;
			player << difficulty << endl;
			player << date << endl;
			player << hour << endl;
		}
		else if (score1 == score2)
		{
			winsound.play();
			Winner.setString("Draw");
			player << "draw\n";
			player << difficulty << endl;
			player << date << endl;
			player << hour << endl;
		}
	}
	void game::showWinner(sf::RenderWindow& window)
	{
		window.draw(Winner); window.draw(textscore1);
		window.draw(textscore2);
	}
	void game::reset()
	{
		gamestate = mainmenu; innerstate = mainmenu;
		ball.setPosition(screenw / 2, screenh / 2);
		paddle2.setPosition(screenw - paddle2.getSize().x, 0.f);
		paddle1.setPosition(sf::Vector2f(0.f, 0.f));
		score1 = 0; score2 = 0;
		sscore1 = to_string(score1); sscore2 = to_string(score2);
		name1 = "player1"; name2 = "computer";
		textscore1.setString(name1+": " + sscore1);
		textscore2.setString(name2+": " + sscore2);
		extrasec = 0; stopsec = 0;
	}
	void game::draw_game(sf::RenderWindow& window)
	{
		window.draw(paddle1);
		window.draw(paddle2);
		window.draw(ball);
		window.draw(border);
		window.draw(border2);
		window.draw(textscore1);
		window.draw(textscore2);
		window.draw(timeleft);
		if (innerstate == pause)
			window.draw(pausing);
		
	}
	void game::update_data(sf::Font& font)
	{
		player.close();
		players.seekg(0);
		for (int i = 0; i < numofmatches; i++)
		{
			players >> playerscore;
			players >> difficulty;
			players >> date;
			players >> hour;
			playersscore[i].setString(playerscore);
			playersscore[i].setFont(font);
			playersscore[i].setFillColor(sf::Color::White);
			playersscore[i].setCharacterSize(requirredSize);
			playersscore[i].setPosition(sf::Vector2f(screenw * 3 / 32, screenh / 8 * (numofmatches - i + 1)));
			if(difficulty.substr(0,5)=="multi")
				playerdata[i].setString(difficulty + "\t\t" + date + "\t" + hour);
			else if(difficulty=="single/hard")
				playerdata[i].setString(difficulty + "\t " + date + "\t" + hour);
			else
				playerdata[i].setString(difficulty + "\t  " + date + "\t" + hour);
			playerdata[i].setFont(font);
			playerdata[i].setFillColor(sf::Color::White);
			playerdata[i].setCharacterSize(requirredSize);
			playerdata[i].setPosition(sf::Vector2f(screenw * 9 / 32, screenh / 8 * (numofmatches - i + 1)));
		}
		player.open("players.txt", ios::app);
	}
	bool game::timeends()
	{
		if (seconds==0)
			return true;
		else
			return false;
	}
	float game::randangle()
	{
		return angles[rand() % 16];
	}
	void game::playsingle()
	{
		gamestate = single;
		innerstate = level;
		difficulty = "single/";
	}
	void game::playmulti()
	{
		gamestate = multi;
		innerstate = level;
		difficulty = "multi/";
	}
	state game::getgamestate()
	{
		return gamestate;
	}
	state game::getinnerstate()
	{
		return innerstate;
	}
	void game::showscores()
	{
		gamestate = score;
	}
	void game::showcredits()
	{
		gamestate = credits;
	}
	void game::showoptions()
	{
		gamestate = options;
	}
	void game::setbackground(int& selected, sf::RectangleShape& background,sf::Texture phototext[])
	{
		paddletext.loadFromFile(paddles[selected]);
		balltext.loadFromFile(balls[selected]);
		paddle1.setTextureRect(sf::IntRect(0, 0, paddletext.getSize().x, paddletext.getSize().y));
		paddle2.setTextureRect(sf::IntRect(0, 0, paddletext.getSize().x, paddletext.getSize().y));
		ball.setTextureRect(sf::IntRect(0, 0, balltext.getSize().x, balltext.getSize().y));
		background.setTextureRect(sf::IntRect(0, 0, phototext[selected].getSize().x, phototext[selected].getSize().y));
		background.setTexture(&phototext[selected]);
		paddle1.setTexture(&paddletext);
		paddle2.setTexture(&paddletext);
		ball.setTexture(&balltext);
	}
	game::~game()
	{
		scores.close();
		scored.close();
		player.close();
		players.close();
		delete[]playersscore;
		playersscore = NULL;
	}
