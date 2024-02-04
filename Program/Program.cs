
string job = "138/job.json";

string name = "test";

string path;

int range = 0;

int dataPoints;



AssignData par = new AssignData();

par.NewTest(name);

for (int j = 0; j < 13; j++){
 par.ReadFile("138/job" + j + ".json");

 }

// for(int i = 0; i < range; i++){
//  for (int j = 0; j < 13; j++){
//  par.ReadFile(name + "/" + i + "/job" + j + ".json");

//  }
//  console.WriteLine(i + "/" + range);
// }

 par.PrintTest(6); 

 Console.WriteLine("done");
