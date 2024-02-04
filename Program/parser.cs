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

private string[] allValues = {"value", "worst", "thresh", "when_failed", "flag", "string", "prefailure", 
"updated_online", "performance", "error_rate", 
    "event_count", "raw_value"
    };


    private string GetString(string input, int counter)
    {
        first = input.IndexOf("\"", StringComparison.Ordinal);
        if (first < 0)
        {
            return "failed";
        }
        input = input.Substring(first + 1);
        if (counter > 0)
        { 
            string place = input.Substring(input.IndexOf("\"", StringComparison.Ordinal) + 3);
            
            return place.Substring(0, place.Length - 1);
        }
        input = input.Substring(0, input.IndexOf("\"", StringComparison.Ordinal));
        return input;
    }

    public void NewTest(string name)
    {
        Attributes blank = new Attributes();
        blank.SetName(name);
        tests.Add(blank);
    }

    public void GetTest(string input)
    {
        for (int i = 0; i < tests.Count; i++)
        {
            if (tests[i].GetName() == input)
            {
                it = i;
            }
        }
    }

    //Add some sort of a method to make it easier to interpret all this data and output it

  


    public async void PrintTest(int amount)
    {
           
        using (StreamWriter ofp = new StreamWriter(tests.Last().GetName() + "_output.txt"))
        {
            tests.Last().refactor(amount);

            for (int i = 0; i < 12; i++) //12
            {
                ofp.WriteLine("**** *****" + idNames[i] + "**** *****"  );

                tests.Last().setInt(i);
            //  ofp.WriteLine(tests.Last().getFactor("value")+"\n" );

                for(int j = 0; j < allValues.Length; j++){
           //  ofp.WriteLine(allValues[j] + ": " + tests.Last().getFactor("value"));
              ofp.WriteLine(allValues[j] + ": " + tests.Last().getFactor(allValues[j]));

        
                }

            }
    


        }
        
    }

    public void ReadFile(string file)
    {
        ifp = new StreamReader(file);
        // if(!){
        //     Console.WriteLine("Couldn't open " + file);}

        while (!ifp.EndOfStream)
        {
            line = ifp.ReadLine();
            temp = GetString(line, 0);

            if (found && temp != "id")
            {
                //Console.WriteLine(temp);

                if(temp == "flags"){
                    flag = true;
                }
                else if(flag && temp == "value"){
                    tests.Last().SetValue("flag", GetString(line, 1));
                } else if(temp != "value") { flag = false;}
                if(temp == "raw"){
                    raw = true;
                }
                else if(raw && temp == "value"){
                    tests.Last().SetValue("rawValue", GetString(line, 1));
                } else if(temp != "value" && temp != "string") { raw = false;}

                if (tests.Last().VerifyValue(temp) && !flag && !raw)
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

            temp = new string(temp.Where(c => !char.IsWhiteSpace(c)).ToArray());

            if (temp == "id")
            {
                // Console.WriteLine(temp);
                try
                {
                    if (tests.Last().Selector(int.Parse(GetString(line, 1))) == 0)
                    {
                found = true;
                    }
                }
                catch (Exception e)
                {

                }
                temp = "not";
                // Console.WriteLine(GetString(line, 1));
                // Console.WriteLine("Success");
            }
        }
        ifp.Close();
    }
}
