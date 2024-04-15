using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//iet presentation may 4th paper

class AssignData
{
    private StreamReader ifp;
    private string line;
    private int first;
    private bool flag;
    private bool raw;
    private int it = 0;
    private bool found = false;
    private List<Attributes> tests = new List<Attributes>();
    private string temp = "test";

    private string[] idNames = {"Raw_Read_Error_Rate", "Reallocate_NAND_Blk_Cnt", "Program_Fail_Count", "Erase_Fail_Count","Ave_Block-Erase_Count",
    "Unexpect_Power_Loss_Ct", "Unused_Reserve_NAND_Blk", "SATA_Interfac_Downshift", "Error_Correction_Count", "Reported_Uncorrect", "Temperature_Celsius", "Reallocated_Event_Count"
    };
   
   

private string[] allValues = {"value", "worst", "thresh",  "raw_value"
    };


    private string GetString(string input, int counter) 
    { //This takes a line and checks if it has a quotation mark then it will reduce it to a regular string without quotation marks
        first = input.IndexOf("\"", StringComparison.Ordinal);
        if (first < 0)
        { //if it doesn't have a quotation mark then it doesn't contain a data point we want so I return
            return "failed";
        }
        input = input.Substring(first + 1);
        if (counter > 0)//If counter is one then it will get the value after the string declaring what value comes after
        { 
            string place = input.Substring(input.IndexOf("\"", StringComparison.Ordinal) + 3);
            
            return place.Substring(0, place.Length - 1);
        }
        input = input.Substring(0, input.IndexOf("\"", StringComparison.Ordinal));//If counter is zero it will simply return the value without quotation marks
        return input;
    }

    public void NewTest(string name) //Creates a new object from data to store all the values extracted
    {
        Attributes blank = new Attributes();
        blank.SetName(name); //gives it a name for future reference (not used)
        tests.Add(blank);
    }

    public void GetTest(string input) //Gets the object that the user is requesting and sets it to the iterator (also not used)
    {
        for (int i = 0; i < tests.Count; i++)
        {
            if (tests[i].GetName() == input)
            {
                it = i;
            }
        }
    }

  


    public async void PrintTest(int amount, string path)//This prints all the factored data out and factors it into the output file
    {
          System.IO.Directory.CreateDirectory(path);

        using (StreamWriter ofp = new StreamWriter(path+ tests.Last().GetName() + "_output.txt")) //names the output file the name of the main folder_output.txt
        {
            tests.Last().refactor(amount); //Tells the data file to factor all the data points into something more manageable

            for (int i = 0; i < 12; i++) //Repeats this for every class of data points we look at
            {
                ofp.WriteLine(idNames[i] + ","  ); //This prints out the name so you can tell what point means what

                tests.Last().setInt(i); //sets the iterator for the data file so that it knows what class of data we want

                for(int j = 0; j < allValues.Length; j++){
              ofp.WriteLine(allValues[j] + "" + tests.Last().getFactor(allValues[j]));//Requests a string with all the data points for a a single value with all the points
                }
                           
               
            }
            ofp.WriteLine("Drive Health" + tests.Last().getPercentage());
            Console.WriteLine("Saved " + tests.Last().GetName() + " to " + Path.GetFullPath(tests.Last().GetName() + "_output.txt"));
        }
        
        
       
    }

    public void ReadFile(string file)
    {
        ifp = new StreamReader(file);//opens the file

        while (!ifp.EndOfStream)//This just runs until it hits the end of the line
        {
            line = ifp.ReadLine(); //Extracts an entire line from the file
            temp = GetString(line, 0); //Sends a request to get a reduced string from the getString method

            if (found && temp != "id")
            { //If it finds an id that the data class knows then it will enter this found state where it will collect data 
            //while we are in one class of data points
                //Console.WriteLine(temp);

                if(temp == "flags"){//because two strings are named the exact same I have two temporary states
                    flag = true; //That check if a value is under flag or raw so that it doesn't 
                } //conflict with the similarly named variable under another sub class
                else if(flag && temp == "value"){
                    tests.Last().SetValue("flag", GetString(line, 1));
                } else if(temp != "value") { flag = false;}
                if(temp == "raw"){
                    raw = true;
                }
                else if(raw && temp == "value"){
                    tests.Last().SetValue("rawValue", GetString(line, 1));
                } else if(temp != "value" && temp != "string") { raw = false;}

                if (tests.Last().VerifyValue(temp) && !flag && !raw)//checks if the string exists and if it does then it gives data class a data point
                {

                    string val = GetString(line, 1);
                    // if(val.Contains("\"")) {val = "null";}
                    tests.Last().SetValue(temp, GetString(line, 1));
                    //  Console.WriteLine("Good");
                }

                continue;
            }
            else
            {
                found = false;
            }

            temp = new string(temp.Where(c => !char.IsWhiteSpace(c)).ToArray()); //Makes sure that id is going to evaluate to true

            if (temp == "id")
            {
                // Console.WriteLine(temp);
                try
                {
                    if (tests.Last().Selector(int.Parse(GetString(line, 1))) == 0){ //This simply tells the data class what id the class is in                    {
                found = true;
                    }
                }
                catch (Exception e)
                {
                Console.WriteLine("Failed finding value"); //Letting you know something went wrong. This should never trigger
                }
                temp = "not"; //Simply double check that temp doesn't mess anything up by equaling id
                // Console.WriteLine(GetString(line, 1));
                // Console.WriteLine("Success");
            }
        }
        ifp.Close();
    }
}
