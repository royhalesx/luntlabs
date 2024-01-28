using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

    public void PrintTest()
    {
        using (StreamWriter ofp = new StreamWriter("output.txt"))
        {
            //string holder = "";
            for (int i = 0; i < tests[it].Size(); i++)
            {
                ofp.WriteLine("Test " + i  +" \n");

                ofp.WriteLine(tests[it].GetAll("value", i));
                ofp.WriteLine(tests[it].GetAll("worst", i));
                ofp.WriteLine(tests[it].GetAll("thresh", i));
                ofp.WriteLine(tests[it].GetAll("when_failed", i));
                ofp.WriteLine(tests[it].GetAll("flag", i));
                
               ofp.WriteLine(tests[it].GetAll("string", i));
               ofp.WriteLine(tests[it].GetAll("prefailure", i));

               ofp.WriteLine(tests[it].GetAll("updated_online", i));
                ofp.WriteLine(tests[it].GetAll("prefailure", i));
                ofp.WriteLine(tests[it].GetAll("performance", i));
                ofp.WriteLine(tests[it].GetAll("error_rate", i));
                ofp.WriteLine(tests[it].GetAll("event_count", i));


                ofp.WriteLine(tests[it].GetAll("rawValue", i));
            }
        }
        
    }

    public void ReadFile(string file)
    {
        ifp = new StreamReader(file);

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
