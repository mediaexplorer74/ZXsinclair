﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace TestHighPerformanceTimer
{
    class Program
    {
        const int num_steps = 100000000;

        static void Main(string[] args)
        {

            /*
                La precisión de 15 ms (en realidad puede ser de 15-25 ms) se basa en la resolución del temporizador de Windows 55 Hz / 65 Hz. Este es también el período básico de TimeSlice.
                El valor del reloj del sistema que DateTime.Nowlee solo se actualiza cada 15 ms aproximadamente (o 10 ms en algunos sistemas), razón por la cual los tiempos se cuantifican alrededor de esos intervalos. Hay un efecto de cuantificación adicional que resulta del hecho de que su código se está ejecutando en un sistema operativo multiproceso y, por lo tanto, hay tramos donde su aplicación no está "viva" y, por lo tanto, no mide el tiempo actual real.
             */

            SerialPi();
            SerialPi();
            SerialPi();

           
            var x = HighResolutionDateTime.IsAvailable;

            var pHighResolutionDateTime = HighResolutionDateTime.UtcNow;

            //Thread.Sleep(314);
            SerialPi();

            var pHighResolutionDateTimeDiff = HighResolutionDateTime.UtcNow - pHighResolutionDateTime;

            var pStopwatch = Stopwatch.StartNew();

            //Thread.Sleep(314);
            SerialPi();

            pStopwatch.Stop();

            var pTicksD1 = DateTime.UtcNow.Ticks;

            SerialPi();

            var pTicksD2 = DateTime.UtcNow.Ticks;

            //SerialPi();
            //var xx = 1;
            //for (var i = 4; i > 0; i--)
            //    xx += i;



            Console.WriteLine("Stopwatch");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"IsHighResolution:{Stopwatch.IsHighResolution}");
            long frequency = Stopwatch.Frequency;
            Console.WriteLine($"Timer frequency in ticks per second = {frequency}");
            long nanosecPerTick = (1000L * 1000L * 1000L) / frequency;
            Console.WriteLine($"Timer is accurate within {nanosecPerTick} nanoseconds");

            var pElapsedMS = (double)pStopwatch.ElapsedTicks * 1000L / Stopwatch.Frequency;
            var pElapsedNS = (double)pStopwatch.ElapsedTicks * 1000L * 1000L * 1000L / Stopwatch.Frequency;

            Console.WriteLine($"SerialPi elapse ms: {pElapsedMS}");
            Console.WriteLine($"SerialPi elapse ns: {pElapsedNS}");

            //Console.WriteLine($""pCounter1.Elapsed. + ": " + result);
            Console.WriteLine("---------------------------------");
            Console.WriteLine();
            Console.WriteLine("HighResolutionDateTime");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"SerialPi elapse ms: {pHighResolutionDateTimeDiff.Ticks / (double)TimeSpan.TicksPerMillisecond}");
            Console.WriteLine($"SerialPi elapse ns: {pHighResolutionDateTimeDiff.Ticks / ((double)TimeSpan.TicksPerMillisecond / (1000L * 1000L))}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine();

            Console.WriteLine("---------------------------------");
            Console.WriteLine();
            Console.WriteLine("TimeDate");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"SerialPi elapse ms: {(pTicksD2-pTicksD1) / (double)TimeSpan.TicksPerMillisecond}");
            Console.WriteLine($"SerialPi elapse ns: {(pTicksD2 - pTicksD1) / ((double)TimeSpan.TicksPerMillisecond / (1000L * 1000L))}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine();

            var pFreq2 = new HiResTimer();
            var pZX8081Z80Freq = (long)(3.25 * 1000 * 1000);
            var pRes = frequency / (double)pZX8081Z80Freq;

            /*
                3250000
                10000000

                3 ticks -> 1 cycle
             */

            Console.ReadLine();
        }

        /// <summary>Estimates the value of PI using a for loop.</summary>
        static double SerialPi()
        {
            double sum = 0.0;
            double step = 1.0 / (double)num_steps;
            for (int i = 0; i < num_steps; i++)
            {
                double x = (i + 0.5) * step;
                sum = sum + 4.0 / (1.0 + x * x);
            }
            return step * sum;
        }

    }
}