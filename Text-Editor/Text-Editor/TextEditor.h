#ifndef TEXTEDITOR_H
#define TEXTEDITOR_H
#include <iostream>
#include <fstream>
#include <string>
#include <vector>

using namespace std;

class TextEditor
{
public:

    vector <string> v;
    int items;

    void AddLine(string text);//adding new line to the file
    void InsertLine(int pos, string text);//inserting a line in specific position

    string GetLineText(int pos);//rturning a line in a specific position;
    void DeleteLine(int pos);//deleting a line 

    void UpdateLine(int pos, string text);//update a line in a specific position
    int* FindAll(string text);//fiding the lines numbers that contains a specific word

    void FindAndReplace(string oldText, string newText);//find a word and replace it with a new word
    void display();//
    
    
    void storingdata();
     
    //void PutInFile();

    TextEditor();
    ~TextEditor();


};

#endif // TEXTEDITOR_H
