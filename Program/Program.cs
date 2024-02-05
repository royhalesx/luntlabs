
string job = "138/job.json";

string name = "test";

string path;

int range = 0;

int dataPoints;



AssignData par = new AssignData();


// for (int j = 0; j < 13; j++){
//  par.ReadFile("138/job" + j + ".json");

//  }

Console.WriteLine("Please input the path");
path = Console.ReadLine();

if(path.Contains("\"")){
path = path.Substring(1, path.Length-2);
}

name = path.Substring(path.IndexOf("\\")+1);
// Console.WriteLine(name);
while(name.Contains("\\")){
name = name.Substring(name.IndexOf("\\")+1);
// Console.WriteLine(name);
}

Console.WriteLine(name);

Console.WriteLine("Please input range of folders in the path");
range = int.Parse(Console.ReadLine());

Console.WriteLine("Please input the amount you want the data averaged out");
dataPoints = int.Parse(Console.ReadLine());




par.NewTest(name);


for(int i = 1; i < range+1; i++){
    
try{
    

 for (int j = 0; j < 13; j++){
 par.ReadFile(path + "\\" + i + "\\job" + j + ".json");

 }
 Console.WriteLine(i + "/" + range);
}
catch(Exception e){
    Console.WriteLine("Cannot open folder " + i);
}
}

 par.PrintTest(dataPoints); 

 Console.WriteLine("done");
