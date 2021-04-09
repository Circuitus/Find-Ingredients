using System;
using System.IO;

namespace Folder_with_everything_for_AS91896
{
    class Program
    {

        //read data from a file
        //receive filename
        //what to do?
        //read information from the file line by line and store the information
        //needs a string variable to store a line from the file
        //needs loop to go through all lines
        //09C10026	"Yoghurt, natural, regular fat (fat approximately 4%)"	355	5.7	4.2	2.7	4.8	4.8	72
        //what can I do with this info
        //split information by tab and insert it into an array
        //print the array

        public static void ReadFromFile(string fileName)
        {    
            System.IO.StreamReader readNutrient = new System.IO.StreamReader(fileName);

            string line;
            //string[] info = line.Split("\t");
            Console.WriteLine("Insert an ingredient you would like to search for");
            string searchIngredient = Console.ReadLine().ToLower().Trim();
            //Console.WriteLine($"{info[0]} {info[1]} {info[2]} {info[3]} {info[4]} {info[5]} {info[6]} {info[7]} {info[8]}");
            string[] forLength = File.ReadAllLines(fileName); //gets total number of lines in file
            //Console.WriteLine(forLength.Length); testing to see if file length is correct
            
            for (int i = 0; i <= forLength.Length-1; i++){
                line = readNutrient.ReadLine();
                string[] info = line.Split("\t");
                //if(line == searchIngredient){
                //Console.WriteLine(info[1]);
                string foodComposition = info[1].Replace('"', ' ').Trim().ToLower(); //turns string food composition into the ingredients list
                //foodComposition.Replace('"', ' ');
                string[] ingredientsList = foodComposition.Split(",");
                //Array.Find(ingredientsList, x => info[0] == searchIngredient); attempt at using lambda method. Only returns empty lines
                bool TorF = foodComposition.Contains(searchIngredient);//if a line contains an ingredient, TorF = true.

                //if(Array.Find(ingredientsList, x => info[0] == searchIngredient) != null) {
                //    Console.WriteLine(line);
                //}
                if (TorF == true) {
                    Console.WriteLine(line); //If TorF = true then the line prints
                } //end if
                
            }

            /*for (int i = 0; i <= 2534; i++){
                line = readNutrient.ReadLine();
                string[] ingredients = info[1].Split(",");
                string searchedIng = ingredients[0];
                if (searchedIng.ToLower().Trim().Replace('"', ' ').Replace(" ", "") == searchIngredient.ToLower().Trim().Replace('"', ' ').Replace(" ", "")){
                    Console.WriteLine(searchedIng);
                }
            }//end if
            */
        }//end readfromfile

        static int indexOfSearchItem(string fileName)
        {
            //will return the index of the column that the user wants to search.
            Console.WriteLine("Welcome, USER, please choose what you would like to search by: \nFood ID    Name");
            string searchType = Console.ReadLine().ToLower().Trim().Replace(" ", "");
            
            System.IO.StreamReader readNutrient = new System.IO.StreamReader(fileName);
            string searchCriteria = readNutrient.ReadLine().Trim().ToLower();
            string[] searchCriteriaList = searchCriteria.Split("\t");
            //Console.WriteLine($"{searchCriteriaList[0]}, {searchCriteriaList[1]}, {searchCriteriaList[2]}");
            //testing to see if it reads the first line of the file for the search criteria
            //if(searchType == searchCriteriaList[0].ToLower().Trim()){
            //    Console.WriteLine("This is a valid input");
            //}
            bool hopefullyTrue = searchCriteria.Contains(searchType);

            if(hopefullyTrue == true){
                Console.WriteLine(searchType);
            }
            return 1;
        }//end indexOfSearchItem
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            const string fileName = "Nutrientfile.txt";

            //Console.WriteLine("Welcome, USER, please choose what you would like to search by: \nFood ID    Name");
            //string searchType = Console.ReadLine().ToLower().Trim().Replace(" ", "");
            // takes input from user and removes spaces, whitespace at the end of text, converts to lowercase letters
            //indexOfSearchItem(fileName);
            ReadFromFile(fileName);
        }//end main
    }//end class
}//end namespace
