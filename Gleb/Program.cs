

using Gleb;

DetectTimer detectTimer = new DetectTimer();
//Pract10 pr = new Pract10();

//Console.WriteLine("Послiдовна частина");
//detectTimer.Start();
//pr.ExecuteSeq();
//detectTimer.Stop();

//Console.WriteLine("\n");


//Console.WriteLine("Паралельна частина");
//detectTimer.Start();
//pr.ExecutePar();
//detectTimer.Stop();




//Pract1112 pract1112 = new Pract1112();

//detectTimer.Start();
//pract1112.ExecuteSeq();
//detectTimer.Stop();

//Console.WriteLine("\n");
//detectTimer.Start();
//pract1112.ExecutePar();
//detectTimer.Stop();


//Pract13 pract13 = new Pract13();

//pract13.InitParams();

//Console.WriteLine("Послiдовна частина");
//detectTimer.Start();
//pract13.ExecuteSeq();
//detectTimer.Stop();

//Console.WriteLine("\n");
//Console.WriteLine("Паралельна частина з Parallel.For");
//detectTimer.Start();
//pract13.ExecutePar();
//detectTimer.Stop();


//Console.WriteLine("\n");
//Console.WriteLine("Паралельна частина з Task");
//detectTimer.Start();
//pract13.ExecuteParTask();
//detectTimer.Stop();


Pract15 pract15 = new Pract15();

pract15.InitMatrixSizes();


Console.WriteLine("\n");
Console.WriteLine("Послiдовна частина");
detectTimer.Start();
pract15.ExecuteSeq();
detectTimer.Stop();


Console.WriteLine("\n");

Console.WriteLine("Паралельна частина з Parallel.For");
detectTimer.Start();
pract15.ExecutePar();
detectTimer.Stop();


pract15.ClearMatrixResult();

Console.WriteLine("\n");
Console.WriteLine("Паралельна частина з Task");
detectTimer.Start();
pract15.ExecuteParTask();
detectTimer.Stop();