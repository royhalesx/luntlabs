string name = "test";

string path;

int range = 180;

int dataPoints = 20;



AssignData par = new AssignData();



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



par.NewTest(name); //Makes a new object and names it test


for(int i = 1; i < range+1; i++){ //This just finds every single file and sends it into the parser file to extract the data
    
try{ //The try makes sure the file exists in an easier way
    

 for (int j = 0; j < 13; j++){
 par.ReadFile(path + "\\" + i + "\\job" + j + ".json");

 }
 Console.WriteLine(i + "/" + range);//A progress bar of sorts telling you how long it will take
}
catch(Exception e){ //if it fails it reports what folder it couldn't open
    Console.WriteLine("Cannot open folder " + i);
}
}

 par.PrintTest(dataPoints); //This takes all the data collected and divides and formats it in a way that will be easy to graph

 Console.WriteLine("done");
