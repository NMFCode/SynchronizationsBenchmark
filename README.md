# SynchronizationsBenchmark
This repository contains a benchmark for NMF Synchronizations

To run the benchmark, follow these steps:
- Make sure you have Java JRE 1.8 and .NET Framework 4.5.2 installed
- Download the code
- Compile it
- - When using Visual Studio, simply open the solution and compile in Release mode for the x64 architecture
- - When using MSBuild directly, please make sure to pass the build mode as parameters `/p:Configuration=Release /p:Platform="x86"`
- Navigate to the binaries in bin\x64\Release
- Run the `SynchronizationBenchmark.exe`. This will take two to four days to complete(!)
- Run the R script results.r in the root directory of the repository

The script generates two files with graphs:
- `init.pdf`: Contains the average times to perform a single transformation
- `updates.pdf`: Contains the average times to perform 20 elementary model changes
