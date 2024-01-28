using System;
using System.Collections.Generic;

class Storage
{
    public List<int> Flag { get; } = new List<int>();
    public List<int> Value { get; } = new List<int>();
    public List<int> Worst { get; } = new List<int>();
    public List<int> Thresh { get; } = new List<int>();
    public List<string> Failed { get; } = new List<string>();

    public List<string> Type { get; } = new List<string>();

    public List<string> Updated { get; } = new List<string>();
    public List<int> RawValue { get; } = new List<int>();

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
        else if (variable == "rawValue")
        {
            RawValue.Add(int.Parse(input));
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
        else if (variable == "rawValue")
        {
            return RawValue[count].ToString();
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
    private int it = 0;

    private void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            Storage temp = new Storage();
            aspects.Add(temp);
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
             holder = holder + " " + aspects[0].GetValue(value, count);

        for (int i = 0; i < 12; i++)
        {
            //  holder = holder + aspects[i].GetValue(value, count) + " ";
        }
        return holder;
    }

    public int Size()
    {
        return aspects[0].Value.Count;
    }

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
            175 => 5,
            178 => 6,
            179 => 7,
            181 => 8,
            182 => 9,
            184 => 10,
            187 => 11,
            _ => -1
        };
        if(it == -1){
            return -1;
        }
        return 0;
    }
}

