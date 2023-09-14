using System;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a Alphanumeric string ");
            var userInput = Console.ReadLine();
            Console.WriteLine();
            if (string.IsNullOrEmpty(userInput))
            { 
                Console.WriteLine("Not able to procceed, please enter a valid input ");
            }
            else
            {
                FindString(userInput);
            }                                     
            Console.ReadKey();
        }        

        private static void FindString(string input)
        {           
            long finalSum = 0;
            for (int firstValue = 0; firstValue < input.Length; firstValue++)
            {
                for (int nextValue = firstValue+1; nextValue < input.Length; nextValue++)
                {
                    if (input[firstValue] == input[nextValue])  
                    {
                        if (IsInputHasOnlyNumbers(input.Substring(firstValue, nextValue - firstValue)))
                        {
                            DisplayResult(input, firstValue, nextValue);
                            long numforSum = Convert.ToInt64(input.Substring(firstValue, nextValue - firstValue + 1));
                            finalSum += numforSum;
                            break;
                        }
                        else 
                        { 
                            break;
                        }
                    }
                }
            }
            if (finalSum != 0)
            { 
                Console.Write($"Total - {finalSum}");
            }
            else 
            { 
                Console.Write("Input is not in proper format. Example : 29535123p48723487597645723645 ");
            }


            Console.ReadLine();
        }

        private static void DisplayResult(string original, int fromIndex, int toIndex)
        {           
            var originalColor = Console.ForegroundColor;            
            Console.Write(original.Substring(0, fromIndex));
            Console.ForegroundColor = ConsoleColor.Cyan;           
            Console.Write(original.Substring(fromIndex, toIndex - fromIndex + 1));            
            Console.ForegroundColor = originalColor;           
            if (toIndex < original.Length - 1) 
                Console.Write(original.Substring(toIndex + 1));           
            Console.WriteLine();
        }

        private static bool IsInputHasOnlyNumbers(string str)
        {
            foreach (var item in str)
            {
              if(item !< '0' || item !> '9')
                {
                    return false;
                }                
            }
            return true;
        }
    }    
}