using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 08 |");
            Console.WriteLine("+-------------------------+");

            var input =
                File
                    .ReadAllLines("input.1.txt")
                    .Select(x => x.Split(' '))
                    .Select(x => new Instruction
                    {
                        Register = x[0],
                        Cmd = x[1],
                        Value = int.Parse(x[2]),
                        Condition = new Condition
                        {
                            Register = x[4],
                            Operator = x[5],
                            Value = int.Parse(x[6])
                        }
                    });

            var registers = input.SelectMany(x => new [] {x.Register, x.Condition.Register}).Distinct().ToDictionary(x => x, x => 0);

            var absoluteMax = registers.Max(x => x.Value);
            foreach(var i in input)
            {
                if(IsTrue(registers, i.Condition))
                {
                    registers[i.Register] = registers[i.Register] + GetValue(i);
                }

                var currentMax = registers.Max(x => x.Value);
                if(currentMax > absoluteMax)
                {
                    absoluteMax = currentMax;
                }
            }

            var max = registers.Max(x => x.Value);

            Console.WriteLine($"Largest value in register at the end is {max}");
            Console.WriteLine($"Largest value in register at any time is {absoluteMax}");

            Console.WriteLine($" - Glædelig jul");
        }

        private static int GetValue(Instruction instruction)
        {
            var val = instruction.Value;

            if(instruction.Cmd == "dec")
            {
                val *= -1;
            }

            return val;
        }

        private static bool IsTrue(Dictionary<string, int> registers, Condition condition)
        {
            switch(condition.Operator)
            {
                case ">":
                    return registers[condition.Register] > condition.Value;
                case "<":
                    return registers[condition.Register] < condition.Value;
                case "==":
                    return registers[condition.Register] == condition.Value;
                case "!=":
                    return registers[condition.Register] != condition.Value;
                case "<=":
                    return registers[condition.Register] <= condition.Value;
                case ">=":
                    return registers[condition.Register] >= condition.Value;
                default:
                    throw new NotSupportedException("Invalid operator");
            }
        }
    }
}
