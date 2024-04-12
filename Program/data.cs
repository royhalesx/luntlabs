using System;
using System.Collections.Generic;
using System.Linq;


//store data on a file so we can get it without running this every single time

//Return an entire vector for every test without passing the entire vector across classes

//use pointers to optimize?

class Storage
{
    private List<int> Flag { get; } = new List<int>();
    public List<int> Value { get; } = new List<int>();
    public List<int> Worst { get; } = new List<int>();
    public List<int> Thresh { get; } = new List<int>();
    public List<double> RawValue { get; } = new List<double>();
    public List<double> percentage { get; } = new List<double>();

    

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
        else if (variable == "raw_value" || variable == "rawValue")
        {
            RawValue.Add(double.Parse(input));
        }
        else if (variable == "percentage" || variable == "percent")
        {
            percentage.Add(double.Parse(input));
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
        else if (variable == "raw_value"    || variable == "rawValue")
        {
            // Console.WriteLine(count + " " + RawValue.Count);
            return  RawValue[count].ToString();
        }
          else if (variable == "percentage" || variable == "percent")
        {
           return percentage[count].ToString();
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
            "raw_value" => true,
            "rawValue" => true,
            _ => false
        };
    }
}

class Attributes
{
    private string name = "none";
    private List<Storage> aspects = new List<Storage>();
    private List<Storage> factored = new List<Storage>();

double totalPercent;
int divide;
    

private string[] allInts = {"value", "worst", "thresh",  "flag",  "raw_value"
    };

    private int[] weight = {1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1}; //This is what decides how much weight each value has on drive health


    private int extra;
    private int it = 0;


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
    public void addPercentage(int count){
        double x = 100- double.Parse(factored[it].GetValue("thresh", count));
        double y = double.Parse(factored[it].GetValue("value", count)) - double.Parse(factored[it].GetValue("thresh", count)); //maybe change this to worst?
    factored[it].SetValue("percentage","" + (y/x*100));
    }
    public string getPercentage(){
string holder = "";
        // Console.WriteLine(factoredSize());
        for (int i = 0; i < factoredSize(); i++)
        {
            for(int j =0; j < 12; j++){
             totalPercent += double.Parse(factored[j].GetValue("percentage", i)) * weight[j];
             divide += weight[j];

            }
            totalPercent = (totalPercent/divide);
             holder += "," + totalPercent + "%";
             totalPercent = 0;
             divide = 0;
        }
        return holder;

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


    public int Size()
    {
        return aspects[0].Value.Count;
    }




//Factoring

   


    private void refactorInt(string value,int amount){
        double total = 0;
// Console.WriteLine("1");


  for(int j = 1; j < Size()+1; j++){
total += double.Parse( aspects[it].GetValue(value, j-1));

  
                
                if(((j)%amount) == 0){

                // Console.WriteLine(value + " " + it);

                    factored[it].SetValue(value,"" + Math.Ceiling((double) total/amount));

                    total = 0;
                }



            }

    } 
 
    
   

    
    public string getFactor(string value)
    {
        string holder = "";
        // Console.WriteLine(factoredSize());
        for (int i = 0; i < factoredSize(); i++)
        {
            addPercentage(i);

             holder = holder+ "," + factored[it].GetValue(value, i);
  
             
        }
        return holder;


    }
    


public int factoredSize()
    {
        return factored[0].Value.Count;
    }
   
    public void refactor(int amount){ //make this factor everything
        // System.WriteLine("Made it here");

         extra = Size()%amount;

         for(int i = 0; i < 12; i++){

        it = i;
        

foreach(string j in allInts){
    // Console.WriteLine(it);
    refactorInt(j, amount);
}



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

