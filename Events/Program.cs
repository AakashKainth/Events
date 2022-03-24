
using System;

class Program
{
    public static void Main()
    {
        Police police = new Police();
        Fire fire = new Fire();
        Ambulance ambulance = new Ambulance();

        Call911 call911 = new Call911();

        call911.CallForHelp += police.OnCallTo911;
        call911.CallForHelp += fire.OnCallTo911;
        call911.CallForHelp += ambulance.OnCallTo911;

        call911.createNotification("2555 Bristol Circle - Aakash - Help!! - Crazy customers at Home Depot!!!!!");

        Console.ReadLine();
    }
}


public class Police
{
    public void OnCallTo911(object sender, EmergencyInfo e)
    {
        Console.WriteLine("There is a Police call from " + e.address);
    }
}
public class Fire
{
    public void OnCallTo911(object sender, EmergencyInfo e)
    {
        Console.WriteLine("There is a FireCall from " + e.address);
    }
}

public class Ambulance
{
    public void OnCallTo911(object sender, EmergencyInfo e)
    {
        Console.WriteLine("There is a Ambulance call from " + e.address);
    }
}

public class Call911
 {
    public event EmergencyEvent CallForHelp;

    public void createNotification(string msg)
    {
        if (CallForHelp != null)
        {
            CallForHelp(this, new EmergencyInfo(msg));
        }
    }

 }

public delegate void EmergencyEvent(object sender, EmergencyInfo e);

public class EmergencyInfo : EventArgs
{ 
    public string address { get; set; }
    public EmergencyInfo(string Adress)
    {
        address = Adress;
    }
}