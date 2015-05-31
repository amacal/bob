Feature: NUnit

	In order to support the community testing with NUnit
	I want to be able to use it in the Bob's tasks

	Scenario: Executing all tests

  		Given there is npgsql repository cloned into "D:/Projects/npgsql" directory
        And "D:/Projects/npgsql" is the working directory
        And there is npgsql repository already restored in "D:/Projects/npgsql/packages" directory
        And there is npgsql repository already compiled in "D:/Projects/npgsql/build/output" directory
		When I execute the following task

		| Code                                                                        |
		| NUnit.Execute(parameters =>                                                 |
		| {                                                                           |
		| parameters.Assemblies = FileSystem.Files.Match("build/output/*.Tests.dll"); |
		| })                                                                          |

		Then the following process is being executed

		| Parameter        | Value                                                                   |
		| Process          | D:\Projects\npgsql\packages\NUnit.Runners.2.6.4\tools\nunit-console.exe |
		| WorkingDirectory | D:\Projects\npgsql                                                      |
		| Arguments        | D:\Projects\npgsql\build\output\Npgsql.Tests.dll                        |
