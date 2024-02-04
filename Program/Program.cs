
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
name = path.Substring(path.IndexOf("/"));
while(name.Contains("/")){
name = path.Substring(name.IndexOf("/"));

}

Console.WriteLine(name);

// Console.WriteLine("Please input range of folders in the path");

// Console.WriteLine("Please input the amount you want the data averaged out");




// par.NewTest(name);


// for(int i = 0; i < range; i++){
    
// try{
    

//  for (int j = 0; j < 13; j++){
//  par.ReadFile(path + name + "/" + i + "/job" + j + ".json");

//  }
//  console.WriteLine(i + "/" + range);
// }
// catch(Exception e){
//     Console.WriteLine("Cannot open folder " + i);
// }
// }

//  par.PrintTest(6); 

//  Console.WriteLine("done");
