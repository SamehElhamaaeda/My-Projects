#include<SFML/Graphics.hpp>
#include<SFML/Audio.hpp>
#include<fstream>
#include<ctime>
#include"wtypes.h"
#include"game.h"
#include"textbox.h"
#include<iostream>
using namespace std;
sf::Vector2i GetDesktopResolution()
{
	sf::Vector2i screensize;
	RECT desktop;
	// Get a handle to the desktop window
	const HWND hDesktop = GetDesktopWindow();
	// Get the size of screen to the variable desktop
	GetWindowRect(hDesktop, &desktop);
	// The top left corner will have coordinates (0,0)
	// and the bottom right corner will have coordinates
	// (horizontal, vertical)
	screensize.x = desktop.right;
	screensize.y = desktop.bottom;
	return screensize;
}
int screenw=GetDesktopResolution().x, screenh=GetDesktopResolution().y;
int requirredSize = sqrt(pow(screenw, 2) + pow(screenh, 2)) * 4 / 181;
sf::Texture phototext[7];
//
//Structures:-
struct menu
{
private:
	int sizer1 = 0, x = 2, sizer2 = 0, sizer3 = 0;
	sf::Text ping_pong;
	sf::Texture creditsText;
	sf::RectangleShape Credits;
	sf::Vector2f required_pos;
	sf::RectangleShape ShowPhoto;
public:
	int selected = 0, wasselected = 0;
	int inselected = 0, wasinselected = 0;
	sf::Text main_pages[6],Easy,Hard;
	sf::Text backgrounds[7];
	menu(sf::Font &font)
	{
		creditsText.loadFromFile("credits.png");
		Credits.setSize(sf::Vector2f(screenw, screenh));
		Credits.setTexture(&creditsText);
		required_pos.x = screenw *3/4;
		required_pos.y = screenh /8.f;
		ping_pong.setFont(font);
		ping_pong.setString("Ping\nPong");
		ping_pong.setCharacterSize(2.f);
		ping_pong.setFillColor(sf::Color::Red);
		ping_pong.setPosition(screenw/8.f, screenh/8.f);
		main_pages[0].setFont(font);
		main_pages[0].setString("Single Player");
		main_pages[0].setCharacterSize(0.f);
		main_pages[0].setFillColor(sf::Color::Green);
		main_pages[0].setPosition(required_pos.x,required_pos.y);
		main_pages[1].setFont(font);
		main_pages[1].setString("Multiplayer");
		main_pages[1].setCharacterSize(requirredSize);
		main_pages[1].setFillColor(sf::Color::White);
		main_pages[1].setPosition(screenw, required_pos.y*2);
		main_pages[2].setFont(font);
		main_pages[2].setString("Scores");
		main_pages[2].setCharacterSize(requirredSize);
		main_pages[2].setFillColor(sf::Color::White);
		main_pages[2].setPosition(screenw, required_pos.y*3);
		main_pages[3].setFont(font);
		main_pages[3].setString("Credits");
		main_pages[3].setCharacterSize(requirredSize);
		main_pages[3].setFillColor(sf::Color::White);
		main_pages[3].setPosition(screenw, required_pos.y*4);
		main_pages[4].setFont(font);
		main_pages[4].setString("Options");
		main_pages[4].setCharacterSize(requirredSize);
		main_pages[4].setFillColor(sf::Color::White);
		main_pages[4].setPosition(screenw,required_pos.y*5);
		main_pages[5].setFont(font);
		main_pages[5].setString("Quit");
		main_pages[5].setCharacterSize(0.f);
		main_pages[5].setFillColor(sf::Color::White);
		main_pages[5].setPosition(required_pos.x, required_pos.y*6);
		Easy.setFont(font);
		Easy.setString("Easy");
		Easy.setCharacterSize(requirredSize);
		Easy.setFillColor(sf::Color::Green);
		Easy.setPosition(required_pos.x,required_pos.y);
		Hard.setFont(font);
		Hard.setString("Hard");
		Hard.setCharacterSize(requirredSize);
		Hard.setFillColor(sf::Color::White);
		Hard.setPosition(required_pos.x,required_pos.y*2);
		for (int i = 0; i < 7; i++)
		{
			backgrounds[i].setFont(font);
			backgrounds[i].setString("Background "+to_string(i+1));
			backgrounds[i].setCharacterSize(requirredSize);
			backgrounds[i].setFillColor(sf::Color::White);
			backgrounds[i].setPosition(required_pos.x,required_pos.y*(i+1));
		}
		backgrounds[0].setFillColor(sf::Color::Green);
		ShowPhoto.setSize(sf::Vector2f(screenw*7/16, screenh*7/16));
		ShowPhoto.setPosition(screenw*5/96, screenh/6);
		ShowPhoto.setOutlineThickness(5.f);
		ShowPhoto.setOutlineColor(sf::Color::Black);
	}
	void draw_menu(sf::RenderWindow& window,state gamestate,state innerstate)
	{
		if (main_pages[0].getCharacterSize()< requirredSize)
			main_pages[0].setCharacterSize(sizer2+=1.f);
		if (main_pages[1].getPosition().x > required_pos.x)
			main_pages[1].move(-x*6, 0.f);
		if (main_pages[2].getPosition().x > required_pos.x)
			main_pages[2].move(-x*6, 0.f);
		if (main_pages[3].getPosition().x > required_pos.x)
			main_pages[3].move(-x*6, 0.f);
		if (main_pages[4].getPosition().x > required_pos.x)
			main_pages[4].move(-x*6, 0.f);
		if (main_pages[5].getCharacterSize() < requirredSize)
			main_pages[5].setCharacterSize(sizer3 += 1.f);
		if (ping_pong.getCharacterSize() < requirredSize*6.25)
			ping_pong.setCharacterSize(sizer1 += 4);
		if (gamestate == credits)
		{
			window.draw(Credits);
		}
		else
		{
			if (gamestate == options)
			{
				ShowPhoto.setTexture(&phototext[inselected]);
				window.draw(ShowPhoto);
				for (int i = 0; i < 7; i++)
				{
					window.draw(backgrounds[i]);
				}
			}
			else
			{
				if (innerstate == level)
				{
					window.draw(Easy);
					window.draw(Hard);
				}
				else
				{
					for(int i=0;i<6;i++)
						window.draw(main_pages[i]);
				}
				window.draw(ping_pong);
			}
		}
	}
	void moveUp(state state)
	{
		if (state == mainmenu)
		{
			wasselected = selected;
			selected--;
			if (selected == -1)
				selected = 5;
			main_pages[selected].setFillColor(sf::Color::Green);
			main_pages[wasselected].setFillColor(sf::Color::White);
			
		}
		else if (state == options)
		{
			wasinselected = inselected;
			inselected--;
			if (inselected == -1)
				inselected = 6;	
			backgrounds[inselected].setFillColor(sf::Color::Green);
			backgrounds[wasinselected].setFillColor(sf::Color::White);
			
		}
	}
	void moveDown(state state)
	{
		if (state == mainmenu)
		{
			wasselected = selected;
			selected++;
			if (selected == 6)
				selected = 0;
			main_pages[selected].setFillColor(sf::Color::Green);
			main_pages[wasselected].setFillColor(sf::Color::White);

		}
		else if (state == options)
		{
			wasinselected = inselected;
			inselected++;
			if (inselected == 7)
				inselected = 0;
			backgrounds[inselected].setFillColor(sf::Color::Green);
			backgrounds[wasinselected].setFillColor(sf::Color::White);

		}
	}
	void reset()
	{
		wasselected = selected;
		selected = 0;
		wasinselected = inselected; inselected = 0;
		main_pages[0].setFillColor(sf::Color::Green);
		backgrounds[0].setFillColor(sf::Color::Green);
		if(wasselected!=selected)
			main_pages[wasselected].setFillColor(sf::Color::White);
		if(wasinselected!=inselected)
			backgrounds[wasinselected].setFillColor(sf::Color::White);
		Easy.setFillColor(sf::Color::Green);
		Hard.setFillColor(sf::Color::White);
	}
};
//
//Function declaration :
void reset(menu& menu, game& game);
//
//main function
int main()
{
	
	sf::Font font;
	font.loadFromFile("fonts/BankGothic.ttf");
	phototext[0].loadFromFile("background/bluehorror.png");
	phototext[1].loadFromFile("background/redhorror.png");
	phototext[2].loadFromFile("background/fairytale.png");
	phototext[3].loadFromFile("background/forest.png");
	phototext[4].loadFromFile("background/frozen.png");
	phototext[5].loadFromFile("background/waterfall.png");
	phototext[6].loadFromFile("background/background1.png");
	game game(font,screenw,screenh,requirredSize);
	menu menu(font);
	Textbox textbox(font, screenw, screenh);
	sf::RenderWindow window(sf::VideoMode(screenw, screenh), "working",sf::Style::Fullscreen);
	sf::View view(sf::FloatRect(0, 0, screenw,screenh));
	window.setView(view);
	sf::RectangleShape background;
	background.setSize(sf::Vector2f( screenw, screenh));
	game.setbackground(menu.inselected, background,phototext);
	sf::Music music;
	music.openFromFile("music/gameMusic.ogg");
	music.setVolume(20.f);
	music.play();
	music.setLoop(true);
	sf::Clock clock;
	window.setKeyRepeatEnabled(true);
	while (window.isOpen())
	{
		float deltaTime = clock.restart().asSeconds();
		sf::Event event;
		while (window.pollEvent(event))
		{

			if (event.type == sf::Event::KeyPressed)
			{
				if (event.key.code == sf::Keyboard::Escape && (game.getgamestate() !=mainmenu))
				{
					if (game.getgamestate() ==score)
					{
						view.reset(sf::FloatRect(0, 0, screenw, screenh));
						window.setView(view);
						background.setPosition(0, 0);
					}
					reset(menu, game);
					textbox.reset();
				}
				else if (event.key.code == sf::Keyboard::Enter && menu.main_pages[0].getFillColor() == sf::Color::Green && game.getgamestate() == mainmenu)
				{
					game.playsingle();
				}
				else if (event.key.code == sf::Keyboard::Enter && menu.main_pages[1].getFillColor() == sf::Color::Green && game.getgamestate() ==mainmenu)
				{
					game.playmulti();
				}
				else if (event.key.code == sf::Keyboard::Enter && menu.main_pages[2].getFillColor() == sf::Color::Green && game.getgamestate() ==mainmenu)
				{
					game.showscores();
				}
				else if (event.key.code == sf::Keyboard::Enter && menu.main_pages[3].getFillColor() == sf::Color::Green && game.getgamestate() == mainmenu)
				{
					game.showcredits();
				}
				else if (event.key.code == sf::Keyboard::Enter && menu.main_pages[4].getFillColor() == sf::Color::Green && game.getgamestate() ==mainmenu)
				{
					game.showoptions();
				}
				else if (event.key.code == sf::Keyboard::Enter && menu.main_pages[5].getFillColor() == sf::Color::Green && game.getgamestate() == mainmenu)
				{
					window.close();
				}
				else if (event.key.code == sf::Keyboard::Up && (game.getgamestate() ==mainmenu || game.getgamestate() ==options))
				{
					menu.moveUp(game.getgamestate());
				}
				else if (event.key.code == sf::Keyboard::Down && (game.getgamestate() ==mainmenu || game.getgamestate() ==options))
				{
					menu.moveDown(game.getgamestate());
				}
				else if (event.key.code == sf::Keyboard::Enter && menu.Easy.getFillColor() == sf::Color::Green && game.getinnerstate()==level)
				{
					game.setEasy();
				}
				else if (event.key.code == sf::Keyboard::Enter && menu.Hard.getFillColor() == sf::Color::Green && game.getinnerstate() == level)
				{
					game.setHard();
				}
				else if (event.key.code == sf::Keyboard::Enter && (game.getinnerstate() == namebox1||game.getinnerstate()==namebox2)&&textbox.getText()!="")
				{
					game.setname(textbox.getText());
					textbox.deleteall();
				}
				else if (event.key.code == sf::Keyboard::Up && (game.getgamestate() ==multi|| game.getgamestate() ==single))
				{
					menu.Easy.setFillColor(sf::Color::Green);
					menu.Hard.setFillColor(sf::Color::White);
				}
				else if (event.key.code == sf::Keyboard::Down && (game.getgamestate() == multi || game.getgamestate() == single))
				{
					menu.Easy.setFillColor(sf::Color::White);
					menu.Hard.setFillColor(sf::Color::Green);
				}
				else if (event.key.code == sf::Keyboard::Enter&& game.getgamestate() == options)
				{
					game.setbackground(menu.inselected, background, phototext);
				}
				else if (event.key.code == sf::Keyboard::Space && game.getinnerstate()==pause)
				{
					game.unpause();
				}
				else if (event.key.code == sf::Keyboard::Space && game.getinnerstate()==play)
				{
					game.setpause();
				}
				
			}
			if (event.type == sf::Event::TextEntered &&(game.getinnerstate()==namebox1||game.getinnerstate()==namebox2))
			{
				textbox.typedOn(event);
			}
		}
		if (game.getgamestate()==multi || game.getgamestate() ==single)
		{
				if (game.getinnerstate()==matchend)
				{
					window.clear();
					window.draw(background);
					game.showWinner(window);
					window.display();
				}
				else if (game.getinnerstate() == level)
				{
					window.clear();
					window.draw(background);
					menu.draw_menu(window, game.getgamestate(), game.getinnerstate());
					window.display();
				}
				else if (game.getinnerstate() == pause)
				{
					window.clear();
					window.draw(background);
					game.draw_game(window);
					window.display();
					game.extratime = game.extraclock.getElapsedTime();
				}
				else if (game.getinnerstate() == namebox1 || game.getinnerstate() == namebox2)
				{
					window.clear();
					window.draw(background);
					textbox.drawTo(window);
					window.display();
				}
				else
				{
					if (game.getinnerstate() == stop)
					{
						game.stoptime = game.stopclock.getElapsedTime();
						if (game.stoptime >= sf::seconds(1))
						{
							game.unstop();
						}
					}
					else
					{
						game.update_time();
						float factor = deltaTime * game.ball_speed;
						game.velocity.x = cos(game.angle) * factor;
						game.velocity.y = sin(game.ball_angle) * factor;
						game.ball.move(game.velocity.x, game.velocity.y);
					}
					float fact = deltaTime * game.padspeed;
					if (game.ball.getGlobalBounds().intersects(game.paddle2.getGlobalBounds()) || game.ball.getGlobalBounds().intersects(game.paddle1.getGlobalBounds()))
					{
						game.deflectX();

					}
					else if (game.ball.getGlobalBounds().intersects(game.border.getGlobalBounds()) || game.ball.getGlobalBounds().intersects(game.border2.getGlobalBounds()))
					{
						game.deflectY();
					}

					if (game.getgamestate() == single)
					{
						if (game.ball.getPosition().y + game.ball.getRadius() * 2.f > game.paddle2.getPosition().y + game.paddle2.getSize().y)
						{
							game.paddle2.move(0.f, fact);
						}
						if (game.ball.getPosition().y < game.paddle2.getPosition().y)
						{
							game.paddle2.move(0.f, -fact);
						}
					}
					else if (game.getgamestate() == multi)
					{
						if ((sf::Keyboard::isKeyPressed(sf::Keyboard::Up)) && !(game.paddle2.getGlobalBounds().intersects(game.border.getGlobalBounds())))
							game.paddle2.move(0, -3.2f);
						else if ((sf::Keyboard::isKeyPressed(sf::Keyboard::Down)) && !(game.paddle2.getGlobalBounds().intersects(game.border2.getGlobalBounds())))
							game.paddle2.move(0, 3.2f);
					}
					if ((sf::Keyboard::isKeyPressed(sf::Keyboard::W)) && !(game.paddle1.getGlobalBounds().intersects(game.border.getGlobalBounds())))
						game.paddle1.move(0, -3.2f);
					else if ((sf::Keyboard::isKeyPressed(sf::Keyboard::S)) && !(game.paddle1.getGlobalBounds().intersects(game.border2.getGlobalBounds())))
						game.paddle1.move(0, 3.2f);
					if (game.ball.getPosition().x < game.paddle1.getPosition().x - 40)
					{
						game.update_score2();
					}
					else if (game.ball.getPosition().x > game.paddle2.getPosition().x + 40)
					{
						game.update_score1();
					}
					window.clear();
					window.draw(background);
					game.draw_game(window);
					window.display();
					if ((game.timeends() && game.seconds == 0)|| (game.score1 == 10)|| (game.score2 == 10))
					{
						game.endMatch();
						game.update_data(font);
					}
					
				}
		}
		else if (game.getgamestate() ==score)
		{
			if (sf::Keyboard::isKeyPressed(sf::Keyboard::Up) && view.getCenter().y - screenh/2 > game.matchnum.getPosition().y)
			{
				view.move(0, -1);
				background.move(0, -1);
			}
			else if (sf::Keyboard::isKeyPressed(sf::Keyboard::Down) && view.getCenter().y + 6*screenh/16 < game.playersscore[0].getPosition().y)
			{
				view.move(0, 1);
				background.move(0, 1);
			}
			window.setView(view);
			window.clear();
			window.draw(background);
			window.draw(game.matchnum);
			for (int i = 0; i < game.numofmatches; i++)
			{
				window.draw(game.playersscore[i]);
				window.draw(game.playerdata[i]);
			}
			window.draw(game.ScorePage);
			window.display();
		}
		else if (game.getgamestate() ==mainmenu)
		{
			window.clear();
			window.draw(background);
			menu.draw_menu(window,game.getgamestate(),game.getinnerstate());
			window.display();
		}
		else if (game.getgamestate() == credits)
		{
			window.clear();
			window.draw(background);
			menu.draw_menu(window, game.getgamestate(), game.getinnerstate());
			window.display();
		}
		else if (game.getgamestate() ==options)
		{
			window.clear();
			window.draw(background);
			menu.draw_menu(window, game.getgamestate(), game.getinnerstate());
			window.display();
		}
		
	}
}
//
//functions definition:-
void reset(menu& menu, game& game)
{
	game.reset();
	menu.reset();
}