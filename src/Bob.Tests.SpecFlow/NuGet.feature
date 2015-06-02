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

    Scenario: Installing NUnit.Runners package for npgsql

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

	Scenario: Creating npgsql package from template

    	Given there is npgsql repository cloned into "D:/Projects/npgsql" directory
        And "D:/Projects/npgsql" is the working directory
		And "C:/Windows/Temp" is the temp directory
        When I execute the following task

		| Code                                                                        |
		| NuGet.Pack(parameters =>                                                    |
		| {                                                                           |
		| parameters.Path = NuGet.Path.Online();                                      |
		| parameters.Specification = NuGet.Specification.Template("template.nuspec"); |
		| })                                                                          |

		Then the following process is being executed

   		| Parameter        | Value                                   |
   		| Process          | C:\Windows\Temp\nuget.exe               |
   		| WorkingDirectory | D:\Projects\npgsql                      |
   		| Arguments        | pack D:\Projects\npgsql\template.nuspec |

    Scenario: Creating npgsql package from scratch

    	Given there is npgsql repository cloned into "D:/Projects/npgsql" directory
        And there is npgsql repository already restored in "D:/Projects/npgsql/packages" directory
        And there is npgsql repository already compiled in "D:/Projects/npgsql/build/output" directory
        And "D:/Projects/npgsql" is the working directory
		And "C:/Windows/Temp" is the temp directory
        When I execute the following task

		| Code                                                                 |
		| NuGet.Pack(parameters =>                                             |
		| {                                                                    |
		| parameters.Path = NuGet.Path.Online();                               |
		| parameters.Specification = NuGet.Specification.Inline(package =>     |
		| {                                                                    |
		| package.Id = "npgsql";                                               |
		| package.Version = "2.2.6";                                           |
		| package.Authors = "John Smith";                                      |
		| package.Description = "";                                            |
		| package.Files["src"] = FileSystem.Files.Match("build/output/*.dll"); |
		| });                                                                  |
		| })                                                                   |

		Then the following process is being executed

   		| Parameter        | Value                            |
   		| Process          | C:\Windows\Temp\nuget.exe        |
   		| WorkingDirectory | D:\Projects\npgsql               |
   		| Arguments        | pack C:\Windows\Temp\file.nuspec |
