using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Complier{


private List<string> names  { get; } = new List<string>();

private List<string> paths  { get; }= new List<string>();

private List<int> ranges { get; } = new List<int>();

private AssignData par = new AssignData();
private int dataPoints;

public void run(string name, int range, string path){
    


for(int i = 1; i < range+1; i++){ //This just finds every single file and sends it into the parser file to extract the data
    
try{ //The try makes sure the file exists in an easier way
    

 for (int j = 0; j < 13; j++){
 par.ReadFile(path + "\\" + i + "\\job" + j + ".json");

 }
 Console.WriteLine(i + "/" + range + " Folders in test " + name);//A progress bar of sorts telling you how long it will take
}
catch(Exception e){ //if it fails it reports what folder it couldn't open
    Console.WriteLine("Cannot open folder " + i);
}
}

}


public void collectData(int total){
int count = 0;
string temp;
string nameTemp;


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

try{ //This is in a try and catch and if you just click enter it will use the default values
Console.WriteLine("Please input range of folders in the path in drive " + count);
ranges.Add(int.Parse(Console.ReadLine())); //The range is the amount of subfolders in the main folder

}
catch(Exception) {Console.WriteLine("Default values have been used: 20 for the dataPoints and 180 for the range");}

count++;
} 
}

public void diffTests(int total){
    for(int i = 0; i < total; i++){
par.NewTest(names[i]); //Makes a new object and names it test

        run(names[i], ranges[i], paths[i]);
        printTest();
        Console.WriteLine("Done with Tests " + names[i]);
    }

}


public void sameDrive(int total){
    par.NewTest(names[0]);
for(int i = 0; i < total; i++){
        run(names[i], ranges[i], paths[i]);
        Console.WriteLine("Done with Test " + i);

    }

        printTest();

}


public void printTest(){
 par.PrintTest(dataPoints); //This takes all the data collected and divides and formats it in a way that will be easy to graph

}

}