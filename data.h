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

vector<string>  rawString;
vector<int> rawValue;

void setValue(string variable, const string& input){


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
else if( strcmp(variable.c_str(), "rawString")){
    rawString.push_back(input);
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
else if( strcmp(variable.c_str(), "rawString")){
    return rawString.at(count);
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
else if( strcmp(variable.c_str(), "rawString")){
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


