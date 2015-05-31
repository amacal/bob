Feature: NuGet

	In order to support the community using NuGet
	I want to be able to use it in the Bob's tasks

	Scenario: Restoring npgsql packages

		Given there is npgsql repository cloned into "D:/Projects/npgsql" directory
        And "D:/Projects/npgsql" is the working directory
		When I execute the following task

		| Code                            |
		| NuGet.Restore(parameters => {}) |

		Then the following process is being executed

		| Parameter        | Value                               |
		| Process          | D:\Projects\npgsql\.nuget\nuget.exe |
		| WorkingDirectory | D:\Projects\npgsql                  |
		| Arguments        | restore                             |

	Scenario: Restoring npgsql packages with specified solution

		Given there is npgsql repository cloned into "D:/Projects/npgsql" directory
        And "D:/Projects/npgsql" is the working directory
		When I execute the following task

		| Code                                                            |
		| NuGet.Restore(parameters =>                                     |
		| {                                                               |
		| parameters.Solution = FileSystem.Files.Match("Npgsql2012.sln"); |
		| })                                                              |

		Then the following process is being executed

		| Parameter        | Value                                     |
		| Process          | D:\Projects\npgsql\.nuget\nuget.exe       |
		| WorkingDirectory | D:\Projects\npgsql                        |
		| Arguments        | restore D:\Projects\npgsql\Npgsql2012.sln |

    Scenario: Restoring npgsql packages with downloaded tool

    	Given there is npgsql repository cloned into "D:/Projects/npgsql" directory
        And "D:/Projects/npgsql" is the working directory
        And "C:/Windows/Temp" is the temp directory
		When I execute the following task

		| Code                                   |
		| NuGet.Restore(parameters =>            |
		| {                                      |
		| parameters.Path = NuGet.Path.Online(); |
		| })                                     |

		Then the following process is being executed

		| Parameter        | Value                     |
		| Process          | C:\Windows\Temp\nuget.exe |
		| WorkingDirectory | D:\Projects\npgsql        |
		| Arguments        | restore                   |

    Scenario: Installing NUnit.Runners package

    	Given there is npgsql repository cloned into "D:/Projects/npgsql" directory
        And "D:/Projects/npgsql" is the working directory
		When I execute the following task

		| Code                                                        |
		| NuGet.Install(parameters =>                                 |
		| {                                                           |
		| parameters.Package = NuGet.Repository.Get("NUnit.Runners"); |
		| })                                                          |

		Then the following process is being executed

		| Parameter        | Value                                                |
		| Process          | D:\Projects\npgsql\.nuget\nuget.exe                  |
		| WorkingDirectory | D:\Projects\npgsql                                   |
		| Arguments        | install NUnit.Runners -o D:\Projects\npgsql\packages |
