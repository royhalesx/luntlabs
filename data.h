#include <iostream>
#include <cstring>
#include <string>
#include <vector>
using namespace std;


//this is for making an object with all the data from a singular read

//individual objects of each variable

class storage{
public:

vector<string> flag;
vector<int> value;
vector<int> worst;
vector<int> thresh;
vector<string>  type;
vector<string>  updated;
vector<string>  failed;

vector<int> rawValue;




void setValue(string variable, const string& input){

// cout << "Setting values" << endl;

if( strcmp(variable.c_str(), "flag")){
    flag.push_back(input);
}
else if( strcmp(variable.c_str(), "value")){
    value.push_back(stoi(input));
    
}
else if( strcmp(variable.c_str(), "thresh")){
    thresh.push_back(stoi(input));
    
}
else if( strcmp(variable.c_str(), "type")){
    type.push_back(input);
    
}
else if( strcmp(variable.c_str(), "updated")){
    updated.push_back(input);
    
}
else if( strcmp(variable.c_str(), "when_failed")){
    failed.push_back(input);
    
}
else if( strcmp(variable.c_str(), "rawValue")){
    rawValue.push_back(stoi(input));
}



}

string getValue(string variable, int count){


if( strcmp(variable.c_str(), "flag")){
    return flag.at(count);
}
else if( strcmp(variable.c_str(), "value")){
    return "" + value.at(count);

    
}
else if( strcmp(variable.c_str(), "thresh")){
    return "" + thresh.at(count);
    
}
else if( strcmp(variable.c_str(), "type")){
    return type.at(count);
    
}
else if( strcmp(variable.c_str(), "updated")){
    return updated.at(count);
    
}
else if( strcmp(variable.c_str(), "when_failed")){
    return failed.at(count);
    
}
else if( strcmp(variable.c_str(), "rawValue")){
    return "" + rawValue.at(count);
}
else {
    return "variable name mismatch";
}
}
bool verify(string variable){

if( strcmp(variable.c_str(), "flag")){
    return true;
}
else if( strcmp(variable.c_str(), "value")){
    return true;

    
}
else if( strcmp(variable.c_str(), "thresh")){
    return true;
    
}
else if( strcmp(variable.c_str(), "type")){
    return true;
    
}
else if( strcmp(variable.c_str(), "updated")){
    return true;
    
}
else if( strcmp(variable.c_str(), "when_failed")){
    return true;
    
}

else if( strcmp(variable.c_str(), "rawValue")){
    return true;
}
else {
    return false;
}
}
};



class attributes{
private:
string name;

vector<storage> aspects;

int it = 0;

void start(){
for(int i = 0; i < 12; i++){
    storage temp;
    aspects.push_back(temp);
}

}

public:

void setValue(string name, string value){
aspects.at(it).setValue(name, value);

}

void getValue(string variable, int count){
aspects.at(it).getValue(variable, count);

}

string getAll(string value, int count){
    string holder;
for (int i =0; i < aspects.size(); i++){
holder += " " + aspects.at(i).getValue(value, count);
}
return holder;

}

int size(){
    return aspects.front().value.size();
}
void setName(string input){
name = input;
if(aspects.size() < 2){
    start();
}
}

string getName(){
    return name;
}

bool verifyValue(string value){
return aspects.at(it).verify(value);

}

int selector(int id){
// cout << "selecting" << endl;

switch(id){

case 1:
it = 0;
return 0;
break;


case 5:
it = 2;
return 0;
break;

case 171:
it = 3;
return 0;
break;

case 172:
it = 4;
return 0;
break;

case 173:
it = 5;
return 0;
break;

case 175:
it = 6;
return 0;
break;

case 178:
it = 6;
return 0;
break;

case 179:
it = 7;
return 0;
break;

case 181:
it = 8;
return 0;
break;

case 182:
it = 9;
return 0;
break;

case 184:
it = 10;
return 0;
break;

case 187:
it = 11;
return 0;
break;
}

return -1;
}


};
