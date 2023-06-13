int Number = 69845;

int firstNumber = Number / 10000;//6
int secondNumber = Number / 1000 - firstNumber * 10;//9
int thirdNumber = Number / 100 - (firstNumber * 100 + secondNumber * 10);//8
int fourthNumber = Number / 10 - (firstNumber * 1000 + secondNumber * 100 + thirdNumber * 10);//4
int fifthNumber = Number - (firstNumber * 10000 + secondNumber * 1000 + thirdNumber * 100 + fourthNumber * 10);//5

Console.WriteLine(firstNumber);
Console.WriteLine(secondNumber);
Console.WriteLine(thirdNumber);
Console.WriteLine(fourthNumber);
Console.WriteLine(fifthNumber);
//Console.WriteLine(firstNumber + " " + secondNumber + " " + thirdNumber + " " + fourthNumber + " " + fifthNumber);
Console.ReadLine();