#include <iostream>
#include <string>
#include <cstring>
#include <vector>
#include <sstream>
#include <fstream>
#include "data.h"



//this servers two functions

//This will read the data all from one drive read and then store it into an object made from data.h

//This will hold 1 drive throughout all the reads it undergoes



class assignData{
private:

ifstream ifp;
string line;
//ofstream ofp(output); // ofp << string;

int first;
int it;

bool found = false;

vector<attributes> tests;


string temp;

string getString(string input, int counter){
   first = input.find("\"");
    if(first < 0 && counter == 0){
        return "failed";
    }
    input = input.substr(first+1);
     if (counter > 0){
       // cout << input << endl;
       string place = input.substr(input.find("\"")+ 3);
        return place.substr(0, place.length()-1);
    }
   input = input.substr(0, input.find("\""));
   return input;
}



public:

void newTest(string name){
attributes blank;
blank.setName(name);
tests.push_back(blank);
}


void getTest(string input){
    for(int i = 0; i < tests.size(); i++){
        if (tests.at(i).getName() == input){
           int it = i;
        }
    }
}
void printTest(){
    ofstream ofp("output.txt");
    string holder;
    for (int i = 0; i < tests.at(it).size()-1; i++){
        cout << tests.at(it).getAll("Value", i);
    }

}



void readFile(string file){
ifp.open(file);


while(!ifp.eof()){
getline(ifp, line);
    istringstream iss(line);
    
    if (found && temp != "id"){
    temp = getString(line, 0);

    if(tests.back().verifyValue(temp)){
        tests.back().setValue(temp, getString(line, 1));
    }

        continue;
    }
    else {found = false;}

// && tests.back().selector(stoi(getString(line, 1))) == 0

    temp = getString(line, 0);
    cout << line.find("id") << endl;
if(temp == "id"){
    cout << temp << endl;
   // cout << getString(line, 1) << endl;
// cout << "Success";
// found = true;

}

}

ifp.close();

}



};

