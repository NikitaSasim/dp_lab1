using lab1;
using lab1.lab3_3;

//partial 1
var a = TimeStampSingleton.GetInstance();
Thread.Sleep(1000);

var b = TimeStampSingleton.GetInstance();
Thread.Sleep(1000);

var c = TimeStampSingleton.GetInstance();
Thread.Sleep(1000);


Console.WriteLine(a);
Console.WriteLine(b);
Console.WriteLine(c);

//partial 2

List<IAbstractCar> garage = new ();

var audiFactory = new AudiFactory();
var hondaFactory = new HondaFactory();
var volvoFactory = new VolvoFactory();
var abramsFactory = new AbramsFactory();
var tigerFactory = new TigerFactory();

garage.Add(audiFactory.CreateCar());
garage.Add(hondaFactory.CreateCar());
garage.Add(volvoFactory.CreateCar());
garage.Add(audiFactory.CreateCar());
garage.Add(abramsFactory.CreateCar());
garage.Add(tigerFactory.CreateCar());

foreach (var car in garage)
{
    if (car is IAbstractTank tank)
    {
        Console.WriteLine($"Tank need {tank.CrewSize} persons to take part in a battle");
    }
    else if (car is IAbstractCargo cargo)
    {
        Console.WriteLine($"Tank volume of cargo is {cargo.TankVolume}");
    }
    else
        Console.WriteLine($"MaxSpeed is {car.MaxSpeed}");
}

// lab 3_3

var container = new Container();

var audi = new AudiFactory().CreateCar();
var volvo = new VolvoFactory().CreateCar();
var abrams = new AbramsFactory().CreateCar();

container.Add(audi);
container.Add(volvo);
container.Add(abrams);


if (audi is IAbstractVehicle audiCar)
{
    audiCar.Color = "Black";
    audiCar.MaxSpeed += 20;
}

if (volvo is IAbstractCargo volvoCargo)
{
    volvoCargo.Tonnage += 1;
}

if (abrams is IAbstractTank abramsTank)
{
    abramsTank.ShotsPerMinute += 1;
}


