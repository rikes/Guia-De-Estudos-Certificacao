using System;
using System.Collections.Generic;
using System.IO;

namespace _4._1_DriverInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                DriveInfo[] drivesInfo = DriveInfo.GetDrives();

                foreach (DriveInfo driveInfo in drivesInfo)
                {
                    Console.WriteLine("Drive {0}", driveInfo.Name);
                    Console.WriteLine("File type: {0}", driveInfo.DriveType);
                    Console.WriteLine("Raiz do diretório {0}", driveInfo.RootDirectory);

                    //Verifica se o drive está disponível - Caso não esteja um null pointer pode ser lançado.
                    if (driveInfo.IsReady == true)
                    {
                        Console.WriteLine("Volume label: {0}", driveInfo.VolumeLabel);
                        Console.WriteLine("File system: {0}", driveInfo.DriveFormat);
                        Console.WriteLine("Drive Type: {0}", driveInfo.DriveType);
                        //bytes -> kb -> mb 
                        Console.WriteLine("Available space to current user: {0, 15} mb", ((driveInfo.AvailableFreeSpace)/1024)/1024);
                        Console.WriteLine("Total available space: {0, 15} mb", ((driveInfo.TotalFreeSpace) / 1024)/ 1024);
                        Console.WriteLine("Total size of drive: {0, 15} mb", ((driveInfo.TotalSize) / 1024)/ 1024);
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
