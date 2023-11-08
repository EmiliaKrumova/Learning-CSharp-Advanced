using MilitaryElite.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary <int, ISoldier > soldiers = new Dictionary<int, ISoldier>();
            string input = String.Empty;

            while((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string typeOfSoldier = tokens[0];
                 int id = int.Parse(tokens[1]);
                string firstName = tokens[2];
                string lastName = tokens[3];

                if(typeOfSoldier== "Private")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    IPrivate @private = new Private(id,firstName,lastName,salary);
                    soldiers.Add(id,@private);

                }
                else if(typeOfSoldier== "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(tokens[4]);
                    ILieutenantGeneral general = new LieutenantGeneral(id,firstName,lastName,salary);
                    // след това ще получим списък от ИД за частни войници, които управлява този генерал
                    // клас Генерал, освен конструктор има пропърти Лист<> от Прайвът войници

                    for(int i = 5;i<tokens.Length;i++)
                    {
                        int currentId = int.Parse(tokens[i]);// взимаме ИД на съответния частен войник

                        IPrivate currPrivate = soldiers[currentId] as IPrivate;
                        // извикваме текущия войник от колекцията ни с войници, като кастваме към необходимия ни тип променлива
                        // Защото в колекцията ни са Войници, а на нас ни е нужна за списъка на генерала променлива Частен войник


                       general.Privates.Add(currPrivate);
                        // достъпваме с точките генерала, неговият списък и чак тогава добавяме частния му войник

                                                
                    }
                    soldiers.Add(id, general);
                    // добавяме генерала в колекцията войници

                }
                else if(typeOfSoldier== "Engineer")
                {
                    decimal salary = decimal.Parse(tokens[4]);

                    string currCorp = tokens[5];

                    bool IsValidCorp = Enum.TryParse(currCorp, out Corps result);

                    // проверка дали е валиден Корпс -> от енум колекцията ни за Корпс опитваме на парснем текущия Корп и в булевата записваме резултата от парсването, който ще е false  ако този Корп не се намира в константите на колекцията Корпс
                    if(!IsValidCorp)
                    {
                        continue;
                    }

                    IEngineer engineer = new Engineer(id,firstName,lastName,salary,result);

                    for(int i = 6;i<tokens.Length;i+=2)// защото ще приемам 2 стойности
                    {
                        string partName = tokens[i];
                        int repairHours = int.Parse(tokens[i+1]);
                        IRepair curentRepair = new Repair(partName, repairHours);
                        engineer.Repairs.Add(curentRepair);

                    }

                    soldiers.Add(id, engineer);


                }
                else if (typeOfSoldier== "Commando")
                {
                    decimal salary = decimal.Parse(tokens[4]);

                    string currCorp = tokens[5];

                    bool IsValidCorp = Enum.TryParse(currCorp, out Corps result);

                    // проверка дали е валиден Корпс -> от енум колекцията ни за Корпс опитваме на парснем текущия Корп и в булевата записваме резултата от парсването, който ще е false  ако този Корп не се намира в константите на колекцията Корпс
                    if (!IsValidCorp)
                    {
                        continue;
                    }

                    ICommando comando = new Commando(id, firstName, lastName, salary, result);

                    for (int i = 6; i < tokens.Length; i += 2)// защото ще приемам 2 стойности
                    {
                        string missionCodeName = tokens[i];
                        string missionStatus = tokens[i+1];

                        bool IsValidMission = Enum.TryParse(missionStatus,out Status result1Status);

                        if(!IsValidMission)
                        {
                            continue;
                        }
                        Mission mission = new Mission(missionCodeName, result1Status);
                        comando.Missions.Add(mission);

                    }
                    soldiers.Add (id, comando);


                }
                else if (typeOfSoldier == "Spy")
                {
                    int codeNumber = int.Parse(tokens[4]);
                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);
                    soldiers.Add(id,spy);
                }
            }

            foreach( var soldier in soldiers)
            {
                Console.WriteLine(soldier.Value.ToString());
            }
        }
    }
}