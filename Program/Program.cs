using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;








int total = 1;


bool diff = false;


Complier obj = new Complier();
Console.WriteLine("How many tests would you like to do today?");
total = int.Parse(Console.ReadLine());
if(total > 1){

Console.WriteLine("If they are all on the same drive please type true with no caps. If they are on differnt type false with no caps");
if(Console.ReadLine() == "false"){
    diff = true;
}

}

obj.collectData(total);

if(diff){
    obj.diffTests(total);
}
else{
    obj.sameDrive(total);
}



 Console.WriteLine("done");

/*

while(count < total){


Console.WriteLine("Please input the path"); 
path = Console.ReadLine(); //Insert the raw path to the file and then the name is stored as a location for the file

if(path.Contains("\"")){ //Sometimes while copying the file I saw that it would contain quotation marks in which case I would just 
path = path.Substring(1, path.Length-2);//exclude them by taking a substring of a couple characters forward and backwards off the string
}

name = path; //This just sets name equal to path and starts off by 

while(name.Contains("\\")){ //This while loop derives the name of the folder to use as the output folder later on and to name the test
name = name.Substring(name.IndexOf("\\")+1);
}

Console.WriteLine(name); //Prints out the name so you know what it assumes is the name of the folder

try{ //This is in a try and catch and if you just click enter it will use the default values
Console.WriteLine("Please input range of folders in the path");
range = int.Parse(Console.ReadLine()); //The range is the amount of subfolders in the main folder

Console.WriteLine("Please input the amount you want the data averaged out");
dataPoints = int.Parse(Console.ReadLine()); //This is the number it divides the data by so 
}
catch(Exception) {Console.WriteLine("Default values have been used: 20 for the dataPoints and 180 for the range");}

count++;
} 

obj.run(name, range, path);
obj.printTest(dataPoints);
*/