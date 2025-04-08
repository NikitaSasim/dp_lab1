﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public enum VehicleClass
    {
        Hatchback,
        Sedan,
        Coupe
    }

    public enum WheelDrive
    {
        Front,
        Back
    }

    internal interface IAbstractCarFactory
    {
        public IAbstractCar CreateCar();
    }


    internal interface IAbstractCar
    {
        double Weight { get; set; }
        double Length { get; set; }
        double MaxSpeed { get; set; }
    }

    internal interface IAbstractCargo : IAbstractCar
    {
        double Tonnage { get; set; }

        double TankVolume { get; set; }

        int AxlesAmount { get; set; }
    }

    
    internal interface IAbstractTank : IAbstractCar
    {
        int ProjectileCaliber { get; set; }

        int ShotsPerMinute { get; set; }

        int CrewSize { get; set; }
    }

    internal interface IAbstractVehicle : IAbstractCar
    {
        WheelDrive WheelDrive { get; set; }

        VehicleClass Class { get; set; }

        string? Color { get; set; }
    }


    internal abstract class AbstractCargo : IAbstractCargo
    {
        public double Weight { get; set; }
        public double Length { get; set; }
        public double MaxSpeed { get; set; }
        public double Tonnage { get; set; }
        public double TankVolume { get; set; }
        public int AxlesAmount { get; set; }
    }

    internal abstract class AbstractVehicle : IAbstractVehicle
    {
        public double Weight { get; set; }
        public double Length { get; set; }
        public double MaxSpeed { get; set; }
        public WheelDrive WheelDrive { get; set; }
        public VehicleClass Class { get; set; }
        public string? Color { get; set; }


    }

    internal abstract class AbstractTank : IAbstractTank
    {
        public double Weight { get; set; }
        public double Length { get; set; }
        public double MaxSpeed { get; set; }
        public int ProjectileCaliber { get; set; }
        public int ShotsPerMinute { get; set; }
        public int CrewSize { get; set; }
    }


    internal class Abrams : AbstractTank
    {
    }

    internal class Audi : AbstractVehicle
    {
    }

    internal class Honda : AbstractVehicle
    {
    }

    internal class Man : AbstractCargo
    {
    }

    internal class Merkava : AbstractTank
    {
    }

    internal class Scania : AbstractCargo
    {
    }

    internal class Tesla : AbstractVehicle
    {
    }

    internal class Tiger : AbstractTank
    {
    }

    internal class Volvo : AbstractCargo
    {
    }

    

    internal class AbramsFactory : IAbstractCarFactory
    {
        private const int DefaultProjectileCaliber = 40;
        private const int DefaultShotsPerMinute = 5;
        private const int DefaultCrewSize = 4;
        private const double DefaultWeight = 19000;
        private const double DefaultLength = 10;
        private const double DefaultMaxSpeed = 90;

        public IAbstractCar CreateCar()
        {
            var abrams = new Abrams()
            {
                ProjectileCaliber = DefaultProjectileCaliber,
                ShotsPerMinute = DefaultShotsPerMinute,
                CrewSize = DefaultCrewSize,
                Weight = DefaultWeight,
                Length = DefaultLength,
                MaxSpeed = DefaultMaxSpeed

            };
            return abrams;
        }
    }

    internal class AudiFactory : IAbstractCarFactory
    {
        private const WheelDrive DefaultWheelDrive = WheelDrive.Front;
        private const VehicleClass DefaultClass = VehicleClass.Sedan;
        private const string DefaultColor = "Red";
        private const double DefaultWeight = 1500;
        private const double DefaultLength = 6.5;
        private const double DefaultMaxSpeed = 200;

        public IAbstractCar CreateCar()
        {
            var audi = new Audi
            {
                WheelDrive = DefaultWheelDrive,
                Class = DefaultClass,
                Color = DefaultColor,
                Weight = DefaultWeight,
                Length = DefaultLength,
                MaxSpeed = DefaultMaxSpeed

            };
            return audi;
        }
    }

    internal class HondaFactory : IAbstractCarFactory
    {
        private const WheelDrive DefaultWheelDrive = WheelDrive.Back;
        private const VehicleClass DefaultClass = VehicleClass.Hatchback;
        private const string DefaultColor = "Black";
        private const double DefaultWeight = 1300;
        private const double DefaultLength = 5.5;
        private const double DefaultMaxSpeed = 190;

        public IAbstractCar CreateCar()
        {
            var honda = new Honda
            {
                WheelDrive = DefaultWheelDrive,
                Class = DefaultClass,
                Color = DefaultColor,
                Weight = DefaultWeight,
                Length = DefaultLength,
                MaxSpeed = DefaultMaxSpeed

            };
            return honda;
        }
    }

    internal class ManFactory : IAbstractCarFactory
    {
        private const double DefaultTonnage = 22;
        private const double DefaultTankVolume = 220;
        private const int DefaultAxlesAmount = 3;
        private const double DefaultWeight = 22000;
        private const double DefaultLength = 21;
        private const double DefaultMaxSpeed = 130;

        public IAbstractCar CreateCar()
        {
            var volvo = new Volvo()
            {
                Tonnage = DefaultTonnage,
                TankVolume = DefaultTankVolume,
                AxlesAmount = DefaultAxlesAmount,
                Weight = DefaultWeight,
                Length = DefaultLength,
                MaxSpeed = DefaultMaxSpeed

            };
            return volvo;
        }
    }

    internal class MerkavaFactory : IAbstractCarFactory
    {
        private const int DefaultProjectileCaliber = 35;
        private const int DefaultShotsPerMinute = 6;
        private const int DefaultCrewSize = 4;
        private const double DefaultWeight = 22000;
        private const double DefaultLength = 11;
        private const double DefaultMaxSpeed = 85;

        public IAbstractCar CreateCar()
        {
            var merkava = new Merkava()
            {
                ProjectileCaliber = DefaultProjectileCaliber,
                ShotsPerMinute = DefaultShotsPerMinute,
                CrewSize = DefaultCrewSize,
                Weight = DefaultWeight,
                Length = DefaultLength,
                MaxSpeed = DefaultMaxSpeed

            };
            return merkava;
        }
    }

    internal class ScaniaFactory : IAbstractCarFactory
    {
        private const double DefaultTonnage = 21;
        private const double DefaultTankVolume = 210;
        private const int DefaultAxlesAmount = 4;
        private const double DefaultWeight = 19000;
        private const double DefaultLength = 22;
        private const double DefaultMaxSpeed = 140;

        public IAbstractCar CreateCar()
        {
            var volvo = new Volvo()
            {
                Tonnage = DefaultTonnage,
                TankVolume = DefaultTankVolume,
                AxlesAmount = DefaultAxlesAmount,
                Weight = DefaultWeight,
                Length = DefaultLength,
                MaxSpeed = DefaultMaxSpeed

            };
            return volvo;
        }
    }

    internal class TeslaFactory : IAbstractCarFactory
    {
        private const WheelDrive DefaultWheelDrive = WheelDrive.Front;
        private const VehicleClass DefaultClass = VehicleClass.Coupe;
        private const string DefaultColor = "White";
        private const double DefaultWeight = 1900;
        private const double DefaultLength = 5.9;
        private const double DefaultMaxSpeed = 220;

        public IAbstractCar CreateCar()
        {
            var tesla = new Tesla
            {
                WheelDrive = DefaultWheelDrive,
                Class = DefaultClass,
                Color = DefaultColor,
                Weight = DefaultWeight,
                Length = DefaultLength,
                MaxSpeed = DefaultMaxSpeed

            };
            return tesla;
        }
    }

    internal class TigerFactory : IAbstractCarFactory
    {
        private const int DefaultProjectileCaliber = 42;
        private const int DefaultShotsPerMinute = 4;
        private const int DefaultCrewSize = 5;
        private const double DefaultWeight = 27000;
        private const double DefaultLength = 12;
        private const double DefaultMaxSpeed = 85;

        public IAbstractCar CreateCar()
        {
            var merkava = new Merkava()
            {
                ProjectileCaliber = DefaultProjectileCaliber,
                ShotsPerMinute = DefaultShotsPerMinute,
                CrewSize = DefaultCrewSize,
                Weight = DefaultWeight,
                Length = DefaultLength,
                MaxSpeed = DefaultMaxSpeed

            };
            return merkava;
        }
    }

    internal class VolvoFactory : IAbstractCarFactory
    {
        private const double DefaultTonnage = 20;
        private const double DefaultTankVolume = 200;
        private const int DefaultAxlesAmount = 4;
        private const double DefaultWeight = 20000;
        private const double DefaultLength = 20;
        private const double DefaultMaxSpeed = 140;

        public IAbstractCar CreateCar()
        {
            var volvo = new Volvo()
            {
                Tonnage = DefaultTonnage,
                TankVolume = DefaultTankVolume,
                AxlesAmount = DefaultAxlesAmount,
                Weight = DefaultWeight,
                Length = DefaultLength,
                MaxSpeed = DefaultMaxSpeed

            };
            return volvo;
        }
    }


}
