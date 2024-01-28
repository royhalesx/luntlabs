#include <iostream>
#include <vector>
#include "parser.h"


//This will manage all of the tests and the read generations

using namespace std;
string job = "138/job.json";

int main(int argc, char * argv[]){
if(argc < 2){
    return 1;
}
assignData par;

par.newTest("driveA");

par.readFile("job6.txt");

// for (int i = 0; i < 2; i++){
// par.readFile(job.insert(7,to_string(i )));

// }

par.printTest();

    return 0;
}