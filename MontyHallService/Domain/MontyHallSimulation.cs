namespace MontyHallService.Domain
{
        public static class MontyHallSimulation
        {
            public static char[] GetDoors()
            {
                List<char> elements = new List<char>() { 'C', 'G' }; // C-CAR, G- GOAT
                char[] doors = new char[3]; // Declared three doors
                Random random = new Random();
                for (int i = 0; i < 3; i++)
                {
                    var ranInt = random.Next(2);
                    if (elements[ranInt] == 'C')
                    {
                        doors[i] = 'C';
                    }
                    else
                        doors[i] = 'G';
                }

                var count = doors.Count(x => x == 'C');
                if (count > 1 || count == 0)
                {
                    doors = GetDoors();
                    return doors;
                }
                return doors;
            }

            public static int MontySimulationCall(int numberOfPlay, bool isChange)
            {
                int successCount = 0;
                for (int iter = 0; iter < numberOfPlay; iter++)
                {
                    successCount += Simulation(isChange);
                }
                Console.WriteLine("Success:" + successCount);
                return successCount;
            }

            public static int Simulation(bool isChange)
            {
                Random random = new Random();
                int returnValue = 0;
                
            /* Start GAME */

                var doors = GetDoors(); //Doors are Ready for Game
                var guestChoise = random.Next(3); //Guest chosed a door.               
                var hostChoise = GetHostChoise(guestChoise, doors); //Host Chosed a door to open
                
                //Console.WriteLine("Host Opened :" + doors[hostChoise]);

                var changedDoor = doors.Where((i, index) => index != 1 && index != 2); // Guest wish to change the door.
               
                // Console.WriteLine(guestChoise + " " + hostChoise + doors[0]+" "+doors[1]+" " + doors[2]);

                // No change
                if (!isChange)
                {
                    if (doors[guestChoise] == 'C') returnValue = 1;
                    //  Console.WriteLine(doors[guestChoise] == 'C' ? "Success" : "Fail");
                }
                else
                {
                    if (doors[guestChoise] == 'C') returnValue = 1;
                    //  Console.WriteLine(changedDoor.ToList().FirstOrDefault() == 'C' ? "Success" : "Fail");
                }

                return returnValue;
            }

            public static int GetHostChoise(int guestChoise, char[] doors)
            {

                Random random = new Random();
                var hostNumber = random_except(3, new int[] { guestChoise });
                var hostChoise = doors[hostNumber] != 'G' ? random_except(3, new int[] { guestChoise, hostNumber }) : hostNumber;
                return hostChoise;
            }

            public static int random_except(int maxValue, int[] exceptValue)
            {
                Random r = new Random();
                exceptValue = exceptValue.OrderBy(x => x).ToArray();
                int result = r.Next(maxValue - exceptValue.Length);

                for (int i = 0; i < exceptValue.Length; i++)
                {
                    if (result < exceptValue[i])
                        return result;
                    result++;
                }
                return result;
            }
        }
}
