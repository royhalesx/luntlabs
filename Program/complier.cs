using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Complier{
//Config Variables
private string file = "Config.txt";

private string[] configs = {"Output path", "inital", "final"};
private string[] convals = {"output", "job0", "job1"};



private void runConfig(){
    string line;
    int count = 0;
StreamReader ifp = new StreamReader(file);//opens the file

        while (!ifp.EndOfStream)//This just runs until it hits the end of the line
        {
            
            line = ifp.ReadLine();

            if(count < configs.Length && line.Contains(configs[count])){
               convals[count] = line.Substring(line.IndexOf(":") + 1);
            }
                //Console.WriteLine(convals[0]);

            count++;

        }


}


private List<string> names  { get; } = new List<string>();

private List<string> paths  { get; }= new List<string>();


private AssignData par = new AssignData();
private int dataPoints;




public void collectData(int total){
int count = 0;
string temp;
string nameTemp;
runConfig();

Console.WriteLine("Please input the amount you want the data averaged out for all drives");
dataPoints = int.Parse(Console.ReadLine()); //This is the number it divides the data by so 

while(count < total){


Console.WriteLine("Please input the path of drive " + count); 
temp = Console.ReadLine();//Insert the raw path to the file and then the name is stored as a location for the file

if(temp.Contains("\"")){ //Sometimes while copying the file I saw that it would contain quotation marks in which case I would just 
temp = temp.Substring(1, temp.Length-2);//exclude them by taking a substring of a couple characters forward and backwards off the string
}

nameTemp = temp; //This just sets name equal to path and starts off by 

while(nameTemp.Contains("\\")){ //This while loop derives the name of the folder to use as the output folder later on and to name the test
nameTemp = nameTemp.Substring(nameTemp.IndexOf("\\")+1);
}
names.Add(nameTemp);
paths.Add(temp);

Console.WriteLine(names[count]); //Prints out the name so you know what it assumes is the name of the folder
count++;
}
}



public void run(string name, string path){
    


try{ //The try makes sure the file exists in an easier way
    

 par.ReadFile(path + "\\" + convals[1] + ".json");
 par.ReadFile(path + "\\" + convals[2] + ".json");


 Console.WriteLine("Done with test "+  name);//A progress bar of sorts telling you how long it will take
}
catch(Exception e){ //if it fails it reports what folder it couldn't open
    Console.WriteLine("Cannot open file for test " + name);
}

}



public void diffTests(int total){
    for(int i = 0; i < total; i++){
par.NewTest(names[i]); //Makes a new object and names it test


        run(names[i], paths[i]);
        printTest();
        Console.WriteLine("Done with Tests " + names[i]);
    }

}


public void sameDrive(int total){
    par.NewTest(names[0]);
for(int i = 0; i < total; i++){
        run(names[i], paths[i]);
        Console.WriteLine("Done with Test " + i);

    }

        printTest();

}


public void printTest(){
 par.PrintTest(dataPoints, "Output\\"); //This takes all the data collected and divides and formats it in a way that will be easy to graph

}

}