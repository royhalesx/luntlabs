using System;
using System.Collections.Generic;


//store data on a file so we can get it without running this every single time

//Return an entire vector for every test without passing the entire vector across classes

//use pointers to optimize?

class Storage
{
    public List<int> Flag { get; } = new List<int>();
    public List<int> Value { get; } = new List<int>();
    public List<int> Worst { get; } = new List<int>();
    public List<int> Thresh { get; } = new List<int>();
    public List<string> Failed { get; } = new List<string>();

    public List<string> Type { get; } = new List<string>();

    public List<string> Updated { get; } = new List<string>();
    public List<double> RawValue { get; } = new List<double>();

    public List<string> preFail { get; } = new List<string>();
    public List<string> performance { get; } = new List<string>();
    public List<string> errorRate { get; } = new List<string>();
    public List<string> eventCount { get; } = new List<string>();
    

    public void SetValue(string variable, string input)
    {
        // Console.WriteLine("Setting values");


        if (variable == "flag")
        {
            Flag.Add(int.Parse(input));
        }
        else if (variable == "value")
        {
            Value.Add(int.Parse(input));
        }
        else if (variable.Contains("worst"))
        {
            Worst.Add(int.Parse(input));
        }
        else if (variable == "thresh")
        {
            Thresh.Add(int.Parse(input));
        }
        else if (variable == "string")
        {
            Type.Add(input);
        }
        else if (variable == "updated_online")
        {
            Updated.Add(input);
        }
        else if (variable == "when_failed")
        {
            Failed.Add(input);
        }
        else if (variable == "prefailure")
        {
            preFail.Add(input);
        }
        else if (variable == "performance")
        {
            performance.Add(input);
        }
        else if (variable == "error_rate")
        {
            errorRate.Add(input);
        }
        else if (variable == "event_count")
        {
            eventCount.Add(input);
        }
        else if (variable == "raw_value" || variable == "rawValue")
        {
            RawValue.Add(double.Parse(input));
        }
        else {
        //  Console.WriteLine("bad");
        }
    }

    public string GetValue(string variable, int count)
    {

        if (variable == "flag")
        {
            return Flag[count].ToString();
        }
        else if (variable == "value")
        {
            return Value[count].ToString();
        }
        else if (variable == "worst")
        {
            return Worst[count].ToString();
        }
        else if (variable == "thresh")
        {
            return Thresh[count].ToString();
        }
        else if (variable == "string")
        {
            return Type[count];
        }
        else if (variable == "updated_online")
        {
            return Updated[count];
        }
        else if (variable == "when_failed")
        {
            return Failed[count];
        }
        else if (variable == "raw_value"    || variable == "rawValue")
        {
            // Console.WriteLine(count + " " + RawValue.Count);
            return  RawValue[count].ToString();
        }
        else if (variable == "prefailure")
        {
           return preFail[count];
        }
        else if (variable == "performance")
        {
           return performance[count];

        }
        else if (variable == "error_rate")
        {
           return errorRate[count];

        }
        else if (variable == "event_count")
        {
           return eventCount[count];

        }
        else
        {
            Console.WriteLine(variable);

            return "variable name mismatch";
        }
    }

    public bool Verify(string variable)
    {
        return variable switch
        {
            "flag" => true,
            "value" => true,
            "thresh" => true,
            "worst" => true,
            "string" => true,
            "updated_online" => true,
            "when_failed" => true,
            "raw_value" => true,
            "rawValue" => true,
            "prefailure"=> true,
            "performance"=> true,
            "error_rate"=> true,
            "event_count"=> true,
            _ => false
        };
    }
}

class Attributes
{
    private string name = "none";
    private List<Storage> aspects = new List<Storage>();
    private List<Storage> factored = new List<Storage>();
    private Dictionary<string, int> stringValues;

private string[] allInts = {"value", "worst", "thresh",  "flag",  "raw_value"
    };
private string[] allBools = {"prefailure", "when_failed",
"updated_online", "performance", "error_rate", 
    "event_count"};

    private int extra;
    private int it = 0;

    private void refactorString(int amount){
        int total = 0;

  for(int j = 0; j < Size(); j++){
if((1+j)%amount == 0){
    factored[it].SetValue("string", aspects[it].GetValue("string", j));

    total = 0;
}
  }


    }   

private void refactorBool(string value,int amount){
        int total = 0;

  for(int j = 0; j < Size(); j++){
if((1+j)%amount == 0){
    factored[it].SetValue(value, aspects[it].GetValue(value, j));

    total = 0;
}
}


    }   


    private void refactorInt(string value,int amount){
        double total = 0;

  for(int j = 0; j < Size(); j++){
total += double.Parse( aspects[it].GetValue(value, j));

  
   
if((1+j)%amount == 0){
    factored[it].SetValue(value,"" + Math.Ceiling((double) total/amount));

    total = 0;
}


            }


    } 


    private void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            Storage temp = new Storage();
            Storage factorTemp = new Storage();

            aspects.Add(temp);
            factored.Add(factorTemp);
        }
    }

    public void SetValue(string name, string value)
    {
        aspects[it].SetValue(name, value);
    }

    public string GetValue(string variable, int count)
    {
        return aspects[it].GetValue(variable, count);
    }

    public string GetAll(string value, int count)
    {
        string holder = " ";

        for (int i = 0; i < 12; i++)
        {
             holder = holder + aspects[i].GetValue(value, count) + " ";
        }
        return holder;
    }




//Factoring

    
    public string getFactor(string value)
    {
        string holder = "";
        for (int i = 0; i < factoredSize(); i++)
        {

             holder = holder + factored[it].GetValue(value, i) + " ";
        }
        return holder;


    }
    

    
   
    public int Size()
    {
        return aspects[0].Value.Count;
    }

public int factoredSize()
    {
        return factored[0].Value.Count;
    }
   
    public void refactor(int amount){ //make this factor everything
        // System.WriteLine("Made it here");
         extra = Size()%amount;
        it = 0; 
        refactorInt("value", amount);

         for(int i = 0; i < 12; i++){
        refactorString(amount);
// foreach(string l in allInts){
//     // Console.WriteLine(aspects[it].Value.Count);
//     refactorInt(l, amount);
// }

// foreach(string k in allBools){
//     refactorBool(k, amount);
// }


         }
        
    }



//Identitity
    public void SetName(string input)
    {
        name = input;
        if (aspects.Count < 2)
        {
            Start();
        }
    }

    public string GetName()
    {
        return name;
    }

    public bool VerifyValue(string value)
    {
        return aspects[it].Verify(value);
    }



    public void setInt(int id){
        it = id;
    }


    public int Selector(int id)
    {
        // Console.WriteLine("selecting" + id);

        it = id switch
        {
            1 => 0,
            5 => 1,
            171 => 2,
            172 => 3,
            173 => 4,
            174 => 5,
            180 => 6,
            183 => 7,
            184 => 8,
            187 => 9,
            194 => 10,
            196 => 11,
            _ => -1
        };
        if(it == -1){
            return -1;
        }
        return 0;
    }
}

