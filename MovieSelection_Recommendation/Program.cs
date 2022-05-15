﻿
// This file was auto-generated by ML.NET Model Builder. 

using System;

namespace MovieSelection.Recommendation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create single instance of sample data from first line of dataset for model input
            RateMLModel.ModelInput sampleData = new RateMLModel.ModelInput()
            {
                MovieId = 18F,
                UserId = @"C51B4D56-B514-44AE-813C-8712C8740A94",
            };

            // Make a single prediction on the sample data and print results
            var predictionResult = RateMLModel.Predict(sampleData);

            Console.WriteLine("Using model to make single prediction -- Comparing actual Value with predicted Value from sample data...\n\n");


            Console.WriteLine($"Value: {3F}");
            Console.WriteLine($"MovieId: {21F}");
            Console.WriteLine($"UserId: {@"C51B4D56-B514-44AE-813C-8712C8740A94"}");


            Console.WriteLine($"\n\nPredicted Value: {predictionResult.Score}\n\n");
            Console.WriteLine("=============== End of process, hit any key to finish ===============");
            Console.ReadKey();
        }
    }
}
