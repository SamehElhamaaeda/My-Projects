#pragma once
#pragma once
#include<iostream>
#include <sstream>
#include<SFML/Graphics.hpp>
#define DELETE_KEY 8
#define ENTER_KEY 13
#define ESCAPE_KEY 27

class Textbox {
public:
	Textbox()
	{

	}
	Textbox(sf::Font &font,int screenw,int screenh) {
		textbox.setFillColor(sf::Color::Green);
		box.setSize(sf::Vector2f(screenw*3/4,screenh/10));
		box.setPosition(screenw/2-box.getSize().x/2, screenh / 2 - box.getSize().y / 2);
		box.setOutlineThickness(5);
		box.setOutlineColor(sf::Color::Green);
		box.setFillColor(sf::Color::Transparent);
		textbox.setPosition(box.getPosition().x + 5, box.getPosition().y);
		textbox.setCharacterSize(box.getSize().y * 5 / 8);
		textbox.setString("-");
		textbox.setFont(font);
		Entername.setPosition(box.getPosition().x , box.getPosition().y/1.5f);
		Entername.setCharacterSize(box.getSize().y * 5 / 8);
		Entername.setString("Enter Player's Name");
		Entername.setFont(font);
	}

	std::string getText() {
		return text.str();
	}

	void drawTo(sf::RenderWindow& window) {
		window.draw(box);
		window.draw(textbox);
		window.draw(Entername);
	}

	// Function for event loop:
	void typedOn(sf::Event input) {
			int charTyped = input.text.unicode;

			// Only allow normal inputs:
			if (charTyped < 128) {
					if (text.str().length() <= limit) {
						inputLogic(charTyped);
					}
					// But allow for char deletions:
					else if (text.str().length() > limit && charTyped == DELETE_KEY) {
						deleteLastChar();
					}
			}
	}
	void deleteall()
	{
		text.str("");
		textbox.setString("-");
		Entername.setString("Enter Second Player's Name");
	}
	void reset()
	{
		text.str("");
		Entername.setString("Enter Player's Name");
	}
private:
	sf::Text textbox,Entername;
	std::ostringstream text;
	bool isSelected = true;
	bool hasLimit = true;
	int limit = 15;
	sf::RectangleShape box;

	// Delete the last character of the text:
	void deleteLastChar() {
		std::string t = text.str();
		std::string newT = "";
		for (int i = 0; i < t.length() - 1; i++) {
			newT += t[i];
		}
		text.str("");
		text << newT;
		textbox.setString(text.str());
		if (textbox.getString() == "")
			textbox.setString("-");
	}
	// Get user input:
	void inputLogic(int charTyped) {
		// If the key pressed isn't delete, or the two selection keys, then append the text with the char:
		if (charTyped != DELETE_KEY && charTyped != ENTER_KEY && charTyped != ESCAPE_KEY) {
			text << static_cast<char>(charTyped);
		}
		// If the key is delete, then delete the char:
		else if (charTyped == DELETE_KEY) {
			if (text.str().length() > 0) {
				deleteLastChar();
			}
		}
		// Set the textbox text:
		textbox.setString(text.str());
		if (textbox.getString() == "")
			textbox.setString("-");
	}
};
