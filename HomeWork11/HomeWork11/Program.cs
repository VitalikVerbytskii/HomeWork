using System;


public interface IRadio
{
    void TurnOn();
    void TurnOff();
    void IncreaseVolume();
    void ReduceVolume();
    public abstract void VolumeM();
    public abstract void VolumeP();
}


public interface ISeats
{

    void AdjustPosition();
    void HeatOn();
    void HeatOff();




}

public abstract class Car
{
    protected int speed;
    protected int volume;
    protected int seatTilt = 90;
    public abstract void ReclineSeats();
    public abstract void AlignSeats();
    public abstract void Accelerate();
    public abstract void Brake();
    public abstract void ChangeStation();
    public int GetSeatTilt()
    {
        return seatTilt;
    }
    public int GetSpeed()
    {
        return speed;
    }
    public int GetVolume()
    {
        return volume;
    }
    public void TurnOn()
    {
        Console.WriteLine("The radio is on.");
    }
    public void TurnOff()
    {
        Console.WriteLine("The radio is off.");
    }
    public void IncreaseVolume()
    {
        Console.WriteLine("Increase the volume of the radio.");
    }
    public void ReduceVolume()
    {
        Console.WriteLine("Reduce the volume of the radio.");
    }
    public void AdjustPosition()
    {
        Console.WriteLine("Adjusting the position of the seats: 1-Align the seats, 2-Recline the seats");
    }
    public void HeatOn()
    {
        Console.WriteLine("Seat heating is on.");
    }
    public void HeatOff()
    {
        Console.WriteLine("Seat heating is off.");
    }
    public void VolumeM()
    {
        volume -= 2;
        if (volume < 0)
        {
            volume = 0;
        }
    }
    public void VolumeP()
    {
        volume += 2;
        if (volume >= 10)
        {
            volume = 10;
        }
    }
}
public class BMW : Car, IRadio, ISeats
{
    public override void Accelerate()
    {
        speed += 19;
        if (speed >= 310)
        {
            speed = 310;
        }
    }
    public override void Brake()
    {
        speed -= 5;
        if (speed < 0)
        {
            speed = 0;
        }
    }
    public override void AlignSeats()
    {
        seatTilt -= 18;
        if (seatTilt < 90)
        {
            seatTilt = 90;
        }
    }
    public override void ReclineSeats()
    {
        seatTilt += 15;
        if (seatTilt > 170)
        {
            seatTilt = 170;
        }
    }
    public override void ChangeStation()
    {

        Console.WriteLine("Choose the radio station: 1-98 FM, 2-98.5 FM, 3-99 FM, 4-99.5 FM");
        string H = Console.ReadLine();
        switch (H)
        {
            case "1":
                Console.WriteLine("98 FM");
                break;
            case "2":
                Console.WriteLine("98.5 FM");
                break;
            case "3":
                Console.WriteLine("99 FM");
                break;
            case "4":
                Console.WriteLine("99.5 FM");
                break;
        }
    }
}
public class AUDI : Car, IRadio, ISeats
{
    public override void Accelerate()
    {
        speed += 17;
        if (speed >= 290)
        {
            speed = 290;
        }
    }
    public override void Brake()
    {
        speed -= 4;
        if (speed < 0)
        {
            speed = 0;
        }
    }
    public override void AlignSeats()
    {
        seatTilt -= 15;
        if (seatTilt < 90)
        {
            seatTilt = 90;
        }
    }
    public override void ReclineSeats()
    {
        seatTilt += 15;
        if (seatTilt > 160)
        {
            seatTilt = 160;
        }
    }
    public override void ChangeStation()
    {
        Console.WriteLine("Choose the radio station: 1-68 FM, 2-78.5 FM, 3-93.5 FM, 4-98.4 FM, 5-105.4 FM");
        string H = Console.ReadLine();
        switch (H)
        {
            case "1":
                Console.WriteLine("68 FM");
                break;
            case "2":
                Console.WriteLine("78.5 FM");
                break;
            case "3":
                Console.WriteLine("93.5 FM");
                break;
            case "4":
                Console.WriteLine("98.4 FM");
                break;
            case "5":
                Console.WriteLine("105.4 FM");
                break;
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Car bmw = new BMW();
        Car audi = new AUDI();
        Console.WriteLine("Choose car: 1-BMW or 2-Audi ");
        string carChoice = Console.ReadLine();
        Console.WriteLine();

        while (true)
        {
            if (carChoice != "1" && carChoice != "2")
            {
                carChoice = null;
                Console.WriteLine("Choose car: 1-BMW or 2-Audi ");
                carChoice = Console.ReadLine();
            }
            if (carChoice == "1")
            {
                Console.WriteLine("Choose action: 1-Accelerate, 2-Brake, 3-TurnOnRadio, 4-TurnOffRadio, 5-ChangeRadioStation, 6-IncreaseRadioVolume, 7-ReduceVolume, 8-ReclineSeats, 9-AlignSeats, 10-TurnOnSeatHeat, 11-TurnOffSeatHeat, 12-Change car");
                string actionChoice = Console.ReadLine();
                Console.WriteLine();
                switch (actionChoice)
                {
                    case "1":
                        bmw.Accelerate();
                        Console.WriteLine("The speed of BMW: " + bmw.GetSpeed());
                        Console.WriteLine();
                        break;
                    case "2":
                        bmw.Brake();
                        Console.WriteLine("The speed of BMW: " + bmw.GetSpeed());
                        Console.WriteLine();
                        break;
                    case "3":
                        ((IRadio)bmw).TurnOn();
                        Console.WriteLine();
                        break;
                    case "4":
                        ((IRadio)bmw).TurnOff();
                        Console.WriteLine();
                        break;
                    case "5":
                        bmw.ChangeStation();
                        Console.WriteLine();
                        break;
                    case "6":
                        ((IRadio)bmw).IncreaseVolume();
                        bmw.VolumeP();
                        Console.WriteLine(bmw.GetVolume());
                        Console.WriteLine();
                        break;
                    case "7":
                        ((IRadio)bmw).ReduceVolume();
                        bmw.VolumeM();
                        Console.WriteLine(bmw.GetVolume());
                        Console.WriteLine();
                        break;
                    case "8":
                        ((ISeats)bmw).AdjustPosition();
                        bmw.ReclineSeats();
                        Console.WriteLine(bmw.GetSeatTilt() + "°");
                        Console.WriteLine();
                        break;
                    case "9":
                        ((ISeats)bmw).AdjustPosition();
                        bmw.AlignSeats();
                        Console.WriteLine(bmw.GetSeatTilt() + "°");
                        Console.WriteLine();
                        break;
                    case "10":
                        ((ISeats)bmw).HeatOn();
                        Console.WriteLine();
                        break;
                    case "11":
                        ((ISeats)bmw).HeatOff();
                        Console.WriteLine();
                        break;
                    case "12":
                        carChoice = null;
                        bmw = new BMW();
                        Console.WriteLine("Choose car: 1-BMW or 2-Audi ");
                        carChoice = Console.ReadLine();
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.WriteLine();
                        break;
                }
            }
            else if (carChoice == "2")
            {
                Console.WriteLine("Choose action: 1-Accelerate, 2-Brake, 3-TurnOnRadio, 4-TurnOffRadio, 5-ChangeRadioStation, 6-IncreaseRadioVolume, 7-ReduceVolume, 8-ReclineSeats, 9-AlignSeats, 10-TurnOnSeatHeat, 11-TurnOffSeatHeat, 12-Change car");
                string actionChoice = Console.ReadLine();
                Console.WriteLine();
                switch (actionChoice)
                {
                    case "1":
                        audi.Accelerate();
                        Console.WriteLine("The speed of Audi: " + audi.GetSpeed());
                        Console.WriteLine();
                        break;
                    case "2":
                        audi.Brake();
                        Console.WriteLine("The speed of Audi: " + audi.GetSpeed());
                        Console.WriteLine();
                        break;
                    case "3":
                        ((IRadio)audi).TurnOn();
                        Console.WriteLine();
                        break;
                    case "4":
                        ((IRadio)audi).TurnOff();
                        Console.WriteLine();
                        break;
                    case "5":
                        audi.ChangeStation();
                        Console.WriteLine();
                        break;
                    case "6":
                        ((IRadio)audi).IncreaseVolume();
                        audi.VolumeP();
                        Console.WriteLine(audi.GetVolume());
                        Console.WriteLine();
                        break;
                    case "7":
                        ((IRadio)audi).ReduceVolume();
                        audi.VolumeM();
                        Console.WriteLine(audi.GetVolume());
                        Console.WriteLine();
                        break;
                    case "8":
                        ((ISeats)audi).AdjustPosition();
                        audi.ReclineSeats();
                        Console.WriteLine(audi.GetSeatTilt() + "°");
                        Console.WriteLine();
                        break;
                    case "9":
                        ((ISeats)audi).AdjustPosition();
                        audi.AlignSeats();
                        Console.WriteLine(audi.GetSeatTilt() + "°");
                        Console.WriteLine();
                        break;
                    case "10":
                        ((ISeats)audi).HeatOn();
                        Console.WriteLine();
                        break;
                    case "11":
                        ((ISeats)audi).HeatOff();
                        Console.WriteLine();
                        break;
                    case "12":
                        carChoice = null;
                        audi = new AUDI();
                        Console.WriteLine("Choose car: 1-BMW or 2-Audi ");
                        carChoice = Console.ReadLine();
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}

