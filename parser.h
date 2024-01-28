#include <iostream>
#include <string>
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




public:

void readFile(string file){
ofstream ofp("output.txt");
ifp.open(file);


while(!ifp.eof()){
getline(ifp, line);
   
    istringstream iss(line);
    
    int first ;

   if(line.find("\"")){
   }

}


ifp.close();

}



};

