// See https://aka.ms/new-console-template for more information

// main();

string job = "138/job.json";

//Add something so that we can say what drives to look through and make it so that it goes through all the folders and yeah

// static void main(string[] args){
AssignData par = new AssignData();

par.NewTest("driveA");

// par.ReadFile("job6.json");

// par.ReadFile("138/job" + 5 + ".json");

 for (int i = 0; i < 13; i++){
 par.ReadFile("138/job" + i + ".json");

 }

 par.PrintTest(); //This simply is printing the test so that we can see what the output looks like

 Console.WriteLine("done");

// }