int Number = 69845;

int FirstNumber = Number / 10000;
int SecondNumber = Number / 1000 - FirstNumber * 10;
int ThirdNumber = Number / 100 - (FirstNumber * 100 + SecondNumber * 10);
int FourthNumber = Number / 10 - (FirstNumber * 1000 + SecondNumber * 100 + ThirdNumber * 10);
int FifthNumber = Number - (FirstNumber * 10000 + SecondNumber * 1000 + ThirdNumber * 100 + FourthNumber * 10);

Console.WriteLine(FirstNumber);
Console.WriteLine(SecondNumber);
Console.WriteLine(ThirdNumber);
Console.WriteLine(FourthNumber);
Console.WriteLine(FifthNumber);
//Console.WriteLine(FirstNumber + " " + SecondNumber + " " + ThirdNumber + " " + FourthNumber + " " + FifthNumber);
Console.ReadLine();
