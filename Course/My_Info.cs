using System;

namespace My_Info
{
     public static class Brand
    {
        public static void show_info()
        {
            Console.WriteLine("The creater of the project is " + Creater);
        }

        public const string Creater = "ILYA DZERAZIAK";

#region Ascii art
        static string Title { get { return @" 

                        _____ _               _____                        _       _     
                       |_   _| |             |  __ \                      (_)     | |    
                         | | | |_   _  __ _  | |  | |_______ _ __ __ _ _____  __ _| | __ 
                         | | | | | | |/ _` | | |  | |_  / _ \ '__/ _` |_  / |/ _` | |/ / 
                        _| |_| | |_| | (_| | | |__| |/ /  __/ | | (_| |/ /| | (_| |   <  
                       |_____|_|\__, |\__,_| |_____//___\___|_|  \__,_/___|_|\__,_|_|\_\ 
                                 __/ |____           _           _                       
                                |___/  __ \         (_)         | |                      
                                    | |__) | __ ___  _  ___  ___| |_                     
                                    |  ___/ '__/ _ \| |/ _ \/ __| __|                    
                                    | |   | | | (_) | |  __/ (__| |_                     
                                    |_|   |_|  \___/| |\___|\___|\__|                    
                                                   _/ |                                  
                                                  |__/                                 
                                                                                                                                                   ";  } }
#endregion

        public static void show_logo()
        {
            Console.WriteLine(Title);
        }
    }
}